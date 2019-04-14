using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Core
{
    public class MyLogDetail
    {
        public MyLogDetail()
        {
            DataHora = DateTime.Now;
        }

        public DateTime DataHora { get; private set; }
        public string Mensagem { get; set; }

        #region ONDE
        public string Aplicacao { get; set; }
        public string CamadaAplicacao { get; set; }
        public string Localizacao { get; set; }
        public string NomeServidor { get; set; }
        #endregion

        #region QUEM
        public decimal? IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public decimal? IdCliente { get; set; }
        public string NomeCliente { get; set; }
        #endregion

        #region INFORMAÇÕES ADICIONAIS
        /// <summary>
        /// Utilzada nos logs de desempenho
        /// </summary>
        public long? DuracaoMilessegundos { get; set; }

        /// <summary>
        /// Exceção do log de erro
        /// </summary>
        public Exception Excecao { get; set; }

        /// <summary>
        /// Id que relaciona o cliente com o servidor
        /// </summary>
        public decimal IdRelacionado { get; set; }

        /// <summary>
        /// Armazena informações adicionais que possam ser
        /// incluídas no log
        /// </summary>
        public Dictionary<string, object> InformacaoAdicional { get; set; }
        #endregion
    }
}
