namespace BookScraper
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBookById = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBookById
            // 
            this.btnBookById.Location = new System.Drawing.Point(321, 66);
            this.btnBookById.Name = "btnBookById";
            this.btnBookById.Size = new System.Drawing.Size(155, 36);
            this.btnBookById.TabIndex = 0;
            this.btnBookById.Text = "Request by ID";
            this.btnBookById.UseVisualStyleBackColor = true;
            this.btnBookById.Click += new System.EventHandler(this.btnBookById_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBookById);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBookById;
    }
}

