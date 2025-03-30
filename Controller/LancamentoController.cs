using FinancasPessoais.Model;
using System.Collections.Generic;

namespace FinancasPessoais.Controller
{
    public class LancamentoController
    {
        // Usando a instância estática para persistir os dados em memória enquanto a aplicação está aberta
        private static FinancasModel financasModel = new FinancasModel();

        public void AdicionarLancamento(Lancamento lancamento)
        {
            financasModel.AdicionarLancamento(lancamento); // Adiciona o lançamento ao modelo
        }

        public List<Lancamento> ListarLancamentos()
        {
            return financasModel.ListarLancamentos(); // Retorna todos os lançamentos
        }

        public bool RemoverLancamento(int id)
        {
            return financasModel.RemoverLancamento(id); // Remove o lançamento com o id correspondente
        }

        public bool AtualizarLancamento(Lancamento atualizado)
        {
            return financasModel.AtualizarLancamento(atualizado); // Atualiza os dados do lançamento no modelo
        }

        public List<Lancamento> FiltrarPorTipo(string tipo)
        {
            return financasModel.FiltrarPorTipo(tipo); // Filtra os lançamentos por tipo (Receita/Despesa)
        }

        public decimal CalcularTotal(string tipo)
        {
            return financasModel.CalcularTotal(tipo); // Calcula o total de um tipo (Receita/Despesa)
        }

        public decimal CalcularSaldo()
        {
            return financasModel.CalcularSaldo(); // Calcula o saldo geral
        }
    }
}
