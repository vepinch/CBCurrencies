using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CBCurrencies.Database;

namespace CBCurrencies.ApiMethods
{
    public class GetCurrencies
    {
        private readonly ApplicationDBContext Context;

        public GetCurrencies(ApplicationDBContext context)
        {
            Context = context;
        }

        public Response Do()
        {

            //Приводим Currency из БД к CurrencyViewModel
            var valutes = Context.Currencies.ToList().Select(x => new CurrencyViewModel
            {
                ID = x.ID,
                NumCode = x.NumCode,
                CharCode = x.CharCode,
                Nominal = x.Nominal,
                Name = x.Name,
                Value = x.Value,
                Previous = x.Previous,
            });

            //Создаем ответ нужной структуры
            var response = new Response
            {
                Timestamp = DateTime.UtcNow,
                Valute = valutes.ToDictionary(p => p.CharCode),
            };

            return response;
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

        public class Response
        {
            public DateTime Timestamp { get; set; }
            public Dictionary<string, CurrencyViewModel> Valute { get; set; }


        }
    }
}
