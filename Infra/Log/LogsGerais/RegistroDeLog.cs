using System;

namespace DepartamentoDePolicia.Infra.Log.LogsGerais
{
    public class RegistroDeLog
    {
        public Guid Id;
        public DateTime Data;
        public int ThreadId;
        public string Logger;
        public string Level;
        public string Exception;
    }
}