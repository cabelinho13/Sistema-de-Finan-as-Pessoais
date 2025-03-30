namespace FinancasPessoais
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgvLancamentos = new System.Windows.Forms.DataGridView();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnExibirTodos = new System.Windows.Forms.Button();
            this.btnFiltrarReceitas = new System.Windows.Forms.Button();
            this.btnFiltrarDespesas = new System.Windows.Forms.Button();
            this.btnGerarGrafico = new System.Windows.Forms.Button();
            this.lblTotalReceitas = new System.Windows.Forms.Label();
            this.lblTotalDespesas = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.chartResumo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnFecharGrafico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLancamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(126, 20);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(200, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // numValor
            // 
            this.numValor.DecimalPlaces = 2;
            this.numValor.Location = new System.Drawing.Point(126, 58);
            this.numValor.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(120, 20);
            this.numValor.TabIndex = 3;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] {
            "Receita",
            "Despesa"});
            this.cmbTipo.Location = new System.Drawing.Point(125, 100);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 5;
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(126, 140);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(200, 20);
            this.dtpData.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(126, 182);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(200, 23);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "Adicionar / Atualizar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dgvLancamentos
            // 
            this.dgvLancamentos.AllowUserToAddRows = false;
            this.dgvLancamentos.Location = new System.Drawing.Point(20, 220);
            this.dgvLancamentos.Name = "dgvLancamentos";
            this.dgvLancamentos.ReadOnly = true;
            this.dgvLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLancamentos.Size = new System.Drawing.Size(600, 200);
            this.dgvLancamentos.TabIndex = 9;
            this.dgvLancamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLancamentos_CellClick);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(640, 220);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 10;
            this.btnRemover.Text = "Remover Selecionado";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnExibirTodos
            // 
            this.btnExibirTodos.Location = new System.Drawing.Point(640, 260);
            this.btnExibirTodos.Name = "btnExibirTodos";
            this.btnExibirTodos.Size = new System.Drawing.Size(75, 23);
            this.btnExibirTodos.TabIndex = 11;
            this.btnExibirTodos.Text = "Exibir Todos";
            this.btnExibirTodos.Click += new System.EventHandler(this.btnExibirTodos_Click);
            // 
            // btnFiltrarReceitas
            // 
            this.btnFiltrarReceitas.Location = new System.Drawing.Point(640, 300);
            this.btnFiltrarReceitas.Name = "btnFiltrarReceitas";
            this.btnFiltrarReceitas.Size = new System.Drawing.Size(102, 23);
            this.btnFiltrarReceitas.TabIndex = 12;
            this.btnFiltrarReceitas.Text = "Filtrar Receitas";
            this.btnFiltrarReceitas.Click += new System.EventHandler(this.btnFiltrarReceitas_Click);
            // 
            // btnFiltrarDespesas
            // 
            this.btnFiltrarDespesas.Location = new System.Drawing.Point(640, 340);
            this.btnFiltrarDespesas.Name = "btnFiltrarDespesas";
            this.btnFiltrarDespesas.Size = new System.Drawing.Size(102, 23);
            this.btnFiltrarDespesas.TabIndex = 13;
            this.btnFiltrarDespesas.Text = "Filtrar Despesas";
            this.btnFiltrarDespesas.Click += new System.EventHandler(this.btnFiltrarDespesas_Click);
            // 
            // btnGerarGrafico
            // 
            this.btnGerarGrafico.Location = new System.Drawing.Point(640, 380);
            this.btnGerarGrafico.Name = "btnGerarGrafico";
            this.btnGerarGrafico.Size = new System.Drawing.Size(102, 23);
            this.btnGerarGrafico.TabIndex = 14;
            this.btnGerarGrafico.Text = "Gerar Gráfico";
            this.btnGerarGrafico.Click += new System.EventHandler(this.btnGerarGrafico_Click);
            // 
            // lblTotalReceitas
            // 
            this.lblTotalReceitas.Location = new System.Drawing.Point(20, 430);
            this.lblTotalReceitas.Name = "lblTotalReceitas";
            this.lblTotalReceitas.Size = new System.Drawing.Size(100, 23);
            this.lblTotalReceitas.TabIndex = 15;
            this.lblTotalReceitas.Text = "Total de Receitas: R$ 0,00";
            // 
            // lblTotalDespesas
            // 
            this.lblTotalDespesas.Location = new System.Drawing.Point(220, 430);
            this.lblTotalDespesas.Name = "lblTotalDespesas";
            this.lblTotalDespesas.Size = new System.Drawing.Size(100, 23);
            this.lblTotalDespesas.TabIndex = 16;
            this.lblTotalDespesas.Text = "Total de Despesas: R$ 0,00";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Location = new System.Drawing.Point(420, 430);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(100, 23);
            this.lblSaldo.TabIndex = 17;
            this.lblSaldo.Text = "Saldo: R$ 0,00";
            // 
            // lblDescricao
            // 
            this.lblDescricao.Location = new System.Drawing.Point(20, 20);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(100, 23);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblValor
            // 
            this.lblValor.Location = new System.Drawing.Point(20, 60);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(100, 23);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor:";
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(20, 100);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(100, 23);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(20, 140);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 23);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "Data:";
            // 
            // chartResumo
            // 
            chartArea1.Name = "ChartArea1";
            this.chartResumo.ChartAreas.Add(chartArea1);
            this.chartResumo.Location = new System.Drawing.Point(20, 470);
            this.chartResumo.Name = "chartResumo";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Resumo";
            this.chartResumo.Series.Add(series1);
            this.chartResumo.Size = new System.Drawing.Size(760, 200);
            this.chartResumo.TabIndex = 18;
            // 
            // btnFecharGrafico
            // 
            this.btnFecharGrafico.Location = new System.Drawing.Point(748, 380);
            this.btnFecharGrafico.Name = "btnFecharGrafico";
            this.btnFecharGrafico.Size = new System.Drawing.Size(90, 23);
            this.btnFecharGrafico.TabIndex = 19;
            this.btnFecharGrafico.Text = "Fechar Gráfico";
            this.btnFecharGrafico.Click += new System.EventHandler(this.btnFecharGrafico_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(850, 700);
            this.Controls.Add(this.btnFecharGrafico);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvLancamentos);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnExibirTodos);
            this.Controls.Add(this.btnFiltrarReceitas);
            this.Controls.Add(this.btnFiltrarDespesas);
            this.Controls.Add(this.btnGerarGrafico);
            this.Controls.Add(this.lblTotalReceitas);
            this.Controls.Add(this.lblTotalDespesas);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.chartResumo);
            this.Name = "Form1";
            this.Text = "Controle de Finanças Pessoais";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLancamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResumo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.DataGridView dgvLancamentos;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnExibirTodos;
        private System.Windows.Forms.Button btnFiltrarReceitas;
        private System.Windows.Forms.Button btnFiltrarDespesas;
        private System.Windows.Forms.Button btnGerarGrafico;
        private System.Windows.Forms.Label lblTotalReceitas;
        private System.Windows.Forms.Label lblTotalDespesas;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResumo;
        private System.Windows.Forms.Button btnFecharGrafico;
    }
}

