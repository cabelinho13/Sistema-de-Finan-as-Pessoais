// FormDashboard.Designer.cs - Versão atualizada com painel de inserção, dashboard e gráfico 🍰

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinancasPessoais.View
{
    partial class FormDashboard
    {
        private Panel pnlDashboard;
        private Panel pnlInsercao;

        private Label lblReceitasResumo;
        private Label lblDespesasResumo;
        private Label lblSaldoResumo;
        private Label lblMaiorGasto;
        private Label lblGastoMedio;
        private Label lblFiltroMes;

        private ComboBox cmbMesFiltro;
        private Button btnNovoLancamento;
        private Button btnExportarExcel;
        private Button btnExportarPDF;

        private Chart chartResumo;

        private TextBox txtDescricao;
        private NumericUpDown numValor;
        private ComboBox cmbTipo;
        private DateTimePicker dtpData;
        private Button btnSalvar;
        private Button btnVoltarDashboard;

        private void InitializeComponent()
        {
            this.Text = "Dashboard - Finanças Pessoais";
            this.Size = new Size(880, 570);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            // ================== Painel Insercao ==================
            pnlInsercao = new Panel();
            pnlInsercao.Size = new Size(850, 500);
            pnlInsercao.Location = new Point(10, 10);
            pnlInsercao.Visible = false;
            pnlInsercao.BackColor = Color.WhiteSmoke;

            Label lblTitulo = new Label()
            {
                Text = "Novo Lançamento",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(300, 20),
                AutoSize = true
            };

            // Label: Descrição
            Label lblDesc = new Label() { Text = "Descrição:", Location = new Point(200, 80), AutoSize = true };
            txtDescricao = new TextBox() { Location = new Point(280, 78), Width = 250 };

            // Label: Valor
            Label lblVal = new Label() { Text = "Valor:", Location = new Point(200, 120), AutoSize = true };
            numValor = new NumericUpDown()
            {
                Location = new Point(280, 118),
                Width = 100,
                DecimalPlaces = 2,
                Maximum = 1000000,
                ThousandsSeparator = true
            };

            // Label: Tipo
            Label lblTp = new Label() { Text = "Tipo:", Location = new Point(200, 160), AutoSize = true };
            cmbTipo = new ComboBox()
            {
                Location = new Point(280, 158),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipo.Items.AddRange(new object[] { "Receita", "Despesa" });

            // Label: Data
            Label lblDt = new Label() { Text = "Data:", Location = new Point(200, 200), AutoSize = true };
            dtpData = new DateTimePicker() { Location = new Point(280, 198), Width = 200 };

            // Botões
            btnSalvar = new Button()
            {
                Text = "💾 Salvar",
                Location = new Point(280, 250),
                Width = 100,
                BackColor = Color.LightGreen
            };
            btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

            btnVoltarDashboard = new Button()
            {
                Text = "← Voltar",
                Location = new Point(390, 250),
                Width = 100,
                BackColor = Color.LightGray
            };
            btnVoltarDashboard.Click += new EventHandler(this.btnVoltarDashboard_Click);

            pnlInsercao.Controls.AddRange(new Control[]
            {
    lblTitulo,
    lblDesc, txtDescricao,
    lblVal, numValor,
    lblTp, cmbTipo,
    lblDt, dtpData,
    btnSalvar, btnVoltarDashboard
            });

            // ================== Painel Dashboard ==================
            pnlDashboard = new Panel();
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.BackColor = Color.WhiteSmoke;

            // Cards de resumo
            lblReceitasResumo = new Label()
            {
                Text = "💰 Receitas: R$ 0,00",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkGreen,
                BackColor = Color.FromArgb(220, 255, 220),
                Location = new Point(30, 20),
                Size = new Size(220, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblDespesasResumo = new Label()
            {
                Text = "💳 Despesas: R$ 0,00",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                BackColor = Color.FromArgb(255, 230, 230),
                Location = new Point(270, 20),
                Size = new Size(220, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblSaldoResumo = new Label()
            {
                Text = "📅 Saldo: R$ 0,00",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.DimGray,
                BackColor = Color.LightGray,
                Location = new Point(510, 20),
                Size = new Size(220, 50),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Informações extras
            lblMaiorGasto = new Label() { Text = "🚀 Maior Gasto: --", Location = new Point(30, 85), AutoSize = true };
            lblGastoMedio = new Label() { Text = "📊 Gasto Médio: R$ 0,00", Location = new Point(270, 85), AutoSize = true };

            // Filtro de mês
            lblFiltroMes = new Label() { Text = "Filtrar por Mês:", Location = new Point(30, 115), AutoSize = true };
            cmbMesFiltro = new ComboBox()
            {
                Location = new Point(130, 110),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbMesFiltro.Items.AddRange(new object[]
            {
    "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
    "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            });
            

            // Botões
            btnExportarExcel = new Button()
            {
                Text = "Exportar Excel",
                Location = new Point(750, 20),
                Size = new Size(100, 30),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnExportarExcel.Click += new EventHandler(this.btnExportarExcel_Click);

            btnExportarPDF = new Button()
            {
                Text = "Exportar PDF",
                Location = new Point(750, 60),
                Size = new Size(100, 30),
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnExportarPDF.Click += new EventHandler(this.btnExportarPDF_Click);

            btnNovoLancamento = new Button()
            {
                Text = "+ Novo",
                Location = new Point(750, 110),
                Size = new Size(100, 30),
                BackColor = Color.AliceBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnNovoLancamento.Click += new EventHandler(this.btnNovoLancamento_Click);

            // Gráfico
            chartResumo = new Chart()
            {
                Location = new Point(30, 160),
                Size = new Size(800, 350)
            };
            ChartArea chartArea = new ChartArea();
            chartResumo.ChartAreas.Add(chartArea);

            // Adiciona todos os componentes ao painel
            pnlDashboard.Controls.AddRange(new Control[]
            {
    lblReceitasResumo, lblDespesasResumo, lblSaldoResumo,
    lblMaiorGasto, lblGastoMedio,
    lblFiltroMes, cmbMesFiltro,
    btnExportarExcel, btnExportarPDF, btnNovoLancamento,
    chartResumo
            });

            // ============ Adiciona ambos painéis ao form ============
            this.Controls.Add(pnlInsercao);
            this.Controls.Add(pnlDashboard);
        }
    }
}
