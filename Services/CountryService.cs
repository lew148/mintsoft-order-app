using System.Collections.Generic;
using System.Linq;
using mintsoft_order_app.Models;
using Newtonsoft.Json;

namespace mintsoft_order_app.Services
{
    public interface ICountryService
    {
        IEnumerable<string> GetAllCountries();
    }

    public class CountryService : ICountryService
    {
        public IEnumerable<string> GetAllCountries()
        {
            return JsonConvert.DeserializeObject<IEnumerable<CountryModel>>(
                    ApiHelper.GetCountriesFromMintSoftApi())
                .Select(c => c.Name);
        }
    }
}