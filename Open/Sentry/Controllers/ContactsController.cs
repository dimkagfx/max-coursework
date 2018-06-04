using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Core;
using Open.Data.Location;
using Open.Domain.Location;
using Open.Facade.Location;
namespace Open.Sentry.Controllers {
    public class ContactsController : Controller {

        private readonly IAddressObjectsRepository addresses;
        private readonly ITelecomDeviceRegistrationObjectsRepository deviceRegistrations;
        internal const string emailProperties = "ID, EmailAddress, ValidFrom, ValidTo";
        internal const string webProperties = "ID, Url, ValidFrom, ValidTo";
        internal const string telecomProperties =
            "ID, CountryCode, AreaCode, Number, Extension, NationalDirectDialingPrefix, DeviceType, ValidFrom, ValidTo";
        internal const string adrProperties =
            "ID, AddressLine, City, RegionOrState, ZipOrPostalCode, Country, ValidFrom, ValidTo";

        #region other code ...
        public ContactsController(IAddressObjectsRepository a,
            ITelecomDeviceRegistrationObjectsRepository d) {
            addresses = a;
            deviceRegistrations = d;
        }
        public async Task<IActionResult> Index(string sortOrder = null,
            string currentFilter = null,
            string searchString = null,
            int? page = null) {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortAddressType"] = string.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewData["SortToString"] = sortOrder == "string" ? "string_desc" : "string";
            ViewData["SortValidFrom"] = sortOrder == "validFrom" ? "validFrom_desc" : "validFrom";
            ViewData["SortValidTo"] = sortOrder == "validTo" ? "validTo_desc" : "validTo";
            addresses.SortOrder = sortOrder != null && sortOrder.EndsWith("_desc")
                ? SortOrder.Descending
                : SortOrder.Ascending;
            addresses.SortFunction = getSortFunction(sortOrder);
            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            addresses.SearchString = searchString;
            addresses.PageIndex = page ?? 1;
            var l = await addresses.GetObjectsList();
            return View(new AddressViewModelsList(l));
        }
        private Func<AddressDbRecord, object> getSortFunction(string sortOrder) {
            if (string.IsNullOrWhiteSpace(sortOrder)) return x => x.GetType().Name;
            if (sortOrder.StartsWith("type")) return x => x.GetType().Name;
            if (sortOrder.StartsWith("validTo")) return x => x.ValidTo;
            if (sortOrder.StartsWith("validFrom")) return x => x.ValidFrom;
            return x => x.Address;
        }
        public async Task<IActionResult> Delete(string id) {
            var c = await addresses.GetObject(id);

            switch (c) {
                case WebAddressObject web:
                    return View("DeleteWeb",
                        AddressViewModelFactory.Create(web) as WebPageAddressViewModel);
                case EmailAddressObject email:
                    return View("DeleteEmail",
                        AddressViewModelFactory.Create(email) as EMailAddressViewModel);
                case TelecomAddressObject tel:
                    await deviceRegistrations.LoadAddresses(tel);
                    return View("DeleteTelecom",
                        AddressViewModelFactory.Create(tel) as TelecomAddressViewModel);
                case GeographicAddressObject adr:
                    await deviceRegistrations.LoadDevices(adr);
                    return View("DeleteAddress",
                        AddressViewModelFactory.Create(adr) as GeographicAddressViewModel);
            }

            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            var c = await addresses.GetObject(id);
            await addresses.DeleteObject(c);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string id) {
            var address = await addresses.GetObject(id);
            switch (address) {
                case WebAddressObject _: return RedirectToAction("EditWeb", new {id});
                case EmailAddressObject _: return RedirectToAction("EditEmail", new { id });
                case TelecomAddressObject _: return RedirectToAction("EditTelecom", new { id });
                default: return RedirectToAction("EditAddress", new { id });
            }
        }
        public async Task<IActionResult> EditWeb(string id) {
            var address = await addresses.GetObject(id);
            return View(AddressViewModelFactory.Create(address) as WebPageAddressViewModel);
        }
        public async Task<IActionResult> EditEmail(string id) {
            var address = await addresses.GetObject(id);
            return View(AddressViewModelFactory.Create(address) as EMailAddressViewModel);
        }
        public async Task<IActionResult> EditAddress(string id,
            string currentFilter = null,
            string searchString = null,
            int? page = null)
        {

            if (searchString != null) page = 1;
            else searchString = currentFilter;
            ViewData["CurrentFilter"] = searchString;
            addresses.SearchString = searchString;
            addresses.PageIndex = page ?? 1;
            var devices = new AddressViewModelsList(null);
            if (!string.IsNullOrWhiteSpace(searchString))
                devices = new AddressViewModelsList(await addresses.GetDevicesList());
            var a = await addresses.GetObject(id) as GeographicAddressObject ?? new GeographicAddressObject(null);
            await deviceRegistrations.LoadDevices(a);
            var adr = AddressViewModelFactory.Create(a) as GeographicAddressViewModel ?? new GeographicAddressViewModel();
            foreach (var device in adr.RegisteredTelecomAddresses)
                devices.RemoveAll(x => x.Contact == device.Contact);
            ViewBag.Devices = devices;
            return View(adr);
        }
        public async Task<IActionResult> EditTelecom(string id) {
            var address = await addresses.GetObject(id) as TelecomAddressObject;
            await deviceRegistrations.LoadAddresses(address);
            return View(AddressViewModelFactory.Create(address) as TelecomAddressViewModel);
        }
        public async Task<IActionResult> Details(string id) {
            var c = await addresses.GetObject(id);

            switch (c) {
                case WebAddressObject web:
                    return View("DetailsWeb",
                        AddressViewModelFactory.Create(web) as WebPageAddressViewModel);
                case EmailAddressObject email:
                    return View("DetailsEmail",
                        AddressViewModelFactory.Create(email) as EMailAddressViewModel);
                case TelecomAddressObject tel:
                    await deviceRegistrations.LoadAddresses(tel);
                    return View("DetailsTelecom",
                        AddressViewModelFactory.Create(tel) as TelecomAddressViewModel);
                case GeographicAddressObject adr:
                    await deviceRegistrations.LoadDevices(adr);
                    return View("DetailsAddress",
                        AddressViewModelFactory.Create(adr) as GeographicAddressViewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateWeb() {
            return View("CreateWeb", new WebPageAddressViewModel());
        }
        public IActionResult CreateEmail() {
            return View("CreateEmail", new EMailAddressViewModel());
        }
        public IActionResult CreateTelecom() {
            return View("CreateTelecom", new TelecomAddressViewModel());
        }
        public IActionResult CreateAddress() {
            return View("CreateAddress", new GeographicAddressViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult>
            CreateWeb([Bind(webProperties)] WebPageAddressViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateWeb(c.ID, c.Url, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWeb([Bind(webProperties)] WebPageAddressViewModel c) {
            if (!ModelState.IsValid) return View("EditWeb", c);
            var o = await addresses.GetObject(c.ID) as WebAddressObject;
            o.DbRecord.Address = c.Url;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmail(
            [Bind(emailProperties)] EMailAddressViewModel c) {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateEmail(c.ID, c.EmailAddress, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmail([Bind(emailProperties)] EMailAddressViewModel c) {
            if (!ModelState.IsValid) return View("EditEmail", c);
            var o = await addresses.GetObject(c.ID) as EmailAddressObject;
            o.DbRecord.Address = c.EmailAddress;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTelecom(
            [Bind(telecomProperties)] TelecomAddressViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateDevice(c.ID, c.CountryCode, c.AreaCode,
                c.Number, c.Extension, c.NationalDirectDialingPrefix, c.DeviceType, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTelecom(
            [Bind(telecomProperties)] TelecomAddressViewModel c) {
            if (!ModelState.IsValid) return View("EditTelecom", c);
            var o = await addresses.GetObject(c.ID) as TelecomAddressObject;
            o.DbRecord.Address = c.Number;
            o.DbRecord.NationalDirectDialingPrefix = c.NationalDirectDialingPrefix;
            o.DbRecord.CityOrAreaCode = c.AreaCode;
            o.DbRecord.RegionOrStateOrCountryCode = c.CountryCode;
            o.DbRecord.ZipOrPostCodeOrExtension = c.Extension;
            o.DbRecord.Device = c.DeviceType;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAddress(
            [Bind(adrProperties)] GeographicAddressViewModel c)
        {
            if (!ModelState.IsValid) return View(c);
            c.ID = Guid.NewGuid().ToString();
            var o = AddressObjectFactory.CreateAddress(c.ID, c.AddressLine, c.City,
                c.RegionOrState, c.ZipOrPostalCode, c.Country, c.ValidFrom, c.ValidTo);
            await addresses.AddObject(o);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAddress(
            [Bind(adrProperties)] GeographicAddressViewModel c)
        {
            if (!ModelState.IsValid) return View("EditAddress", c);
            var o = await addresses.GetObject(c.ID) as GeographicAddressObject;
            o.DbRecord.Address = c.AddressLine;
            o.DbRecord.CityOrAreaCode = c.City;
            o.DbRecord.RegionOrStateOrCountryCode = c.RegionOrState;
            o.DbRecord.ZipOrPostCodeOrExtension = c.ZipOrPostalCode;
            o.DbRecord.CountryID = c.Country;
            o.DbRecord.ValidFrom = c.ValidFrom ?? DateTime.MinValue;
            o.DbRecord.ValidTo = c.ValidTo ?? DateTime.MaxValue;
            await addresses.UpdateObject(o);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveDevice(string adr, string dev)
        {
            var o = await deviceRegistrations.GetObject(adr, dev);
            await deviceRegistrations.DeleteObject(o);
            return RedirectToAction("EditAddress", new { id = adr });
        }


        #endregion
        public async Task<IActionResult> AddDevice(string adr, string dev)
        {
            var r = new TelecomDeviceRegistrationDbRecord
            {
                AddressID = adr,
                DeviceID = dev
            };
            await deviceRegistrations.AddObject(new TelecomDeviceRegistrationObject(r));
            return RedirectToAction("EditAddress", new { id = adr });
        }
    }
}



