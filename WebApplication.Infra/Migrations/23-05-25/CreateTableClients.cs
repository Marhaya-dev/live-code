using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Infra.Migrations
{
    [Migration(1685049297)]
    public class CreateTableClients : Migration
    {
        private readonly string tableName = "clients";

        private readonly string id = "id";
        private readonly string name = "name";
        private readonly string email = "email";
        private readonly string createdAt = "created_at";
        private readonly string updatedAt = "updated_at";

        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(id)
                        .AsInt32()
                        .PrimaryKey()
                        .Identity()
                    .WithColumn(name)
                        .AsString(50)
                        .NotNullable()
                    .WithColumn(email)
                        .AsString(255)
                        .NotNullable()
                    .WithColumn(createdAt)
                        .AsDateTime()
                        .WithDefault(SystemMethods.CurrentDateTime)
                    .WithColumn(updatedAt)
                        .AsDateTime()
                        .Nullable()
                ;
            }
        }

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            }
        }
    }
}
