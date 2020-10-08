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
    public class UpdateCurrencies
    {
        private readonly ApplicationDBContext Context;

        public UpdateCurrencies(ApplicationDBContext context)
        {
            Context = context;
        }


        public void Do(string request)
        {
            var currencies = JsonConvert.DeserializeObject<List<Currency>>(request);

            var DbKeys = currencies.Select(p => p.ID).ToList();
            var updatingCurrencies = Context.Currencies.Where(p => DbKeys.Contains(p.ID)).ToList();

            
            updatingCurrencies = currencies;



            Context.SaveChanges();
        }
    }
}
