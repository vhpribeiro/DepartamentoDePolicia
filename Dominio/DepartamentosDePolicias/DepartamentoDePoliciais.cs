using System.Collections.Generic;
using Departamento.De.Policia.Dominio._Comum;
using Departamento.De.Policia.Dominio.Policiais;
using Departamento.De.Policia.Dominio.Viaturas;

namespace Departamento.De.Policia.Dominio.DepartamentosDePolicia
{
    public class DepartamentoDePoliciais : Entidade<DepartamentoDePoliciais>
    {
        private static IList<Policial> _policiais = new List<Policial>();
        public IEnumerable<Policial> Policiais = _policiais;
        private static IList<Viatura> _viaturas = new List<Viatura>();
        public IEnumerable<Viatura> Viaturas = _viaturas;
        public int AnoDeCriacao { get; protected set; }
        public int NumeroDeRegistro { get; protected set; }

        public DepartamentoDePoliciais(int anoDeCriacao, int numeroDeRegistro)
        {
            AnoDeCriacao = anoDeCriacao;
            NumeroDeRegistro = numeroDeRegistro;
        }

        public void ContratarPolicial(Policial policial)
        {
            _policiais.Add(policial);
        }

        public void ComprarNovaViatura(Viatura viatura)
        {
            _viaturas.Add(viatura);
        }
    }
}