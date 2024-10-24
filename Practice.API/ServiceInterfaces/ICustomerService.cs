namespace Practice.API.ServiceInterfaces
{
    public interface ICustomerService
    {
        public List<Customer> Customers { get; set; }
        public List<Customer> GetCustomers();
        public Customer? GetCustomerById(int id);
        public Customer AddCustomer(Customer customer);
        public bool DeleteCustomerById(int id);
        public bool EditCustomerById(int id, Customer customer);
    }
}
