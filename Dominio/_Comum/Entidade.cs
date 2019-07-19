namespace Biblioteca.Dominio._Comum
{
    public abstract class Entidade<T> where T : Entidade<T>
    {
        public virtual int Id { get; protected set; }
        public virtual bool EhTransiente => Id == 0;

        public override bool Equals(object obj)
        {
            var outraEntidade = obj as T;
            if (outraEntidade == null) return false;

            if (EhTransiente && outraEntidade.EhTransiente)
                return ReferenceEquals(this, outraEntidade);

            return Id == outraEntidade.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Entidade<T> e1, Entidade<T> e2)
        {
            return Equals(e1, e2);
        }

        public static bool operator !=(Entidade<T> e1, Entidade<T> e2)
        {
            return !Equals(e1, e2);
        }
    }
}