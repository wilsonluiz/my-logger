using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace MyLogger.Core
{
    public static class MyLogger
    {
        private static readonly ILogger Despempenho;
        private static readonly ILogger Utilizacao;
        private static readonly ILogger Problema;
        private static readonly ILogger Dignostico;

        static MyLogger()
        {
            Despempenho = new LoggerConfiguration()
                .WriteTo.File("D:\\dev\\logs\\desempenho.log")
                .CreateLogger();

            Utilizacao = new LoggerConfiguration()
                .WriteTo.File("D:\\dev\\logs\\utilzacao.log")
                .CreateLogger();

            Problema = new LoggerConfiguration()
                .WriteTo.File("D:\\dev\\logs\\problema.log")
                .CreateLogger();

            Dignostico = new LoggerConfiguration()
                .WriteTo.File("D:\\dev\\logs\\diagnostico.log")
                .CreateLogger();
            
        }

        public static void LogDesempenho(MyLogDetail desempenho)
        {
            Despempenho.Write(LogEventLevel.Information, "{@MyLogDetail}", desempenho);
        }

        public static void LogUtilizacao(MyLogDetail utilizacao)
        {
            Utilizacao.Write(LogEventLevel.Information, "{@MyLogDetail}", utilizacao);
        }

        public static void LogErro(MyLogDetail erro)
        {
            Problema.Write(LogEventLevel.Information, "{@MyLogDetail}", erro);
        }

        public static void LogDiagnostico(MyLogDetail diagnostico)
        {

            var deveLogarDiagsnostico = Convert.ToBoolean(ConfigurationManager.AppSettings["HabilitarDiagnostico"]);
            if (!deveLogarDiagsnostico)
                return;

            Problema.Write(LogEventLevel.Information, "{@MyLogDetail}", diagnostico);
        }
    }


}
