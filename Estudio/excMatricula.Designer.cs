
namespace Estudio
{
    partial class excMatricula
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
            this.cbAlunos = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbHora = new System.Windows.Forms.ComboBox();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.cbModalidade = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAlunos);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbHora);
            this.groupBox1.Controls.Add(this.cbDia);
            this.groupBox1.Controls.Add(this.cbModalidade);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 323);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Excluir Matrícula";
            // 
            // cbAlunos
            // 
            this.cbAlunos.FormattingEnabled = true;
            this.cbAlunos.Location = new System.Drawing.Point(199, 177);
            this.cbAlunos.Name = "cbAlunos";
            this.cbAlunos.Size = new System.Drawing.Size(185, 25);
            this.cbAlunos.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Excluir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbHora
            // 
            this.cbHora.FormattingEnabled = true;
            this.cbHora.Location = new System.Drawing.Point(147, 146);
            this.cbHora.Name = "cbHora";
            this.cbHora.Size = new System.Drawing.Size(237, 25);
            this.cbHora.TabIndex = 7;
            this.cbHora.SelectedIndexChanged += new System.EventHandler(this.cbHora_SelectedIndexChanged);
            // 
            // cbDia
            // 
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Location = new System.Drawing.Point(199, 115);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(185, 25);
            this.cbDia.TabIndex = 6;
            this.cbDia.SelectedIndexChanged += new System.EventHandler(this.cbDia_SelectedIndexChanged);
            // 
            // cbModalidade
            // 
            this.cbModalidade.FormattingEnabled = true;
            this.cbModalidade.Location = new System.Drawing.Point(173, 80);
            this.cbModalidade.Name = "cbModalidade";
            this.cbModalidade.Size = new System.Drawing.Size(211, 25);
            this.cbModalidade.TabIndex = 5;
            this.cbModalidade.SelectedIndexChanged += new System.EventHandler(this.cbModalidade_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nome do aluno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dia da semana:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Horário:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modalidade:";
            // 
            // excMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 351);
            this.Controls.Add(this.groupBox1);
            this.Name = "excMatricula";
            this.Text = "excMatricula";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbHora;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.ComboBox cbModalidade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAlunos;
    }
}