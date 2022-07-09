using CustomerMicroservice.DB;
using CustomerMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMicroservice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        Uri baseAddress = new Uri("https://localhost:44379/api/Account");
        HttpClient client;
        CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _context = context;
        }
        public CustomerAccountDetails createCustomer(CustomerDetails customer)
        {
            _context.customers.Add(customer);
            string data = JsonConvert.SerializeObject(new{ customerId = customer.CustomerId});
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            string token = TokenInfo.StringToken;
            client.DefaultRequestHeaders.Add("Authorization", token);
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/createAccount/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string data1 = response.Content.ReadAsStringAsync().Result;
                CustomerAccountDetails details = JsonConvert.DeserializeObject<CustomerAccountDetails>(data1);
                return details;
            }
            return null;
        }

        public CustomerDetails getCustomerDetails(string CustomerId)
        {
            return _context.customers.Where(c => c.CustomerId == CustomerId).FirstOrDefault();          
        }
    }
}
