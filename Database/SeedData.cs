using CBCurrencies.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBCurrencies.Database
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDBContext context)
        {
            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange(
                    new Currency
                    {
                        ID = "R01010",
                        NumCode = 036,
                        CharCode = "AUD",
                        Nominal = 1,
                        Name = "Австралийский доллар",
                        Value = 56.1674,
                        Previous = 56.0725
                    },
                    new Currency
                    {
                        ID = "R01020A",
                        NumCode = 944,
                        CharCode = "AZN",
                        Nominal = 1,
                        Name = "Азербайджанский манат",
                        Value = 46.2107,
                        Previous = 45.9848
                    },
                    new Currency
                    {
                        ID = "R01035",
                        NumCode = 826,
                        CharCode = "GBP",
                        Nominal = 1,
                        Name = "Фунт стерлингов Соединенного королевства",
                        Value = 101.8142,
                        Previous = 101.1603
                    },
                    new Currency
                    {
                        ID = "R01060",
                        NumCode = 051,
                        CharCode = "AMD",
                        Nominal = 100,
                        Name = "Армянских драмов",
                        Value = 16.0425,
                        Previous = 15.9445
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
