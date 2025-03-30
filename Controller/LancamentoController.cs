using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancasPessoais.Model;



namespace FinancasPessoais.Controller
{
    public class LancamentoController
    {
        private FinancasModel financasModel = new FinancasModel();
        public void AdicionarLancamento(Lancamento lancamento)
        {
            financasModel.AdicionarLancamento(lancamento);
        }
        public List<Lancamento> ListarLancamentos()
        {
            return financasModel.ListarLancamentos();
        }
        public bool RemoverLancamento(int id)
        {
            return financasModel.RemoverLancamento(id);
        }
        public bool AtualizarLancamento(Lancamento atualizado)
        {
            return financasModel.AtualizarLancamento(atualizado);
        }
        public List<Lancamento> FiltrarPorTipo(string tipo)
        {
            return financasModel.FiltrarPorTipo(tipo);
        }   

        public decimal CalcularTotal(string tipo)
        {
            return financasModel.CalcularTotal(tipo);
        }

        public decimal CalcularSaldo()
        {
            return financasModel.CalcularSaldo();
        }   
    }
}
