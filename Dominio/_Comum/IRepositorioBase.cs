using System.Collections.Generic;

namespace Biblioteca.Dominio._Comum
{
    public interface IRepositorioBase<T> where T : Entidade<T>
    {
        T ObterPor(int id);
        IEnumerable<T> ObterPor(ISpecification<T> specification);
        IEnumerable<T> ObterTodos();
        int ContarPor(ISpecification<T> specification);
        void Salvar(T entidade);
    }
}