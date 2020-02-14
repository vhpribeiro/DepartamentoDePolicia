using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Departamento.De.Policia.Infra.Log.LogsGerais
{
    public interface IRegistrosDeLog
    {
        void RegistrarInformacao(string informacao);
        void RegistrarErro(string erro);
        void RegistrarErro(string erro, string origemDoLog);
        void RegistrarErro(Exception excecao);
        Task<IEnumerable<RegistroDeLog>> ListarPorOrigem(string origem);
        void Excluir(Guid id);
    }
}