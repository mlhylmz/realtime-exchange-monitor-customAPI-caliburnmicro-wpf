using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace ExchangeInstantAPI.Models;

public class ApiData
{
    public async Task<ExchangeModel[]?> GetExchange()
    {
        try
        {
            // API Connection
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:3000/api/data");
            var result = await response.Content.ReadAsStringAsync();

            // JSON AYIRMA
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultJson = JsonSerializer.Deserialize<ExchangeModel[]>(result, options);

            return resultJson;
        }
        catch (Exception e)
        {
            MessageBox.Show("Error! API Connection Failed!");
            Console.WriteLine(e);
            throw;
        }
    }
}