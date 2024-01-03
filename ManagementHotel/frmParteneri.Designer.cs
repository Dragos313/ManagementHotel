namespace ManagementHotel
{
    partial class frmParteneri
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocalitate = new System.Windows.Forms.TextBox();
            this.cmbTara = new System.Windows.Forms.ComboBox();
            this.cmbJudet = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSterge = new System.Windows.Forms.Button();
            this.txtCNP = new System.Windows.Forms.TextBox();
            this.txtNumePrenume = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.btnAdauga = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.txtLocalitate);
            this.groupBox1.Controls.Add(this.cmbTara);
            this.groupBox1.Controls.Add(this.cmbJudet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTelefon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSterge);
            this.groupBox1.Controls.Add(this.txtCNP);
            this.groupBox1.Controls.Add(this.txtNumePrenume);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnActualizeaza);
            this.groupBox1.Controls.Add(this.btnAdauga);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(862, 269);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adauga Partener Nou";
            // 
            // txtLocalitate
            // 
            this.txtLocalitate.Location = new System.Drawing.Point(580, 139);
            this.txtLocalitate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLocalitate.Name = "txtLocalitate";
            this.txtLocalitate.Size = new System.Drawing.Size(255, 24);
            this.txtLocalitate.TabIndex = 24;
            // 
            // cmbTara
            // 
            this.cmbTara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTara.FormattingEnabled = true;
            this.cmbTara.Items.AddRange(new object[] {
            "---"});
            this.cmbTara.Location = new System.Drawing.Point(580, 97);
            this.cmbTara.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTara.Name = "cmbTara";
            this.cmbTara.Size = new System.Drawing.Size(255, 26);
            this.cmbTara.TabIndex = 23;
            // 
            // cmbJudet
            // 
            this.cmbJudet.FormattingEnabled = true;
            this.cmbJudet.Items.AddRange(new object[] {
            "---"});
            this.cmbJudet.Location = new System.Drawing.Point(140, 136);
            this.cmbJudet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJudet.Name = "cmbJudet";
            this.cmbJudet.Size = new System.Drawing.Size(255, 26);
            this.cmbJudet.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Judet:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 142);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "Localitate:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(140, 92);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(255, 24);
            this.txtTelefon.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Telefon:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tara:";
            // 
            // btnSterge
            // 
            this.btnSterge.BackColor = System.Drawing.Color.Red;
            this.btnSterge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSterge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSterge.ForeColor = System.Drawing.Color.White;
            this.btnSterge.Location = new System.Drawing.Point(362, 208);
            this.btnSterge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(129, 42);
            this.btnSterge.TabIndex = 7;
            this.btnSterge.Text = "Sterge";
            this.btnSterge.UseVisualStyleBackColor = false;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // txtCNP
            // 
            this.txtCNP.Location = new System.Drawing.Point(580, 46);
            this.txtCNP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCNP.Name = "txtCNP";
            this.txtCNP.Size = new System.Drawing.Size(255, 24);
            this.txtCNP.TabIndex = 13;
            // 
            // txtNumePrenume
            // 
            this.txtNumePrenume.Location = new System.Drawing.Point(140, 50);
            this.txtNumePrenume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumePrenume.Name = "txtNumePrenume";
            this.txtNumePrenume.Size = new System.Drawing.Size(255, 24);
            this.txtNumePrenume.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nume Prenume:";
            // 
            // btnActualizeaza
            // 
            this.btnActualizeaza.BackColor = System.Drawing.Color.Indigo;
            this.btnActualizeaza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizeaza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizeaza.ForeColor = System.Drawing.Color.White;
            this.btnActualizeaza.Location = new System.Drawing.Point(216, 208);
            this.btnActualizeaza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(139, 42);
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
            this.btnAdauga.Location = new System.Drawing.Point(78, 208);
            this.btnAdauga.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdauga.Name = "btnAdauga";
            this.btnAdauga.Size = new System.Drawing.Size(129, 42);
            this.btnAdauga.TabIndex = 8;
            this.btnAdauga.Text = "Adauga";
            this.btnAdauga.UseVisualStyleBackColor = false;
            this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "CNP:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 271);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(862, 246);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // frmParteneri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 517);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmParteneri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parteneri";
            this.Load += new System.EventHandler(this.frmParteneri_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.TextBox txtCNP;
        private System.Windows.Forms.TextBox txtNumePrenume;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Button btnAdauga;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtLocalitate;
        private System.Windows.Forms.ComboBox cmbTara;
        private System.Windows.Forms.ComboBox cmbJudet;
        private System.Windows.Forms.Label label2;
    }
}