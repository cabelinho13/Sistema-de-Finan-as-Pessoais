using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancasPessoais.Model
{
    public class FinancasModel
    {
        // Lista estática para manter os dados em memória
        private static List<Lancamento> lista = new List<Lancamento>();

        public void AdicionarLancamento(Lancamento lancamento)
        {
            lancamento.Id = lista.Count > 0 ? lista.Max(l => l.Id) + 1 : 1; // Garante que o ID será único
            lista.Add(lancamento); // Adiciona o lançamento
        }

        public List<Lancamento> ListarLancamentos()
        {
            return lista.ToList(); // Retorna a lista de lançamentos
        }

        public bool RemoverLancamento(int id)
        {
            var lancamento = lista.FirstOrDefault(l => l.Id == id);
            if (lancamento != null)
            {
                lista.Remove(lancamento); // Remove o lançamento
                return true;
            }
            return false;
        }

        public bool AtualizarLancamento(Lancamento lancamento)
        {
            var lancamentoExistente = lista.FirstOrDefault(l => l.Id == lancamento.Id);
            if (lancamentoExistente != null)
            {
                lancamentoExistente.Descricao = lancamento.Descricao;
                lancamentoExistente.Valor = lancamento.Valor;
                lancamentoExistente.Tipo = lancamento.Tipo;
                lancamentoExistente.Data = lancamento.Data;
                return true;
            }
            return false;
        }

        public List<Lancamento> FiltrarPorTipo(string tipo)
        {
            return lista.Where(l => l.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public decimal CalcularTotal(string tipo)
        {
            return lista.Where(l => l.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase)).Sum(l => l.Valor);
        }

        public decimal CalcularSaldo()
        {
            decimal totalReceitas = CalcularTotal("Receita");
            decimal totalDespesas = CalcularTotal("Despesa");
            return totalReceitas - totalDespesas;
        }
    }
}
