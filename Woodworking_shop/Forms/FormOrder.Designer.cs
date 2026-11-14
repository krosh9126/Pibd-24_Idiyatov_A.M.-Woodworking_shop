namespace Woodworking_shop.Forms
{
    partial class FormOrder
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
            textBoxClient = new TextBox();
            textBoxType = new TextBox();
            dataGridViewItems = new DataGridView();
            labelClient = new Label();
            labelType = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            groupBoxItems = new GroupBox();
            ColumnProduct = new DataGridViewComboBoxColumn();
            ColumnQuantity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).BeginInit();
            groupBoxItems.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxClient
            // 
            textBoxClient.Location = new Point(209, 12);
            textBoxClient.Name = "textBoxClient";
            textBoxClient.Size = new Size(345, 31);
            textBoxClient.TabIndex = 0;
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(209, 85);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(345, 31);
            textBoxType.TabIndex = 1;
            // 
            // dataGridViewItems
            // 
            dataGridViewItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItems.Columns.AddRange(new DataGridViewColumn[] { ColumnProduct, ColumnQuantity });
            dataGridViewItems.Dock = DockStyle.Fill;
            dataGridViewItems.Location = new Point(3, 27);
            dataGridViewItems.Name = "dataGridViewItems";
            dataGridViewItems.RowHeadersVisible = false;
            dataGridViewItems.RowHeadersWidth = 62;
            dataGridViewItems.Size = new Size(453, 262);
            dataGridViewItems.TabIndex = 2;
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Location = new Point(95, 18);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(71, 25);
            labelClient.TabIndex = 3;
            labelClient.Text = "Клиент:";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(64, 91);
            labelType.Name = "labelType";
            labelType.Size = new Size(102, 25);
            labelType.TabIndex = 4;
            labelType.Text = "Тип заказа:";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(484, 448);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(166, 448);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // groupBoxItems
            // 
            groupBoxItems.Controls.Add(dataGridViewItems);
            groupBoxItems.Location = new Point(147, 150);
            groupBoxItems.Name = "groupBoxItems";
            groupBoxItems.Size = new Size(459, 292);
            groupBoxItems.TabIndex = 12;
            groupBoxItems.TabStop = false;
            groupBoxItems.Text = "Изделия";
            // 
            // ColumnProduct
            // 
            ColumnProduct.HeaderText = "Изделия";
            ColumnProduct.MinimumWidth = 8;
            ColumnProduct.Name = "ColumnProduct";
            ColumnProduct.Resizable = DataGridViewTriState.True;
            ColumnProduct.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnQuantity
            // 
            ColumnQuantity.HeaderText = "Количество";
            ColumnQuantity.MinimumWidth = 8;
            ColumnQuantity.Name = "ColumnQuantity";
            // 
            // FormOrder
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 494);
            Controls.Add(groupBoxItems);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelType);
            Controls.Add(labelClient);
            Controls.Add(textBoxType);
            Controls.Add(textBoxClient);
            Name = "FormOrder";
            Text = "FormOrder";
            ((System.ComponentModel.ISupportInitialize)dataGridViewItems).EndInit();
            groupBoxItems.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxClient;
        private TextBox textBoxType;
        private DataGridView dataGridViewItems;
        private Label labelClient;
        private Label labelType;
        private Button buttonCancel;
        private Button buttonSave;
        private GroupBox groupBoxItems;
        private DataGridViewComboBoxColumn ColumnProduct;
        private DataGridViewTextBoxColumn ColumnQuantity;
    }
}