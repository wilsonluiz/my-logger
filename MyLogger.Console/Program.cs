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
