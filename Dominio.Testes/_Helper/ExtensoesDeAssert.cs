using System.Text;
using Biblioteca.Dominio._Comum;
using Xunit;

namespace Biblioteca.Testes._Helper
{
    public static class ExtensoesDeAssert
    {
        public static ExcecaoDeDominio ComMensagem(this ExcecaoDeDominio exception, string message)
        {
            if (!exception.PossuiErroComAMensagemIgualA(message))
            {
                var mensagemDeFalha = MontarMensagemDeFalha(exception, message);
                Assert.False(true, mensagemDeFalha.ToString());
            }

            return exception;
        }

        private static StringBuilder MontarMensagemDeFalha(ExcecaoDeDominio exception, string message)
        {
            var mensagens = exception.Mensagens();
            var mensagemDeFalha = new StringBuilder();

            mensagemDeFalha.AppendLine($"Não disparou exceção com a mensagem: {message}");

            foreach (var mensagem in mensagens)
                mensagemDeFalha.AppendLine($"E exibiu a seguinte mensagem: {mensagem}");

            return mensagemDeFalha;
        }
    }
}