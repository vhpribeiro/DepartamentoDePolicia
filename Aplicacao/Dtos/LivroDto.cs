namespace Biblioteca.Aplicacao.Dtos
{
    public class LivroDto
    {
        public string Titulo { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int AnoDeLancamento { get; set; }
        public CategoriaDeLivrosDto Categoria { get; set; }
        public AutorDto Autor { get; set; }
    }
}