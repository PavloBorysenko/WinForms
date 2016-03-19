namespace BorysekoExamAdoNet
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.TimeTable = new System.Windows.Forms.DataGridView();
            this.InfoTimeTable = new System.Windows.Forms.DataGridView();
            this.TablePlayer = new System.Windows.Forms.DataGridView();
            this.TableInfoPlayer = new System.Windows.Forms.DataGridView();
            this.etap1 = new System.Windows.Forms.ListBox();
            this.etap2 = new System.Windows.Forms.ListBox();
            this.etap3 = new System.Windows.Forms.ListBox();
            this.etap4 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.TimeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoTimeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableInfoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "load_click";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TimeTable
            // 
            this.TimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TimeTable.Location = new System.Drawing.Point(1, 0);
            this.TimeTable.Name = "TimeTable";
            this.TimeTable.Size = new System.Drawing.Size(256, 165);
            this.TimeTable.TabIndex = 1;
            this.TimeTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TimeTable_CellContentClick);
            // 
            // InfoTimeTable
            // 
            this.InfoTimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoTimeTable.Location = new System.Drawing.Point(1, 171);
            this.InfoTimeTable.Name = "InfoTimeTable";
            this.InfoTimeTable.Size = new System.Drawing.Size(408, 73);
            this.InfoTimeTable.TabIndex = 2;
            // 
            // TablePlayer
            // 
            this.TablePlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablePlayer.Location = new System.Drawing.Point(286, 0);
            this.TablePlayer.Name = "TablePlayer";
            this.TablePlayer.Size = new System.Drawing.Size(382, 165);
            this.TablePlayer.TabIndex = 3;
            // 
            // TableInfoPlayer
            // 
            this.TableInfoPlayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableInfoPlayer.Location = new System.Drawing.Point(415, 171);
            this.TableInfoPlayer.Name = "TableInfoPlayer";
            this.TableInfoPlayer.Size = new System.Drawing.Size(358, 73);
            this.TableInfoPlayer.TabIndex = 4;
            this.TableInfoPlayer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableInfoPlayer_CellContentClick);
            // 
            // etap1
            // 
            this.etap1.FormattingEnabled = true;
            this.etap1.Location = new System.Drawing.Point(1, 292);
            this.etap1.Name = "etap1";
            this.etap1.Size = new System.Drawing.Size(217, 43);
            this.etap1.TabIndex = 5;
            // 
            // etap2
            // 
            this.etap2.FormattingEnabled = true;
            this.etap2.Location = new System.Drawing.Point(1, 367);
            this.etap2.Name = "etap2";
            this.etap2.Size = new System.Drawing.Size(217, 43);
            this.etap2.TabIndex = 6;
            this.etap2.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // etap3
            // 
            this.etap3.FormattingEnabled = true;
            this.etap3.Location = new System.Drawing.Point(1, 517);
            this.etap3.Name = "etap3";
            this.etap3.Size = new System.Drawing.Size(217, 43);
            this.etap3.TabIndex = 7;
            // 
            // etap4
            // 
            this.etap4.FormattingEnabled = true;
            this.etap4.Location = new System.Drawing.Point(1, 442);
            this.etap4.Name = "etap4";
            this.etap4.Size = new System.Drawing.Size(217, 43);
            this.etap4.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Группа А";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Группа D";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Группа В";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Группа С";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(224, 342);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(217, 43);
            this.listBox1.TabIndex = 13;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(224, 459);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(217, 43);
            this.listBox2.TabIndex = 14;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(448, 394);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(211, 56);
            this.listBox3.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 588);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.etap4);
            this.Controls.Add(this.etap3);
            this.Controls.Add(this.etap2);
            this.Controls.Add(this.etap1);
            this.Controls.Add(this.TableInfoPlayer);
            this.Controls.Add(this.TablePlayer);
            this.Controls.Add(this.InfoTimeTable);
            this.Controls.Add(this.TimeTable);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoTimeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TablePlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableInfoPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView TimeTable;
        private System.Windows.Forms.DataGridView InfoTimeTable;
        private System.Windows.Forms.DataGridView TablePlayer;
        private System.Windows.Forms.DataGridView TableInfoPlayer;
        private System.Windows.Forms.ListBox etap1;
        private System.Windows.Forms.ListBox etap2;
        private System.Windows.Forms.ListBox etap3;
        private System.Windows.Forms.ListBox etap4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
    }
}

