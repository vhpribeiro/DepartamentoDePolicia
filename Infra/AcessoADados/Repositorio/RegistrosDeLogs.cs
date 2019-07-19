using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Biblioteca.Infra.Log.LogsGerais;
using Dapper;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Biblioteca.Infra.AcessoADados.Repositorio
{
    public class RegistrosDeLogs : IRegistrosDeLog
    {
        private Logger _logger;
        private readonly string _stringDeConexaoDoBancoDeDados;

        public RegistrosDeLogs(string stringDeConexaoDoBancoDeDados)
        {
            _stringDeConexaoDoBancoDeDados = stringDeConexaoDoBancoDeDados;
            const string origemDoRegistro = "RegistroDeLog";
            var configuracaoDeLogging = new LoggingConfiguration();
            var configuracoesDeBancoDeDados = new DatabaseTarget
            {
                Name = origemDoRegistro,
                ConnectionString = stringDeConexaoDoBancoDeDados,
                CommandText = "INSERT INTO RegistroDeLog (Id, Data, ThreadId, Logger, Level, Exception)" +
                              "VALUES (NEWID(), GETDATE(), @threadId, @logger, @level, @exception)",
                Parameters =
                {
                    new DatabaseParameterInfo { Name = "@threadId", Layout = "${threadid}" },
                    new DatabaseParameterInfo { Name = "@level", Layout = "${level}" },
                    new DatabaseParameterInfo { Name = "@logger", Layout = "${logger}" },
                    new DatabaseParameterInfo { Name = "@exception", Layout = "${message}" },
                },
            };

            configuracaoDeLogging.AddTarget("bancoDeDados", configuracoesDeBancoDeDados);

            var regraDeLog = new LoggingRule("*", LogLevel.Trace, LogLevel.Off, configuracoesDeBancoDeDados);
            configuracaoDeLogging.LoggingRules.Add(regraDeLog);

            LogManager.Configuration = configuracaoDeLogging;

            _logger = LogManager.GetLogger(origemDoRegistro);
        }

        public void RegistrarInformacao(string informacao)
        {
            _logger.Info(informacao);
        }

        public void RegistrarErro(string erro, string origemDoLog)
        {
            _logger = LogManager.GetLogger(origemDoLog);
            _logger.Error(erro);
        }

        public void RegistrarErro(string erro)
        {
            _logger.Error(erro);
        }

        public void RegistrarErro(Exception excecao)
        {
            _logger.Error(excecao);
        }

        public async Task<IEnumerable<RegistroDeLog>> ListarPorOrigem(string origem)
        {
            IEnumerable<RegistroDeLog> registrosDeLog;
            using (var conexao = new SqlConnection(_stringDeConexaoDoBancoDeDados))
            {
                await conexao.OpenAsync();
                var query = $"SELECT * FROM RegistroDeLog WHERE Logger = \'{origem}\' order by Data desc";
                registrosDeLog = await conexao.QueryAsync<RegistroDeLog>(query);
            }

            return registrosDeLog;
        }

        public void Excluir(Guid id)
        {
            using (var conexao = new SqlConnection(_stringDeConexaoDoBancoDeDados))
            {
                var query = $"DELETE FROM RegistroDeLog WHERE Id = {id}";
                conexao.Execute(query);
            }
        }
    }
}