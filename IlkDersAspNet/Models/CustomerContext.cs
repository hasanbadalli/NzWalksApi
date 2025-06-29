using System.Collections.Generic;

namespace CustomerApp.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer { FirstName = "Sardar", LastName = "Eliyev", Age = 56 },
            new Customer { FirstName = "Vardar", LastName = "Eli", Age = 30 }
        };
    }
}
