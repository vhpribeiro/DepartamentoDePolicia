using System.Collections.Generic;
using Departamento.De.Policia.Dominio._Comum;
using DepartamentoDePolicia.Dominio._Comum;

namespace Departamento.De.Policia.Aplicacao._Comum
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterTodos();
        void Salvar(T entidade);
    }
}