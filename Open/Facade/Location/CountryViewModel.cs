using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Core;
using Open.Facade.Common;
using Open.Facade.Money;
namespace Open.Facade.Location {
    public class CountryViewModel : NamedViewModel {
        private string alpha3Code;
        private string alpha2Code;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Three Character Code")]
        public string Alpha3Code {
            get => getString(ref alpha3Code);
            set => alpha3Code = value;
        }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [RegularExpression(RegularExpressionFor.EnglishCapitalsOnly)]
        [DisplayName("ISO Two Character Code")]
        public string Alpha2Code {
            get => getString(ref alpha2Code);
            set => alpha2Code = value;
        }
        [DisplayName("Currencies in use")]
        public List<CurrencyViewModel> CurrenciesInUse { get; } = new List<CurrencyViewModel>();
    }
}




