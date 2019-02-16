using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesX.Exercises.Models;

namespace WooliesX.Exercises
{
    public class WooliesXService
    {
        public HttpClient Client { get; }

        public string Token{get; set;}
        public WooliesXService(HttpClient client)
        {            
            client.BaseAddress = new Uri("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/");
            Client = client;            
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await Client.GetAsync($"products?token={Token}");
            response.EnsureSuccessStatusCode();           
            var result = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            return result;
        }

        public async Task<IEnumerable<ShopperHistory>> GetShopperHistory()
        {
            var response = await Client.GetAsync($"shopperHistory/?token={Token}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<IEnumerable<ShopperHistory>>();
            return result;
        }

        public async Task<IEnumerable<ShopperHistory>> PostTrolleyCalculator(object data)
        {
            var response = await Client.GetAsync($"trolleyCalculator/?token={Token}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<IEnumerable<ShopperHistory>>();
            return result;
        }
    }
}