using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinancasPessoais.Controller;
using FinancasPessoais.Model;
using System.Linq;

namespace FinancasPessoais
{
    public partial class Form1 : Form
    {

        private int? idSelecionado = null;

        private bool GerouGrafico = false;  

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartResumo.Visible = false;
            btnFecharGrafico.Visible = false;
        }

        private LancamentoController lancamentoController = new LancamentoController();
        
        private void AtualizarGrid()
        {
            dgvLancamentos.DataSource = null;
            dgvLancamentos.DataSource = lancamentoController.ListarLancamentos();
        }

        private void AtualizarChart()
        {
            chartResumo.Series.Clear();
            Series series = chartResumo.Series.Add("Lançamentos");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.Label = "#VALX\n#VAL{C}\n#PERCENT";
            series.LegendText = "#VALX";

            decimal totalReceita = 0;
            decimal totalDespesa = 0;

            foreach (DataGridViewRow row in dgvLancamentos.Rows)
            {
                if (row.Cells["Tipo"].Value?.ToString().Equals("Receita", StringComparison.OrdinalIgnoreCase) == true)
                    totalReceita += Convert.ToDecimal(row.Cells["Valor"].Value);

                if (row.Cells["Tipo"].Value?.ToString().Equals("Despesa", StringComparison.OrdinalIgnoreCase) == true)
                    totalDespesa += Convert.ToDecimal(row.Cells["Valor"].Value);
            }

            if (totalReceita > 0)
            {
                int index = series.Points.AddXY("Receita", totalReceita);
                series.Points[index].Color = Color.Green;
            }

            if (totalDespesa > 0)
            {
                int index = series.Points.AddXY("Despesa", totalDespesa);
                series.Points[index].Color = Color.Red;
            }

            lblTotalReceitas.Text = $"Total de Receitas: R$ {totalReceita:N2}";
            lblTotalDespesas.Text = $"Total de Despesas: R$ {totalDespesa:N2}";
            lblSaldo.Text = $"Saldo: R$ {(totalReceita - totalDespesa):N2}";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text;
            decimal valor = numValor.Value;
            string tipo = cmbTipo.Text;
            DateTime data = dtpData.Value;

           
            if (string.IsNullOrWhiteSpace(descricao) || valor == 0 || string.IsNullOrWhiteSpace(tipo))
            {
                MessageBox.Show("Preencha os Campos em Branco", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numValor.Value == 0)
            {
                MessageBox.Show("Preencha o Valor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Tipo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (idSelecionado == null)
            {
                Lancamento lancamento = new Lancamento()
                {
                    Descricao = descricao,
                    Valor = valor,
                    Tipo = tipo,
                    Data = data
                };

                lancamentoController.AdicionarLancamento(lancamento);
            }
            else  
            {
                var lancamento = lancamentoController.ListarLancamentos().FirstOrDefault(l => l.Id == idSelecionado);

                if (lancamento != null)
                {
                    lancamento.Descricao = descricao;
                    lancamento.Valor = valor;
                    lancamento.Tipo = tipo;
                    lancamento.Data = data;

                    lancamentoController.AtualizarLancamento(lancamento);
                }
            }

            AtualizarGrid();
            AtualizarChart();

        
            LimparCampos();
            idSelecionado = null; 
        }

        private void LimparCampos()
        {
            txtDescricao.Clear();
            numValor.Value = 0;
            cmbTipo.SelectedIndex = -1;
            dtpData.Value = DateTime.Now;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvLancamentos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um lançamento para remover!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(dgvLancamentos.SelectedRows[0].Cells["Id"].Value);

            var confirmacao = MessageBox.Show(
                "Deseja realmente remover o lançamento?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmacao == DialogResult.Yes)
            {
                lancamentoController.RemoverLancamento(id);
                AtualizarGrid();
               
            }
        }

        private void btnExibirTodos_Click(object sender, EventArgs e)
        {
            dgvLancamentos.DataSource = lancamentoController.ListarLancamentos();   

            chartResumo.Titles.Clear();
            chartResumo.Titles.Add("Resumo Financeiro:");
            AtualizarGrid();

            if (GerouGrafico)
            {
                AtualizarChart();
            }
        }

        private void btnFiltrarReceitas_Click(object sender, EventArgs e)
        {
            dgvLancamentos.DataSource = lancamentoController.FiltrarPorTipo("Receita");

            chartResumo.Titles.Clear();
            chartResumo.Titles.Add("Somente Receitas:");

            if (GerouGrafico)
            {
                AtualizarChart();
            }
        }

        private void btnFiltrarDespesas_Click(object sender, EventArgs e)
        {
            dgvLancamentos.DataSource = lancamentoController.FiltrarPorTipo("Despesa");

            chartResumo.Titles.Clear();
            chartResumo.Titles.Add("Somente Despesas:");
            
            if (GerouGrafico)
            {
                AtualizarChart();
            }
        }

        private void btnGerarGrafico_Click(object sender, EventArgs e)
        {
            GerouGrafico = true;
            chartResumo.Visible = true;
            AtualizarChart();
            btnFecharGrafico.Visible = true;
        }

        private void btnFecharGrafico_Click(object sender, EventArgs e)
        {
            chartResumo.Visible = false;
            GerouGrafico = false;    
        }

        private void dgvLancamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSelecionado = Convert.ToInt32(dgvLancamentos.SelectedRows[0].Cells["Id"].Value); // Usar a variável de classe 'idSelecionado'
                var lancamento = lancamentoController.ListarLancamentos().FirstOrDefault(l => l.Id == idSelecionado);

                if (lancamento != null)
                {
                    txtDescricao.Text = lancamento.Descricao;
                    numValor.Value = lancamento.Valor;
                    cmbTipo.SelectedItem = lancamento.Tipo;
                    dtpData.Value = lancamento.Data;
                }
            }
        }

    }
}
