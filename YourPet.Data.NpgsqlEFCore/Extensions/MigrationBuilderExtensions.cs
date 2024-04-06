using Microsoft.EntityFrameworkCore.Migrations;

namespace YourPet.Data.NpgsqlEFCore.Utility;

public static class MigrationBuilderExtensions
{
    public static void SqlFromResources(this MigrationBuilder migrationBuilder, string prefix)
    {
        var sqlScripts = EmbeddedResourceUtility.LoadResourceStringsByPrefix("Database." + prefix);

        foreach (var sqlScript in sqlScripts)
        {
            migrationBuilder.Sql(sqlScript);
        }
    }
}