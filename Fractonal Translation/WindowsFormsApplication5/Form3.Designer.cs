namespace WindowsFormsApplication5
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.brnOk = new System.Windows.Forms.Button();
            this.tbxLogin = new System.Windows.Forms.TextBox();
            this.tbxPasword1 = new System.Windows.Forms.TextBox();
            this.tbxPasword2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Повторите пароль";
            // 
            // brnOk
            // 
            this.brnOk.Location = new System.Drawing.Point(269, 241);
            this.brnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.brnOk.Name = "brnOk";
            this.brnOk.Size = new System.Drawing.Size(180, 28);
            this.brnOk.TabIndex = 3;
            this.brnOk.Text = "Подтвердить ввод";
            this.brnOk.UseVisualStyleBackColor = true;
            this.brnOk.Click += new System.EventHandler(this.brnOk_Click);
            // 
            // tbxLogin
            // 
            this.tbxLogin.Location = new System.Drawing.Point(269, 55);
            this.tbxLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLogin.Name = "tbxLogin";
            this.tbxLogin.Size = new System.Drawing.Size(180, 22);
            this.tbxLogin.TabIndex = 4;
            // 
            // tbxPasword1
            // 
            this.tbxPasword1.Location = new System.Drawing.Point(269, 100);
            this.tbxPasword1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPasword1.Name = "tbxPasword1";
            this.tbxPasword1.Size = new System.Drawing.Size(180, 22);
            this.tbxPasword1.TabIndex = 5;
            this.tbxPasword1.TextChanged += new System.EventHandler(this.tbxPasword1_TextChanged);
            this.tbxPasword1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPasword1_KeyPress);
            // 
            // tbxPasword2
            // 
            this.tbxPasword2.Location = new System.Drawing.Point(269, 161);
            this.tbxPasword2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPasword2.Name = "tbxPasword2";
            this.tbxPasword2.Size = new System.Drawing.Size(180, 22);
            this.tbxPasword2.TabIndex = 6;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 434);
            this.Controls.Add(this.tbxPasword2);
            this.Controls.Add(this.tbxPasword1);
            this.Controls.Add(this.tbxLogin);
            this.Controls.Add(this.brnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fractional translation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button brnOk;
        private System.Windows.Forms.TextBox tbxLogin;
        private System.Windows.Forms.TextBox tbxPasword1;
        private System.Windows.Forms.TextBox tbxPasword2;
    }
}