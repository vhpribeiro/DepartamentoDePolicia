using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002151029)]
    public class M202002151029CriacaoDaTabelaDepartamentoDePoliciais : Migration
    {
        public override void Up()
        {
            Create.Table("DepartamentoDePoliciais")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("AnoDeCriacao").AsInt32().Nullable()
                .WithColumn("NumeroDeRegistro").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("DepartamentoDePoliciais");
        }
    }
}