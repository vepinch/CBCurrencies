using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CBCurrencies.Database;
using CBCurrencies.ApiMethods;
using CBCurrencies.ExternalApiMethods;


namespace CBCurrencies.Controllers
{
    [ApiController]
    public class CurrenciesController
    {
        private readonly ApplicationDBContext Context;

        public CurrenciesController(ApplicationDBContext context)
        {
            Context = context;
        }

        [HttpGet("currency/{request}")]
        public string GetCurrency(string request)
        {
            var currency = new GetCurrency(Context).Do(request.ToUpper());
            if (currency == null)
                return "Currency not found";
            return JsonConvert.SerializeObject(currency);
        }

        [HttpGet("currencies")]
        public string GetCurrencies()
        {
            return JsonConvert.SerializeObject(new GetCurrencies(Context).Do());
        }

        [HttpGet("getUpdate")]
        public async Task<string> GetUpdate()
        {


            var recivedData = await new GetUpdate().Do();
            var presentedData = new AddCurrencies(Context).Do(recivedData);
            new UpdateCurrencies(Context).Do(presentedData);

            return "Обновление завершено, введите /currencies для просмотра";
        }




    }

    
}
