using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002151033)]
    public class M202002151033AdicionandoIdDoDepartamentoNaViatura : Migration
    {
        public override void Up()
        {
            Alter.Table("Viatura").AddColumn("IdDepartamentoDePoliciais").AsInt32().Nullable();

            Create.ForeignKey().FromTable("Viatura").ForeignColumn("IdDepartamentoDePoliciais")
                .ToTable("DepartamentoDePoliciais").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Column("IdDepartamentoDePoliciais").FromTable("Viatura");
        }
    }
}