namespace MegaTime
{
    partial class Recibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recibo));
            this.folha = new System.Windows.Forms.Label();
            this.lbl_premio = new System.Windows.Forms.Label();
            this.bt_print = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folha
            // 
            this.folha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.folha.Location = new System.Drawing.Point(13, 7);
            this.folha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.folha.Name = "folha";
            this.folha.Size = new System.Drawing.Size(324, 350);
            this.folha.TabIndex = 0;
            this.folha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_premio
            // 
            this.lbl_premio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_premio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_premio.Location = new System.Drawing.Point(12, 357);
            this.lbl_premio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_premio.Name = "lbl_premio";
            this.lbl_premio.Size = new System.Drawing.Size(324, 132);
            this.lbl_premio.TabIndex = 1;
            this.lbl_premio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bt_print
            // 
            this.bt_print.FlatAppearance.BorderSize = 0;
            this.bt_print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_print.Image = ((System.Drawing.Image)(resources.GetObject("bt_print.Image")));
            this.bt_print.Location = new System.Drawing.Point(274, 488);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(60, 47);
            this.bt_print.TabIndex = 2;
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // Recibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 547);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.lbl_premio);
            this.Controls.Add(this.folha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "Recibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo";
            this.Load += new System.EventHandler(this.Recibo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label folha;
        private System.Windows.Forms.Label lbl_premio;
        private System.Windows.Forms.Button bt_print;


    }
}