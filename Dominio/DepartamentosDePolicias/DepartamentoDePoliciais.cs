using System;
using Departamento.De.Policia.Dominio._Comum;
using Departamento.De.Policia.Dominio.Policiais;
using Departamento.De.Policia.Dominio.Viaturas;
using System.Collections.Generic;
using Departamento.De.Policia.Dominio._Helper;

namespace Departamento.De.Policia.Dominio.DepartamentosDePolicias
{
    public class 
        DepartamentoDePoliciais : Entidade<DepartamentoDePoliciais>
    {
        private readonly IList<Policial> _policiais = new List<Policial>();
        public virtual IEnumerable<Policial> Policiais => _policiais;
        private readonly IList<Viatura> _viaturas = new List<Viatura>();
        public virtual IEnumerable<Viatura> Viaturas => _viaturas;
        public virtual int AnoDeCriacao { get; protected set; }
        public virtual int NumeroDeRegistro { get; protected set; }

        protected DepartamentoDePoliciais() { }

        public DepartamentoDePoliciais(int anoDeCriacao, int numeroDeRegistro)
        {
            ValidarDados(anoDeCriacao, numeroDeRegistro);

            AnoDeCriacao = anoDeCriacao;
            NumeroDeRegistro = numeroDeRegistro;
        }

        public virtual void ContratarPolicial(Policial policial)
        {
            _policiais.Add(policial);
        }

        public virtual void ComprarNovaViatura(Viatura viatura)
        {
            _viaturas.Add(viatura);
        }

        public virtual void DisparouAlarmeHandler(object origm, EventArgs argumentos)
        {
            foreach (var policial in Policiais) 
                policial.FazerRonda();
        }

        private static void ValidarDados(int anoDeCriacao, int numeroDeRegistro)
        {
            Validacoes<DepartamentoDePoliciais>.Criar()
                .Quando(anoDeCriacao < 1960, "É necessário informar um ano válido de criação do departamento.")
                .Quando(numeroDeRegistro <= 0, "É necessário informar um número de registro válido para o departamento.")
                .DispararSeHouverErros();
        }
    }
}