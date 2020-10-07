using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CBCurrencies.Database;

namespace CBCurrencies.ApiMethods
{
    public class GetCurrency
    {
        private readonly ApplicationDBContext Context;

        public GetCurrency(ApplicationDBContext context)
        {
            Context = context;
        }

        public CurrencyViewModel Do (string charcode)
        {
            return Context.Currencies.Where(x => x.CharCode == charcode).Select(x => new CurrencyViewModel
            {
                ID = x.ID,
                NumCode = x.NumCode,
                CharCode = x.CharCode,
                Nominal = x.Nominal,
                Name = x.Name,
                Value = x.Value,
                Previous = x.Previous
            })
                .FirstOrDefault();
        }

        public class CurrencyViewModel
        {
            public string ID { get; set; }
            public int NumCode { get; set; }
            public string CharCode { get; set; }
            public int Nominal { get; set; }
            public string Name { get; set; }
            public double Value { get; set; }
            public double Previous { get; set; }
        }
    }
}
