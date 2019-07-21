using System.Collections.Generic;
using Biblioteca.Dominio._Comum;

namespace Biblioteca.Aplicacao._Comum
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterTodos();
        void Salvar(T entidade);
    }
}