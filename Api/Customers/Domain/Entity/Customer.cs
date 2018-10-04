namespace EnterprisePatterns.Api.Customers
{
    public class Customer
    {
        public virtual long Id { get; set; }
        public virtual string OrganizationName { get; set; }
 
        public Customer()
        {
        }
    }
}
