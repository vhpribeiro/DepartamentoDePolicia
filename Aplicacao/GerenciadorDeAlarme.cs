using System;

namespace Departamento.De.Policia.Aplicacao
{
    public class GerenciadorDeAlarme
    {
        public delegate void DisparouAlarmeHandler(object origem, EventArgs argumentos);

        public event DisparouAlarmeHandler DisparouAlarme;

        public void AcionarAlarme()
        {
            NoDisparoDoAlarme();
        }

        protected virtual void NoDisparoDoAlarme()
        {
            DisparouAlarme?.Invoke(this, EventArgs.Empty);
        }
    }
}