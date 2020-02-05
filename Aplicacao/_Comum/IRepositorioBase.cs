using System.Collections.Generic;
using DepartamentoDePolicia.Dominio._Comum;

namespace DepartamentoDePolicia.Aplicacao._Comum
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterTodos();
        void Salvar(T entidade);
    }
}