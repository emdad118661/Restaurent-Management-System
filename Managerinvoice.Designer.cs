
namespace Resturentsystem
{
    partial class Managerinvoice
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
            this.Search = new System.Windows.Forms.TextBox();
            this.ManagerinvoiceGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ManagerinvoiceGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search By Name";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(43, 103);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(281, 20);
            this.Search.TabIndex = 1;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // ManagerinvoiceGridView
            // 
            this.ManagerinvoiceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManagerinvoiceGridView.Location = new System.Drawing.Point(12, 204);
            this.ManagerinvoiceGridView.Name = "ManagerinvoiceGridView";
            this.ManagerinvoiceGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ManagerinvoiceGridView.Size = new System.Drawing.Size(555, 234);
            this.ManagerinvoiceGridView.TabIndex = 2;
            this.ManagerinvoiceGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManagerinvoiceGridView_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Managerinvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ManagerinvoiceGridView);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Managerinvoice";
            this.Text = "Managerinvoice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Managerinvoice_FormClosing);
            this.Load += new System.EventHandler(this.Managerinvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ManagerinvoiceGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.DataGridView ManagerinvoiceGridView;
        private System.Windows.Forms.Button button1;
    }
}