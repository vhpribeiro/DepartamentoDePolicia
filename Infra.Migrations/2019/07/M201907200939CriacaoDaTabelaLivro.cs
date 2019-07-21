using System;
using FluentMigrator;

namespace Biblioteca.Infra.Migrations._2019._07
{
    [Migration(201907200939)]
    public class M201907200939CriacaoDaTabelaLivro : Migration
    {
        public override void Up()
        {
            Create.Table("Livro")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Titulo").AsString(Int32.MaxValue).NotNullable()
                .WithColumn("AnoDeLancamento").AsInt32().NotNullable()
                .WithColumn("Categoria").AsString().NotNullable()
                .WithColumn("QuantidadeDisponivel").AsInt32().NotNullable()
                .WithColumn("IdAutor").AsInt32().NotNullable();
            Create.ForeignKey().FromTable("Livro").ForeignColumn("IdAutor").ToTable("Autor").PrimaryColumn("Id");

        }

        public override void Down()
        {
            Delete.ForeignKey("IdAutor");
            Delete.Table("Livro");
        }
    }
}