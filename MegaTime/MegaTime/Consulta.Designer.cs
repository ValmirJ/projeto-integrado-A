namespace MegaTime
{
    partial class Consulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bt_consultar = new System.Windows.Forms.Button();
            this.bt_return = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(45, 48);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // bt_consultar
            // 
            this.bt_consultar.BackColor = System.Drawing.Color.White;
            this.bt_consultar.FlatAppearance.BorderSize = 0;
            this.bt_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_consultar.ForeColor = System.Drawing.Color.Black;
            this.bt_consultar.Location = new System.Drawing.Point(217, 48);
            this.bt_consultar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_consultar.Name = "bt_consultar";
            this.bt_consultar.Size = new System.Drawing.Size(74, 24);
            this.bt_consultar.TabIndex = 2;
            this.bt_consultar.Text = "Consultar";
            this.bt_consultar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_consultar.UseVisualStyleBackColor = false;
            this.bt_consultar.Click += new System.EventHandler(this.bt_consultar_Click);
            // 
            // bt_return
            // 
            this.bt_return.BackColor = System.Drawing.Color.Transparent;
            this.bt_return.FlatAppearance.BorderSize = 0;
            this.bt_return.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_return.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_return.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_return.Image = ((System.Drawing.Image)(resources.GetObject("bt_return.Image")));
            this.bt_return.Location = new System.Drawing.Point(5, 5);
            this.bt_return.Name = "bt_return";
            this.bt_return.Size = new System.Drawing.Size(32, 29);
            this.bt_return.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bt_return, "Clique aqui para voltar!");
            this.bt_return.UseVisualStyleBackColor = false;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(337, 101);
            this.ControlBox = false;
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.bt_consultar);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Consulta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bt_consultar;
        private System.Windows.Forms.Button bt_return;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}