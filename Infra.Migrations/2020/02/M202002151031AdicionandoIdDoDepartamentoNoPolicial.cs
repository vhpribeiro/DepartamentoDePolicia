using FluentMigrator;

namespace DepartamentoDePolicia.Infra.Migrations._2020._02
{
    [Migration(202002151031)]
    public class M202002151031AdicionandoIdDoDepartamentoNoPolicial : Migration
    {
        public override void Up()
        {
            Alter.Table("Policial").AddColumn("IdDepartamentoDePoliciais").AsInt32().Nullable();

            Create.ForeignKey().FromTable("Policial").ForeignColumn("IdDepartamentoDePoliciais")
                .ToTable("DepartamentoDePoliciais").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Column("IdDepartamentoDePoliciais").FromTable("Policial");
        }
    }
}