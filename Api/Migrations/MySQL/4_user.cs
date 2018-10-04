using FluentMigrator;

namespace EnterprisePatterns.Api.Migrations.MySQL
{
    [Migration(4)]
    public class UserTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("4_user.sql");
        }

        public override void Down()
        {
        }
    }
}
