using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Core
{
    public class RastreadorDesempenho
    {
        private readonly Stopwatch _sw;
        private readonly MyLogDetail _infoParaLogar;

        public RastreadorDesempenho(string nome, decimal? idUsuario, string nomeUsuario,
            string localizacao, string aplicacao, string camadaAplicacao)
        {
            _sw = Stopwatch.StartNew();
            _infoParaLogar = new MyLogDetail()
            {
                Mensagem = nome,
                IdUsuario = idUsuario,
                NomeUsuario = nomeUsuario,
                Aplicacao = aplicacao,
                CamadaAplicacao = camadaAplicacao,
                Localizacao = localizacao,
                NomeServidor = Environment.MachineName
            };

            var inicio = DateTime.Now;
            _infoParaLogar.InformacaoAdicional = new Dictionary<string, object>()
            {
                {"Iniciou", inicio.ToString(CultureInfo.InvariantCulture)}
            };
        }

        public RastreadorDesempenho(string nome, decimal? idUsuario, string nomeUsuario,
            string localizacao, string aplicacao, string camadaAplicacao,
            Dictionary<string, object> parametrosDesempenho)
            : this(nome, idUsuario, nomeUsuario, localizacao, aplicacao, camadaAplicacao)
        {
            foreach (var parametro in parametrosDesempenho)
            {
                _infoParaLogar.InformacaoAdicional.Add("input-" + parametro.Key, parametro.Value);
            }
        }

        public void Stop()
        {
            _sw.Stop();
            _infoParaLogar.DuracaoMilessegundos = _sw.ElapsedMilliseconds;
            MyLogger.LogDesempenho(_infoParaLogar);
        }
    }
}
