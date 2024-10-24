using Practice.API.ServiceInterfaces;
namespace Practice.API.Services
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> Customers { get; set; }
        public CustomerService()
        {
            Customers = new List<Customer>
            {
                new Customer{Id = 1, FirstName = "Nikita" , LastName = "Belokrinitskiy", Balance = 25.65},
                new Customer{Id = 2, FirstName = "Vlad" , LastName = "Drebich", Balance = 11.34},
                new Customer{Id = 3, FirstName = "Oleg" , LastName = "Brevich", Balance = 7.7},
                new Customer{Id = 4, FirstName = "Natalia" , LastName = "Melnik", Balance = 34.11}
            };
        }
        public List<Customer> GetCustomers()
        {
            return Customers;
        }
        public Customer? GetCustomerById(int id)
        {
            Customer? customer = Customers.FirstOrDefault(unit => unit.Id == id);
            return customer;
        }
        public Customer AddCustomer(Customer customer)
        {
            Customer added_customer = customer;
            if (Customers.Any(unit => unit.Id == added_customer.Id))
                throw new Exception();
            Customers.Add(added_customer);
            return added_customer;
        }
        public bool DeleteCustomerById(int id)
        {
            Customer? customer_for_deletion = Customers.FirstOrDefault(unit => unit.Id == id);
            if(customer_for_deletion != null)
                return Customers.Remove(customer_for_deletion);
            return false;
        }
        public bool EditCustomerById(int id, Customer customer)
        {
            try
            {
                int index = Customers.IndexOf(Customers.First(unit => unit.Id == id));
                Customers[index] = customer;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
