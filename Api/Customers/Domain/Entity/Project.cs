using EnterprisePatterns.Api.Customers;
namespace EnterprisePatterns.Api.Projects
{
    public class Project
    {
        public virtual long Id { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual decimal Budget { get; set; }
        public virtual long CurrencyId { get; set; }
        public virtual Customer Customer { get; set; }

        public Project()
        {
        }
    }
}
