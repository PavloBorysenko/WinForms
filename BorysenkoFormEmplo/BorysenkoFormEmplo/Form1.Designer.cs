namespace BorysenkoFormEmplo
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.proiz = new System.Windows.Forms.RadioButton();
            this.inge = new System.Windows.Forms.RadioButton();
            this.mark = new System.Windows.Forms.RadioButton();
            this.listEmpl = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.proiz);
            this.groupBox1.Controls.Add(this.inge);
            this.groupBox1.Controls.Add(this.mark);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отделы";
            // 
            // proiz
            // 
            this.proiz.AutoSize = true;
            this.proiz.Location = new System.Drawing.Point(7, 93);
            this.proiz.Name = "proiz";
            this.proiz.Size = new System.Drawing.Size(124, 17);
            this.proiz.TabIndex = 2;
            this.proiz.TabStop = true;
            this.proiz.Text = "Производственный";
            this.proiz.UseVisualStyleBackColor = true;
            this.proiz.CheckedChanged += new System.EventHandler(this.proiz_CheckedChanged);
            // 
            // inge
            // 
            this.inge.AutoSize = true;
            this.inge.Location = new System.Drawing.Point(7, 55);
            this.inge.Name = "inge";
            this.inge.Size = new System.Drawing.Size(91, 17);
            this.inge.TabIndex = 1;
            this.inge.TabStop = true;
            this.inge.Text = "Инженерный";
            this.inge.UseVisualStyleBackColor = true;
            this.inge.CheckedChanged += new System.EventHandler(this.inge_CheckedChanged);
            // 
            // mark
            // 
            this.mark.AutoSize = true;
            this.mark.Location = new System.Drawing.Point(7, 20);
            this.mark.Name = "mark";
            this.mark.Size = new System.Drawing.Size(106, 17);
            this.mark.TabIndex = 0;
            this.mark.TabStop = true;
            this.mark.Text = "Маркетинговый";
            this.mark.UseVisualStyleBackColor = true;
            this.mark.CheckedChanged += new System.EventHandler(this.mark_CheckedChanged);
            // 
            // listEmpl
            // 
            this.listEmpl.FormattingEnabled = true;
            this.listEmpl.Location = new System.Drawing.Point(12, 145);
            this.listEmpl.Name = "listEmpl";
            this.listEmpl.Size = new System.Drawing.Size(138, 199);
            this.listEmpl.TabIndex = 1;
            this.listEmpl.SelectedIndexChanged += new System.EventHandler(this.listEmpl_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(371, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 198);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(281, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 65);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(553, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 65);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(371, 229);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 74);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(281, 215);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Показать";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(631, 355);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listEmpl);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton proiz;
        private System.Windows.Forms.RadioButton inge;
        private System.Windows.Forms.RadioButton mark;
        private System.Windows.Forms.ListBox listEmpl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

