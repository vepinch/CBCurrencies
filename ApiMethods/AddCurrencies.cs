using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CBCurrencies.Database;
using Newtonsoft.Json;
using CBCurrencies.Models;

namespace CBCurrencies.ApiMethods
{
    public class AddCurrencies
    {
        private readonly ApplicationDBContext Context;

        public AddCurrencies(ApplicationDBContext context)
        {
            Context = context;
        }


        public string Do(string request)
        {
            var currencies = JsonConvert.DeserializeObject<List<Currency>>(request);

            var DbKeys = Context.Currencies.Select(p => p.CharCode).ToList();
            var newCurrencies = currencies.Where(p => !DbKeys.Contains(p.CharCode)).ToList();

            Context.Currencies.AddRange(newCurrencies);
            Context.SaveChanges();

            return JsonConvert.SerializeObject(currencies.Except(newCurrencies));
        }

        
    }
}
