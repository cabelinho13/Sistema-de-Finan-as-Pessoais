// ATENÇÃO: O layout é gerado 100% por código, o Designer Visual estará vazio.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinancasPessoais.Controller;
using FinancasPessoais.Model;

namespace FinancasPessoais.View
{
    public partial class FormDashboard : Form
    {
        private int? idSelecionado = null;
        private LancamentoController lancamentoController = new LancamentoController();

        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

            cmbMesFiltro.SelectedIndexChanged += CmbMesFiltro_SelectedIndexChanged;

            int mesAtual = DateTime.Now.Month;
            cmbMesFiltro.SelectedIndex = mesAtual - 1;
            AtualizarDashboard();
        }

        private void CmbMesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDashboard();
        }

        public void AtualizarDashboard()
        {
            var todosLancamentos = lancamentoController.ListarLancamentos();
            int mesSelecionado = cmbMesFiltro.SelectedIndex + 1;

            var filtrados = todosLancamentos
                .Where(l => l.Data.Month == mesSelecionado)
                .ToList();

            AtualizarCards(filtrados);
            AtualizarChart(filtrados);
        }

        private void AtualizarChart(List<Lancamento> lista)
        {
            chartResumo.Series.Clear();
            chartResumo.Titles.Clear();

            chartResumo.Titles.Add("Resumo Financeiro");
            chartResumo.ChartAreas[0].AxisX.Title = "Tipo";
            chartResumo.ChartAreas[0].AxisY.Title = "Valor (R$)";

            Series serie = new Series("Lançamentos")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#VALX\n#VAL{C}\n#PERCENT",
                LegendText = "#VALX"
            };

            decimal totalReceita = lista
                .Where(l => l.Tipo.Equals("Receita", StringComparison.OrdinalIgnoreCase))
                .Sum(l => l.Valor);

            decimal totalDespesa = lista
                .Where(l => l.Tipo.Equals("Despesa", StringComparison.OrdinalIgnoreCase))
                .Sum(l => l.Valor);

            if (totalReceita > 0)
            {
                int index = serie.Points.AddXY("Receita", totalReceita);
                serie.Points[index].Color = Color.Green;
            }

            if (totalDespesa > 0)
            {
                int index = serie.Points.AddXY("Despesa", totalDespesa);
                serie.Points[index].Color = Color.Red;
            }

            chartResumo.Series.Add(serie);
        }

        public void AtualizarCards(List<Lancamento> lista)
        {
            decimal totalReceitas = lista.Where(l => l.Tipo.Equals("Receita", StringComparison.OrdinalIgnoreCase)).Sum(l => l.Valor);
            decimal totalDespesas = lista.Where(l => l.Tipo.Equals("Despesa", StringComparison.OrdinalIgnoreCase)).Sum(l => l.Valor);

            decimal saldo = totalReceitas - totalDespesas;

            lblReceitasResumo.Text = $"💰 Receitas: R$ {totalReceitas:N2}";
            lblDespesasResumo.Text = $"💳 Despesas: R$ {totalDespesas:N2}";
            lblSaldoResumo.Text = $"📅 Saldo: R$ {saldo:N2}";

            if (saldo > 0)
                lblSaldoResumo.ForeColor = Color.Green;
            else if (saldo < 0)
                lblSaldoResumo.ForeColor = Color.Red;
            else
                lblSaldoResumo.ForeColor = Color.Gray;

            var maiorGasto = lista
                .Where(l => l.Tipo.Equals("Despesa", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(l => l.Valor)
                .FirstOrDefault();

            lblMaiorGasto.Text = maiorGasto != null
                ? $"🚀 Maior Gasto: {maiorGasto.Descricao} - R$ {maiorGasto.Valor:N2}"
                : "🚀 Maior Gasto: --";

            var despesas = lista.Where(l => l.Tipo.Equals("Despesa", StringComparison.OrdinalIgnoreCase)).ToList();
            decimal media = despesas.Count > 0 ? despesas.Average(l => l.Valor) : 0;

            lblGastoMedio.Text = $"📊 Gasto Médio: R$ {media:N2}";
        }

        private void btnNovoLancamento_Click(object sender, EventArgs e)
        {
            pnlDashboard.Visible = false;
            pnlInsercao.Visible = true;
            LimparCampos();
            idSelecionado = null;
        }

        private void btnVoltarDashboard_Click(object sender, EventArgs e)
        {
            pnlInsercao.Visible = false;
            pnlDashboard.Visible = true;
            AtualizarDashboard();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string descricao = txtDescricao.Text.Trim();
            decimal valor = numValor.Value;
            string tipo = cmbTipo.Text;
            DateTime data = dtpData.Value;

            if (string.IsNullOrWhiteSpace(descricao) || valor == 0 || string.IsNullOrWhiteSpace(tipo))
            {
                MessageBox.Show("Preencha todos os campos corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo do lançamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lancamento lancamento = new Lancamento()
            {
                Descricao = descricao,
                Valor = valor,
                Tipo = tipo,
                Data = data
            };

            lancamentoController.AdicionarLancamento(lancamento);

            cmbMesFiltro.SelectedIndex = data.Month - 1;


            AtualizarDashboard();

            MessageBox.Show("Lançamento salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            pnlInsercao.Visible = false;
            pnlDashboard.Visible = true;

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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função de exportação ainda será implementada!", "Atenção");
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Função de exportação ainda será implementada!", "Atenção");
        }
    }
}