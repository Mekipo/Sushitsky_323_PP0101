
namespace Sklad
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxCriticalLevel = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.panelAddProduct = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelAdd = new System.Windows.Forms.Button();
            this.buttonConfirmAdd = new System.Windows.Forms.Button();
            this.textBoxAddCriticalLevel = new System.Windows.Forms.TextBox();
            this.textBoxAddQuantity = new System.Windows.Forms.TextBox();
            this.textBoxAddName = new System.Windows.Forms.TextBox();
            this.checkBoxShowCritical = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.panelAddProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(42, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.Size = new System.Drawing.Size(384, 393);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(42, 435);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 56);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(177, 435);
            this.textBoxQuantity.Multiline = true;
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(119, 57);
            this.textBoxQuantity.TabIndex = 3;
            // 
            // textBoxCriticalLevel
            // 
            this.textBoxCriticalLevel.Location = new System.Drawing.Point(307, 435);
            this.textBoxCriticalLevel.Multiline = true;
            this.textBoxCriticalLevel.Name = "textBoxCriticalLevel";
            this.textBoxCriticalLevel.Size = new System.Drawing.Size(119, 57);
            this.textBoxCriticalLevel.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(42, 498);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(138, 499);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 7;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(244, 498);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Location = new System.Drawing.Point(351, 498);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonExportExcel.TabIndex = 9;
            this.buttonExportExcel.Text = "Экспорт";
            this.buttonExportExcel.UseVisualStyleBackColor = true;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // panelAddProduct
            // 
            this.panelAddProduct.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelAddProduct.Controls.Add(this.label3);
            this.panelAddProduct.Controls.Add(this.label2);
            this.panelAddProduct.Controls.Add(this.label1);
            this.panelAddProduct.Controls.Add(this.buttonCancelAdd);
            this.panelAddProduct.Controls.Add(this.buttonConfirmAdd);
            this.panelAddProduct.Controls.Add(this.textBoxAddCriticalLevel);
            this.panelAddProduct.Controls.Add(this.textBoxAddQuantity);
            this.panelAddProduct.Controls.Add(this.textBoxAddName);
            this.panelAddProduct.Location = new System.Drawing.Point(0, 1);
            this.panelAddProduct.Name = "panelAddProduct";
            this.panelAddProduct.Size = new System.Drawing.Size(529, 604);
            this.panelAddProduct.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Критическиий уровень";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название";
            // 
            // buttonCancelAdd
            // 
            this.buttonCancelAdd.Location = new System.Drawing.Point(503, 7);
            this.buttonCancelAdd.Name = "buttonCancelAdd";
            this.buttonCancelAdd.Size = new System.Drawing.Size(23, 23);
            this.buttonCancelAdd.TabIndex = 4;
            this.buttonCancelAdd.Text = "Х";
            this.buttonCancelAdd.UseVisualStyleBackColor = true;
            // 
            // buttonConfirmAdd
            // 
            this.buttonConfirmAdd.Location = new System.Drawing.Point(212, 381);
            this.buttonConfirmAdd.Name = "buttonConfirmAdd";
            this.buttonConfirmAdd.Size = new System.Drawing.Size(136, 39);
            this.buttonConfirmAdd.TabIndex = 3;
            this.buttonConfirmAdd.Text = "Добавить";
            this.buttonConfirmAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxAddCriticalLevel
            // 
            this.textBoxAddCriticalLevel.Location = new System.Drawing.Point(212, 294);
            this.textBoxAddCriticalLevel.Multiline = true;
            this.textBoxAddCriticalLevel.Name = "textBoxAddCriticalLevel";
            this.textBoxAddCriticalLevel.Size = new System.Drawing.Size(136, 39);
            this.textBoxAddCriticalLevel.TabIndex = 2;
            // 
            // textBoxAddQuantity
            // 
            this.textBoxAddQuantity.Location = new System.Drawing.Point(212, 223);
            this.textBoxAddQuantity.Multiline = true;
            this.textBoxAddQuantity.Name = "textBoxAddQuantity";
            this.textBoxAddQuantity.Size = new System.Drawing.Size(136, 39);
            this.textBoxAddQuantity.TabIndex = 1;
            // 
            // textBoxAddName
            // 
            this.textBoxAddName.Location = new System.Drawing.Point(212, 153);
            this.textBoxAddName.Multiline = true;
            this.textBoxAddName.Name = "textBoxAddName";
            this.textBoxAddName.Size = new System.Drawing.Size(136, 39);
            this.textBoxAddName.TabIndex = 0;
            // 
            // checkBoxShowCritical
            // 
            this.checkBoxShowCritical.AutoSize = true;
            this.checkBoxShowCritical.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxShowCritical.Location = new System.Drawing.Point(432, 12);
            this.checkBoxShowCritical.Name = "checkBoxShowCritical";
            this.checkBoxShowCritical.Size = new System.Drawing.Size(97, 19);
            this.checkBoxShowCritical.TabIndex = 12;
            this.checkBoxShowCritical.Text = "Критические";
            this.checkBoxShowCritical.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(526, 600);
            this.Controls.Add(this.panelAddProduct);
            this.Controls.Add(this.checkBoxShowCritical);
            this.Controls.Add(this.buttonExportExcel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxCriticalLevel);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dataGridViewProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.panelAddProduct.ResumeLayout(false);
            this.panelAddProduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxCriticalLevel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.Panel panelAddProduct;
        private System.Windows.Forms.Button buttonCancelAdd;
        private System.Windows.Forms.Button buttonConfirmAdd;
        private System.Windows.Forms.TextBox textBoxAddCriticalLevel;
        private System.Windows.Forms.TextBox textBoxAddQuantity;
        private System.Windows.Forms.TextBox textBoxAddName;
        private System.Windows.Forms.CheckBox checkBoxShowCritical;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

