using FluentNHibernate.Mapping;

namespace EnterprisePatterns.Api.Projects.Infrastructure.Persistence.NHibernate.Mapping
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id).Column("project_id");
            Map(x => x.ProjectName).Column("project_name");
            Map(x => x.Budget).Column("budget");
            Map(x => x.CurrencyId).Column("currency_id");
            References(x => x.Customer, "customer_id");
        }
    }
}
