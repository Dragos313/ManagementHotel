﻿using System.Windows.Forms;

namespace ManagementHotel
{
    partial class frmUtilizator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUtilizator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFunctie = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParola = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSterge = new System.Windows.Forms.Button();
            this.txtCNP = new System.Windows.Forms.TextBox();
            this.txtNumePrenume = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.txtUtilizator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.cmbFunctie);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTelefon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtParola);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSterge);
            this.groupBox1.Controls.Add(this.txtCNP);
            this.groupBox1.Controls.Add(this.txtNumePrenume);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnActualizeaza);
            this.groupBox1.Controls.Add(this.btnAdauga);
            this.groupBox1.Controls.Add(this.txtUtilizator);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(974, 336);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adauga Utilizator Nou";
            // 
            // cmbFunctie
            // 
            this.cmbFunctie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunctie.FormattingEnabled = true;
            this.cmbFunctie.Items.AddRange(new object[] {
            "---",
            "Administrator",
            "Receptioner"});
            this.cmbFunctie.Location = new System.Drawing.Point(652, 175);
            this.cmbFunctie.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cmbFunctie.Name = "cmbFunctie";
            this.cmbFunctie.Size = new System.Drawing.Size(286, 30);
            this.cmbFunctie.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(489, 178);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Functie:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(172, 167);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(286, 28);
            this.txtTelefon.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Telefon:";
            // 
            // txtParola
            // 
            this.txtParola.Location = new System.Drawing.Point(652, 118);
            this.txtParola.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtParola.Name = "txtParola";
            this.txtParola.Size = new System.Drawing.Size(286, 28);
            this.txtParola.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(489, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "Parola:";
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.Color.Red;
            this.btnSterge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSterge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSterge.ForeColor = System.Drawing.Color.White;
            this.btnSterge.Location = new System.Drawing.Point(407, 260);
            this.btnSterge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(145, 52);
            this.btnSterge.TabIndex = 7;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = false;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // txtCNP
            // 
            this.txtCNP.Location = new System.Drawing.Point(172, 114);
            this.txtCNP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCNP.Name = "txtCNP";
            this.txtCNP.Size = new System.Drawing.Size(286, 28);
            this.txtCNP.TabIndex = 13;
            // 
            // txtNumePrenume
            // 
            this.txtNumePrenume.Location = new System.Drawing.Point(652, 62);
            this.txtNumePrenume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumePrenume.Name = "txtNumePrenume";
            this.txtNumePrenume.Size = new System.Drawing.Size(286, 28);
            this.txtNumePrenume.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nume Prenume:";
            // 
            // btnActualizeaza
            // 
            this.btnActualizeaza.BackColor = System.Drawing.Color.Indigo;
            this.btnActualizeaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizeaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizeaza.ForeColor = System.Drawing.Color.White;
            this.btnActualizeaza.Location = new System.Drawing.Point(243, 260);
            this.btnActualizeaza.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(156, 52);
            this.btnActualizeaza.TabIndex = 9;
            this.btnActualizeaza.Text = "Actualizeaza";
            this.btnActualizeaza.UseVisualStyleBackColor = false;
            this.btnActualizeaza.Click += new System.EventHandler(this.btnActualizeaza_Click);
            // 
            // btnAdauga
            // 
            this.btnAdauga.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAdauga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdauga.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdauga.ForeColor = System.Drawing.Color.White;
            this.btnAdauga.Location = new System.Drawing.Point(88, 260);
            this.btnAdauga.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(145, 52);
            this.btnAdauga.TabIndex = 8;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // txtUtilizator
            // 
            this.txtUtilizator.Location = new System.Drawing.Point(172, 68);
            this.txtUtilizator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUtilizator.Name = "txtUtilizator";
            this.txtUtilizator.Size = new System.Drawing.Size(286, 28);
            this.txtUtilizator.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "CNP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Utilizator";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 335);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(974, 308);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // frmUtilizator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 643);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUtilizator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilizator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUtilizator_FormClosing);
            this.Load += new System.EventHandler(this.frmUtilizator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtParola;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.TextBox txtCNP;
        private System.Windows.Forms.TextBox txtNumePrenume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.TextBox txtUtilizator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFunctie;
    }
}