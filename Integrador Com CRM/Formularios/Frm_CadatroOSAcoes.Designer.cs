﻿namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_CadatroOSAcoes
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
            components = new System.ComponentModel.Container();
            label5 = new Label();
            label2 = new Label();
            Txt_Mensagem = new TextBox();
            Btn_Salvar = new ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new ComponentesPerson.BotaoArredond(components);
            Txt_IdCategoria = new TextBox();
            label1 = new Label();
            Txt_Id = new TextBox();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(33, 93);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 15;
            label5.Text = "Mensagem Ação:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(33, 62);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 11;
            label2.Text = "Id Categoria:";
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.Location = new Point(33, 111);
            Txt_Mensagem.MaxLength = 100;
            Txt_Mensagem.Multiline = true;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.Size = new Size(394, 128);
            Txt_Mensagem.TabIndex = 16;
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.LimeGreen;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(127, 260);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 18;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Tomato;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(235, 260);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 17;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Txt_IdCategoria
            // 
            Txt_IdCategoria.Location = new Point(113, 59);
            Txt_IdCategoria.MaxLength = 10;
            Txt_IdCategoria.Name = "Txt_IdCategoria";
            Txt_IdCategoria.Size = new Size(114, 23);
            Txt_IdCategoria.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 19;
            label1.Text = "ID:";
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(113, 25);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 21;
            // 
            // Frm_CadatroOSAcoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(461, 298);
            Controls.Add(Txt_Id);
            Controls.Add(Txt_IdCategoria);
            Controls.Add(label1);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(Txt_Mensagem);
            Controls.Add(label5);
            Controls.Add(label2);
            DoubleBuffered = true;
            MaximizeBox = false;
            MaximumSize = new Size(477, 337);
            MinimizeBox = false;
            MinimumSize = new Size(477, 337);
            Name = "Frm_CadatroOSAcoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Frm_CadatroOSAcoes";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label2;
        private TextBox Txt_Mensagem;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private TextBox Txt_IdCategoria;
        private Label label1;
        private TextBox Txt_Id;
    }
}