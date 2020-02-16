using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002150947)]
    public class M202002150947CriacaoDaTabelaPolicial : Migration
    {
        public override void Up()
        {
            Create.Table("Policial")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("NumeroDoDistintivo").AsString().NotNullable()
                .WithColumn("AnosNaAcademia").AsInt32().Nullable()
                .WithColumn("Idade").AsInt32().Nullable()
                .WithColumn("Experiencia").AsInt32().Nullable()
                .WithColumn("Nivel").AsInt32().Nullable()
                .WithColumn("IdArma").AsInt32().Nullable()
                .WithColumn("IdViatura").AsInt32().Nullable();

            Create.ForeignKey().FromTable("Policial").ForeignColumn("IdArma").ToTable("Arma").PrimaryColumn("Id");
            Create.ForeignKey().FromTable("Policial").ForeignColumn("IdViatura").ToTable("Viatura").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Policial");
        }
    }
}