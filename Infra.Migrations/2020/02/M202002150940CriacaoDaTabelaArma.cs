using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002150940)]
    public class M202002150940CriacaoDaTabelaArma : Migration
    {
        public override void Up()
        {
            Create.Table("Arma")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Tipo").AsString().NotNullable()
                .WithColumn("QuantidadeDeBalasNoPente").AsInt32().NotNullable()
                .WithColumn("QuantidadeDeBalasRestantesNoPente").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Arma");
        }
    }
}