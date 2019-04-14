using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLogger.Core;

namespace MyLogger.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var detalheLog = ObterDetalheDoLog("inciando a aplicacao", null);
            Core.MyLogger.LogDiagnostico(detalheLog);

            var ratreador = new RastreadorDesempenho("MyLogger.Console_Execution", null,
                detalheLog.NomeUsuario, detalheLog.Localizacao, detalheLog.Aplicacao,
                detalheLog.CamadaAplicacao);

            try
            {
                var excecao = new Exception("Algo de ruim aconteceu!");
                excecao.Data.Add("input param", "nada para ver aqui");
                throw excecao;
            }
            catch (Exception ex)
            {
                detalheLog = ObterDetalheDoLog("", ex);
                Core.MyLogger.LogErro(detalheLog);
            }

            detalheLog = ObterDetalheDoLog("utilizado mylloger.console", null);
            Core.MyLogger.LogUtilizacao(detalheLog);

            detalheLog = ObterDetalheDoLog("parando a aplicacao", null);
            Core.MyLogger.LogDiagnostico(detalheLog);

            ratreador.Stop();
        }

        private static MyLogDetail ObterDetalheDoLog(string mensagem, Exception excecao)
        {
            return new MyLogDetail()
            {
                Aplicacao = "MyLogger",
                Localizacao = "MyLogger.Console",
                CamadaAplicacao = "Job",
                NomeUsuario = Environment.UserName,
                NomeServidor = Environment.MachineName,
                Mensagem = mensagem,
                Excecao = excecao
            };
        }
    }
}
