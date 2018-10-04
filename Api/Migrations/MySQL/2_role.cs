using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(2)]
    public class RoleTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("2_role.sql");
        }

        public override void Down()
        {
        }
    }
}
