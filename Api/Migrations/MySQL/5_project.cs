using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(5)]
    public class ProjectTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("5_project.sql");
        }

        public override void Down()
        {
        }
    }
}
