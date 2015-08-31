namespace MegaTime
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.bt_consultar = new System.Windows.Forms.Button();
            this.bt_apostar = new System.Windows.Forms.Button();
            this.bt_close = new System.Windows.Forms.Button();
            this.tooltip_btConsultar = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // bt_consultar
            // 
            this.bt_consultar.BackColor = System.Drawing.Color.White;
            this.bt_consultar.FlatAppearance.BorderSize = 0;
            this.bt_consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_consultar.Location = new System.Drawing.Point(159, 197);
            this.bt_consultar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_consultar.Name = "bt_consultar";
            this.bt_consultar.Size = new System.Drawing.Size(140, 21);
            this.bt_consultar.TabIndex = 0;
            this.bt_consultar.Text = "Consultar apostas";
            this.tooltip_btConsultar.SetToolTip(this.bt_consultar, "Consulte resultados de apostas e apostas anteriores aqui!!");
            this.bt_consultar.UseVisualStyleBackColor = false;
            this.bt_consultar.Click += new System.EventHandler(this.bt_consultar_Click);
            // 
            // bt_apostar
            // 
            this.bt_apostar.BackColor = System.Drawing.Color.White;
            this.bt_apostar.FlatAppearance.BorderSize = 0;
            this.bt_apostar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_apostar.Location = new System.Drawing.Point(9, 197);
            this.bt_apostar.Margin = new System.Windows.Forms.Padding(2);
            this.bt_apostar.Name = "bt_apostar";
            this.bt_apostar.Size = new System.Drawing.Size(140, 21);
            this.bt_apostar.TabIndex = 1;
            this.bt_apostar.Text = "Nova aposta";
            this.bt_apostar.UseVisualStyleBackColor = false;
            this.bt_apostar.Click += new System.EventHandler(this.bt_apostar_Click);
            // 
            // bt_close
            // 
            this.bt_close.BackColor = System.Drawing.Color.White;
            this.bt_close.FlatAppearance.BorderSize = 0;
            this.bt_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_close.Location = new System.Drawing.Point(309, 197);
            this.bt_close.Margin = new System.Windows.Forms.Padding(2);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(48, 21);
            this.bt_close.TabIndex = 2;
            this.bt_close.Text = "Sair";
            this.bt_close.UseVisualStyleBackColor = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // tooltip_btConsultar
            // 
            this.tooltip_btConsultar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(368, 228);
            this.Controls.Add(this.bt_close);
            this.Controls.Add(this.bt_apostar);
            this.Controls.Add(this.bt_consultar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_consultar;
        private System.Windows.Forms.Button bt_apostar;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.ToolTip tooltip_btConsultar;
    }
}