using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FinancasPessoais.Model
{

    public class FinancasModel
    {
        private List<Lancamento> lancamentos = new List<Lancamento>();
        private int proximoId = 1;  

        public void AdicionarLancamento(Lancamento lancamento)
        {
            lancamento.Id = proximoId;
            proximoId++;
            lancamentos.Add(lancamento);

        }

        public List<Lancamento> ListarLancamentos()
        {
            return lancamentos;
        }

        public bool RemoverLancamento(int id)
        {
            Lancamento lancamento = lancamentos.Find(l => l.Id == id);
            if (lancamento != null)
            {
                lancamentos.Remove(lancamento);
                return true;
            }  
            return false;
        }

        public bool AtualizarLancamento(Lancamento atualizado)
        {
            Lancamento lancamento = lancamentos.Find(l => l.Id == atualizado.Id);
            if (lancamento != null)
            {
                lancamento.Descricao = atualizado.Descricao;
                lancamento.Valor = atualizado.Valor;
                lancamento.Tipo = atualizado.Tipo;
                lancamento.Data = atualizado.Data;
                return true;
            }   
            return false;
        }

        public List<Lancamento> FiltrarPorTipo(string tipo)
        {

            return lancamentos.FindAll(l => l.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase));
        }

        public decimal CalcularTotal(string tipo)
        {
            return lancamentos.Where(l => l.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase)).Sum(l => l.Valor);
        }

        public decimal CalcularSaldo()
        {
            decimal totalReceitas = CalcularTotal("Receita");
            decimal totalDespesas = CalcularTotal("Despesa");   
            return CalcularTotal("Receita") - CalcularTotal("Despesa");
        }
    }
}
