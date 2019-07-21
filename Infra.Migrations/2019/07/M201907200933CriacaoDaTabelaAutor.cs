using System;
using FluentMigrator;

namespace Biblioteca.Infra.Migrations._2019._07
{
    [Migration(201907200933)]
    public class M201907200933CriacaoDaTabelaAutor : Migration
    {
        public override void Up()
        {
            Create.Table("Autor")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Nome").AsString(Int32.MaxValue).NotNullable()
                .WithColumn("QuantidadeDeLivrosVendidos").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Autor");
        }
    }
}