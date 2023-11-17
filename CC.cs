using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Welcome to the Currency Conversion Calculator!");

        var exchangeRates = await GetExchangeRates();

        Console.WriteLine("Available currencies for conversion:");

        foreach (var currency in exchangeRates.Rates.Keys)
        {
            Console.WriteLine(currency);
        }

        Console.Write("Enter the source currency: ");
        string sourceCurrency = Console.ReadLine().ToUpper();

        Console.Write("Enter the target currency: ");
        string targetCurrency = Console.ReadLine().ToUpper();

        Console.Write("Enter the value to be converted: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {

            if (exchangeRates.Rates.ContainsKey(sourceCurrency) && exchangeRates.Rates.ContainsKey(targetCurrency))
            {
                double convertedAmount = ConvertCurrency(amount, sourceCurrency, targetCurrency, exchangeRates);

                Console.WriteLine($"{amount} {sourceCurrency} is equivalent to {convertedAmount:F2} {targetCurrency}");
            }
            else
            {
                Console.WriteLine("Invalid source or target currency.");
            }
        }
        else
        {
            Console.WriteLine("Invalid value.");
        }
    }

    static async Task<ExchangeRates> GetExchangeRates()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetFromJsonAsync<ExchangeRates>("https://api.exchangerate-api.com/v4/latest/USD");
            return response;
        }
    }

    static double ConvertCurrency(double amount, string sourceCurrency, string targetCurrency, ExchangeRates exchangeRates)
    {
        sourceCurrency = sourceCurrency.ToUpper();
        targetCurrency = targetCurrency.ToUpper();

        double amountInUSD = amount / exchangeRates.Rates[sourceCurrency];

        double convertedAmount = amountInUSD * exchangeRates.Rates[targetCurrency];

        convertedAmount = Math.Round(convertedAmount, 2);

        return convertedAmount;
    }
}

public class ExchangeRates
{
    public string BaseCurrency { get; set; }
    public string Date { get; set; }
    public Dictionary<string, double> Rates { get; set; }
}
