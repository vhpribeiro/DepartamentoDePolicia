using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002150944)]
    public class M202002150944CriacaoDaTabelaViatura : Migration
    {
        public override void Up()
        {
            Create.Table("Viatura")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("SireneEstaAtiva").AsBoolean().WithDefaultValue(false).Nullable()
                .WithColumn("Ano").AsInt32().Nullable()
                .WithColumn("QuantidadeDeGasolinaEmLitros").AsInt32().Nullable()
                .WithColumn("QuantidadeMaximaDoTanqueEmlitros").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Viatura");
        }
    }
}