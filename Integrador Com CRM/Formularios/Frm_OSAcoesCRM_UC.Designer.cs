﻿namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_OSAcoesCRM_UC
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DGV_Dados = new DataGridView();
            label1 = new Label();
            Btn_Add = new Button();
            groupBox1 = new GroupBox();
            Txt_Mensagem = new TextBox();
            label5 = new Label();
            Txt_CodAcao = new TextBox();
            label3 = new Label();
            Txt_IdCategoria = new TextBox();
            label2 = new Label();
            Btn_Remover = new Button();
            Btn_Salvar = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DGV_Dados
            // 
            DGV_Dados.AllowUserToAddRows = false;
            DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Dados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Dados.Location = new Point(21, 133);
            DGV_Dados.Name = "DGV_Dados";
            DGV_Dados.Size = new Size(790, 252);
            DGV_Dados.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(128, 128, 255);
            label1.Location = new Point(183, 12);
            label1.Name = "label1";
            label1.Size = new Size(415, 30);
            label1.TabIndex = 1;
            label1.Text = "Defina as Categorias e codigos das Ações";
            // 
            // Btn_Add
            // 
            Btn_Add.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Add.ForeColor = SystemColors.ActiveCaptionText;
            Btn_Add.Location = new Point(687, 40);
            Btn_Add.Name = "Btn_Add";
            Btn_Add.Size = new Size(97, 32);
            Btn_Add.TabIndex = 2;
            Btn_Add.Text = "Adicionar";
            Btn_Add.UseVisualStyleBackColor = true;
            Btn_Add.Click += Btn_Add_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(Txt_Mensagem);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(Txt_CodAcao);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Txt_IdCategoria);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Btn_Add);
            groupBox1.ForeColor = SystemColors.ActiveCaptionText;
            groupBox1.Location = new Point(21, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(790, 82);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Adicionar Dados";
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.Location = new Point(377, 27);
            Txt_Mensagem.MaxLength = 100;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.Size = new Size(275, 23);
            Txt_Mensagem.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(272, 30);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 10;
            label5.Text = "Mensagem Ação:";
            // 
            // Txt_CodAcao
            // 
            Txt_CodAcao.Location = new Point(107, 48);
            Txt_CodAcao.MaxLength = 100;
            Txt_CodAcao.Name = "Txt_CodAcao";
            Txt_CodAcao.Size = new Size(153, 23);
            Txt_CodAcao.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(13, 56);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 8;
            label3.Text = "Codigo Ação:";
            // 
            // Txt_IdCategoria
            // 
            Txt_IdCategoria.Location = new Point(107, 23);
            Txt_IdCategoria.MaxLength = 10;
            Txt_IdCategoria.Name = "Txt_IdCategoria";
            Txt_IdCategoria.Size = new Size(114, 23);
            Txt_IdCategoria.TabIndex = 7;
            Txt_IdCategoria.KeyPress += Txt_DiasCobrancas_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(13, 30);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 6;
            label2.Text = "Id Categoria:";
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Red;
            Btn_Remover.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Remover.Location = new Point(736, 391);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.Size = new Size(75, 23);
            Btn_Remover.TabIndex = 7;
            Btn_Remover.Text = "Remover";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.LimeGreen;
            Btn_Salvar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Salvar.Location = new Point(21, 391);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.Size = new Size(75, 27);
            Btn_Salvar.TabIndex = 8;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Yellow;
            label4.Location = new Point(119, 391);
            label4.Name = "label4";
            label4.Size = new Size(227, 21);
            label4.TabIndex = 9;
            label4.Text = "<--  Não Esqueça de Salvar :)";
            // 
            // Frm_OSAcoesCRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label4);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(DGV_Dados);
            Name = "Frm_OSAcoesCRM";
            Size = new Size(829, 421);
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Dados;
        private Label label1;
        private Button Btn_Add;
        private GroupBox groupBox1;
        private TextBox Txt_CodAcao;
        private Label label3;
        private TextBox Txt_IdCategoria;
        private Label label2;
        private Button Btn_Remover;
        private Button Btn_Salvar;
        private Label label4;
        private TextBox Txt_Mensagem;
        private Label label5;
    }
}
