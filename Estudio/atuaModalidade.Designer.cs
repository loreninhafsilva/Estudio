﻿namespace Estudio
{
    partial class atuaModalidade
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAtivo = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.maskConsultaPreco = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAulas = new System.Windows.Forms.TextBox();
            this.txtAlunos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAtivo);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.maskConsultaPreco);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtAulas);
            this.groupBox1.Controls.Add(this.txtAlunos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 342);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atualizar Modalidade";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAtivo
            // 
            this.btnAtivo.Location = new System.Drawing.Point(101, 265);
            this.btnAtivo.Name = "btnAtivo";
            this.btnAtivo.Size = new System.Drawing.Size(287, 23);
            this.btnAtivo.TabIndex = 12;
            this.btnAtivo.Text = "Ativar";
            this.btnAtivo.UseVisualStyleBackColor = true;
            this.btnAtivo.Click += new System.EventHandler(this.btnAtivo_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(196, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // maskConsultaPreco
            // 
            this.maskConsultaPreco.Location = new System.Drawing.Point(196, 84);
            this.maskConsultaPreco.Mask = "000,00";
            this.maskConsultaPreco.Name = "maskConsultaPreco";
            this.maskConsultaPreco.Size = new System.Drawing.Size(41, 21);
            this.maskConsultaPreco.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAulas
            // 
            this.txtAulas.Location = new System.Drawing.Point(196, 163);
            this.txtAulas.Name = "txtAulas";
            this.txtAulas.Size = new System.Drawing.Size(192, 21);
            this.txtAulas.TabIndex = 7;
            // 
            // txtAlunos
            // 
            this.txtAlunos.Location = new System.Drawing.Point(197, 121);
            this.txtAlunos.Name = "txtAlunos";
            this.txtAlunos.Size = new System.Drawing.Size(192, 21);
            this.txtAlunos.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modalidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preço:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(98, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Qtde de Aulas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Qtde de Alunos:";
            // 
            // atuaModalidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 368);
            this.Controls.Add(this.groupBox1);
            this.Name = "atuaModalidade";
            this.Text = "Atualizar Modalidade";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAtivo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MaskedTextBox maskConsultaPreco;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAulas;
        private System.Windows.Forms.TextBox txtAlunos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}