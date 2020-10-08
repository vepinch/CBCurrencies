using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using CBCurrencies.Database;

namespace CBCurrencies.ExternalApiMethods
{
    public class GetUpdate
    {


        public async Task<string> Do()
        {
            var client = new RestClient("https://www.cbr-xml-daily.ru/daily_json.js");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            List<CurrencyViewModel> values = new List<CurrencyViewModel>();

            if (response.IsSuccessful)
            {
                var skipped = JObject.Parse(response.Content);

                
                foreach (var item in skipped.Last.Children().Children())
                {
                    values.Add(item.First.ToObject<CurrencyViewModel>());
                }
            }



            return JsonConvert.SerializeObject(values, Formatting.Indented);


        }

        public class ContentViewModel
        {
            public DateTime Date { get; set; }
            public DateTime PreviousDate { get; set; }
            public string PreviousURL { get; set; }
            public DateTime Timestamp { get; set; }

            public ValutesViewModel Valutes { get; set; }
        }

        public class ValutesViewModel
        {
            public Dictionary<string, CurrencyViewModel> Valutes { get; set; }
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
