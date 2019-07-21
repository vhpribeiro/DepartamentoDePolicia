using System.Collections.Generic;

namespace Biblioteca.Dominio._Comum
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterTodos();
        void Salvar(T entidade);
    }
}