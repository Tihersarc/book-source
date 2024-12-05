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
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.numPages = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddToDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBookById
            // 
            this.btnBookById.Location = new System.Drawing.Point(192, 12);
            this.btnBookById.Name = "btnBookById";
            this.btnBookById.Size = new System.Drawing.Size(155, 34);
            this.btnBookById.TabIndex = 0;
            this.btnBookById.Text = "Request by ID";
            this.btnBookById.UseVisualStyleBackColor = true;
            this.btnBookById.Click += new System.EventHandler(this.btnBookById_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(12, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(160, 26);
            this.txtId.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(192, 79);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(155, 34);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Request by Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 83);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(160, 26);
            this.txtQuery.TabIndex = 3;
            this.txtQuery.Text = "BcG2dVRXKukC";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(374, 12);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersWidth = 62;
            this.dgvBooks.RowTemplate.Height = 28;
            this.dgvBooks.Size = new System.Drawing.Size(414, 426);
            this.dgvBooks.TabIndex = 4;
            // 
            // numPages
            // 
            this.numPages.Location = new System.Drawing.Point(12, 153);
            this.numPages.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPages.Name = "numPages";
            this.numPages.Size = new System.Drawing.Size(120, 26);
            this.numPages.TabIndex = 5;
            this.numPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Number of pages";
            // 
            // btnAddToDB
            // 
            this.btnAddToDB.Location = new System.Drawing.Point(12, 404);
            this.btnAddToDB.Name = "btnAddToDB";
            this.btnAddToDB.Size = new System.Drawing.Size(335, 34);
            this.btnAddToDB.TabIndex = 7;
            this.btnAddToDB.Text = "Add Query to DB";
            this.btnAddToDB.UseVisualStyleBackColor = true;
            this.btnAddToDB.Click += new System.EventHandler(this.btnAddToDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddToDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPages);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnBookById);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBookById;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.NumericUpDown numPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddToDB;
    }
}

