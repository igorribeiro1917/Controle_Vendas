using System;

namespace ProjetoControleVendas.br.com.projeto.view
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtdata = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txthora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtusuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoricoVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracao = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracaoTrocaUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracaoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtdata,
            this.toolStripStatusLabel3,
            this.txthora,
            this.toolStripStatusLabel5,
            this.txtusuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(983, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Data Atual:";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // txtdata
            // 
            this.txtdata.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdata.Name = "txtdata";
            this.txtdata.Size = new System.Drawing.Size(73, 17);
            this.txtdata.Text = "08/08/2024";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel3.Text = "Hora Atual:";
            // 
            // txthora
            // 
            this.txthora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthora.Name = "txthora";
            this.txthora.Size = new System.Drawing.Size(38, 17);
            this.txthora.Text = "10:30";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(93, 17);
            this.toolStripStatusLabel5.Text = "Usuário Logado:";
            // 
            // txtusuario
            // 
            this.txtusuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(73, 17);
            this.txtusuario.Text = "Igor Ribeiro";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCliente,
            this.menuFuncionario,
            this.menuFornecedores,
            this.menuProdutos,
            this.menuVenda,
            this.menuConfiguracao});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(983, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuCliente
            // 
            this.menuCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConsultaClientes,
            this.consultaDeClientesToolStripMenuItem});
            this.menuCliente.Image = global::ProjetoControleVendas.Properties.Resources._1120619_businessman_client_man_manager_person_icon;
            this.menuCliente.Name = "menuCliente";
            this.menuCliente.Size = new System.Drawing.Size(77, 20);
            this.menuCliente.Text = "Clientes";
            // 
            // menuConsultaClientes
            // 
            this.menuConsultaClientes.Name = "menuConsultaClientes";
            this.menuConsultaClientes.Size = new System.Drawing.Size(182, 22);
            this.menuConsultaClientes.Text = "Cadastro de Clientes";
            this.menuConsultaClientes.Click += new System.EventHandler(this.menuConsultaClientes_Click);
            // 
            // consultaDeClientesToolStripMenuItem
            // 
            this.consultaDeClientesToolStripMenuItem.Name = "consultaDeClientesToolStripMenuItem";
            this.consultaDeClientesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.consultaDeClientesToolStripMenuItem.Text = "Consulta de Clientes";
            this.consultaDeClientesToolStripMenuItem.Click += new System.EventHandler(this.consultaDeClientesToolStripMenuItem_Click);
            // 
            // menuFuncionario
            // 
            this.menuFuncionario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFuncionario,
            this.menuConsultaFuncionario});
            this.menuFuncionario.Image = global::ProjetoControleVendas.Properties.Resources._11689930_worker_person_employee_man_engineer_icon;
            this.menuFuncionario.Name = "menuFuncionario";
            this.menuFuncionario.Size = new System.Drawing.Size(103, 20);
            this.menuFuncionario.Text = "Funcionários";
            this.menuFuncionario.Click += new System.EventHandler(this.menuFuncionario_Click);
            // 
            // menuCadastroFuncionario
            // 
            this.menuCadastroFuncionario.Name = "menuCadastroFuncionario";
            this.menuCadastroFuncionario.Size = new System.Drawing.Size(208, 22);
            this.menuCadastroFuncionario.Text = "Cadastro de Funcionário";
            this.menuCadastroFuncionario.Click += new System.EventHandler(this.menuCadastroFuncionario_Click);
            // 
            // menuConsultaFuncionario
            // 
            this.menuConsultaFuncionario.Name = "menuConsultaFuncionario";
            this.menuConsultaFuncionario.Size = new System.Drawing.Size(208, 22);
            this.menuConsultaFuncionario.Text = "Consulta de Funcionários";
            this.menuConsultaFuncionario.Click += new System.EventHandler(this.menuConsultaFuncionario_Click);
            // 
            // menuFornecedores
            // 
            this.menuFornecedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFornecedores,
            this.menuConsultaFornecedores});
            this.menuFornecedores.Image = global::ProjetoControleVendas.Properties.Resources._3387292_market_shopping_icon;
            this.menuFornecedores.Name = "menuFornecedores";
            this.menuFornecedores.Size = new System.Drawing.Size(106, 20);
            this.menuFornecedores.Text = "Fornecedores";
            // 
            // menuCadastroFornecedores
            // 
            this.menuCadastroFornecedores.Name = "menuCadastroFornecedores";
            this.menuCadastroFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuCadastroFornecedores.Text = "Cadastro de Fornecedores";
            this.menuCadastroFornecedores.Click += new System.EventHandler(this.menuCadastroFornecedores_Click);
            // 
            // menuConsultaFornecedores
            // 
            this.menuConsultaFornecedores.Name = "menuConsultaFornecedores";
            this.menuConsultaFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuConsultaFornecedores.Text = "Consulta de Fornecedores";
            this.menuConsultaFornecedores.Click += new System.EventHandler(this.menuConsultaFornecedores_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroProdutos,
            this.menuConsultaProdutos});
            this.menuProdutos.Image = global::ProjetoControleVendas.Properties.Resources._52650_box_full_icon;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(83, 20);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuCadastroProdutos
            // 
            this.menuCadastroProdutos.Name = "menuCadastroProdutos";
            this.menuCadastroProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuCadastroProdutos.Text = "Cadastro de Produtos";
            this.menuCadastroProdutos.Click += new System.EventHandler(this.menuCadastroProdutos_Click);
            // 
            // menuConsultaProdutos
            // 
            this.menuConsultaProdutos.Name = "menuConsultaProdutos";
            this.menuConsultaProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuConsultaProdutos.Text = "Consulta de Produtos";
            this.menuConsultaProdutos.Click += new System.EventHandler(this.menuConsultaProdutos_Click);
            // 
            // menuVenda
            // 
            this.menuVenda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistoricoVenda});
            this.menuVenda.Image = global::ProjetoControleVendas.Properties.Resources._9802735_cashback_sales_discount_offer_icon;
            this.menuVenda.Name = "menuVenda";
            this.menuVenda.Size = new System.Drawing.Size(72, 20);
            this.menuVenda.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(180, 22);
            this.menuNovaVenda.Text = "Nova Venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistoricoVenda
            // 
            this.menuHistoricoVenda.Name = "menuHistoricoVenda";
            this.menuHistoricoVenda.Size = new System.Drawing.Size(180, 22);
            this.menuHistoricoVenda.Text = "Histórico de Venda";
            this.menuHistoricoVenda.Click += new System.EventHandler(this.menuHistoricoVenda_Click);
            // 
            // menuConfiguracao
            // 
            this.menuConfiguracao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfiguracaoTrocaUsuario,
            this.menuConfiguracaoSair});
            this.menuConfiguracao.Image = global::ProjetoControleVendas.Properties.Resources._5402442_settings_cog_configuration_gear_options_icon1;
            this.menuConfiguracao.Name = "menuConfiguracao";
            this.menuConfiguracao.Size = new System.Drawing.Size(112, 20);
            this.menuConfiguracao.Text = "Configurações";
            // 
            // menuConfiguracaoTrocaUsuario
            // 
            this.menuConfiguracaoTrocaUsuario.Name = "menuConfiguracaoTrocaUsuario";
            this.menuConfiguracaoTrocaUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuConfiguracaoTrocaUsuario.Text = "Trocar de Usuário";
            this.menuConfiguracaoTrocaUsuario.Click += new System.EventHandler(this.menuConfiguracaoTrocaUsuario_Click);
            // 
            // menuConfiguracaoSair
            // 
            this.menuConfiguracaoSair.Name = "menuConfiguracaoSair";
            this.menuConfiguracaoSair.Size = new System.Drawing.Size(180, 22);
            this.menuConfiguracaoSair.Text = "Sair";
            this.menuConfiguracaoSair.Click += new System.EventHandler(this.menuConfiguracaoSair_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjetoControleVendas.Properties.Resources._1000_F_84710252_ZrquscCqzOdXW00o6wMebF1TUp3wjkq9;
            this.ClientSize = new System.Drawing.Size(983, 439);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Menu Principal -  Controle de Vendas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
       

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtdata;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel txthora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCliente;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuVenda;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuHistoricoVenda;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracao;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracaoTrocaUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracaoSair;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem consultaDeClientesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem menuProdutos;
        public System.Windows.Forms.ToolStripMenuItem menuFuncionario;
        public System.Windows.Forms.ToolStripMenuItem menuFornecedores;
        public System.Windows.Forms.ToolStripMenuItem menuCadastroFornecedores;
        public System.Windows.Forms.ToolStripStatusLabel txtusuario;
    }
}