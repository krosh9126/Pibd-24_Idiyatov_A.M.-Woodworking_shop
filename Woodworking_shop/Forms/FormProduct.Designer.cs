namespace Woodworking_shop.Forms
{
    partial class FormProduct
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
            textBoxName = new TextBox();
            comboBoxCategory = new ComboBox();
            numericUpDownPrice = new NumericUpDown();
            numericUpDownQty = new NumericUpDown();
            labelProduct = new Label();
            labelCategory = new Label();
            labelPrice = new Label();
            labelQty = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(409, 55);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(241, 31);
            textBoxName.TabIndex = 0;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(409, 120);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(182, 33);
            comboBoxCategory.TabIndex = 1;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(411, 236);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(180, 31);
            numericUpDownPrice.TabIndex = 2;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.DecimalPlaces = 2;
            numericUpDownQty.Location = new Point(411, 302);
            numericUpDownQty.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(180, 31);
            numericUpDownQty.TabIndex = 3;
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(175, 55);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(164, 25);
            labelProduct.TabIndex = 4;
            labelProduct.Text = "Название изделия:";
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(216, 128);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(134, 25);
            labelCategory.TabIndex = 5;
            labelCategory.Text = "Вид категории:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(284, 236);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(57, 25);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Цена:";
            // 
            // labelQty
            // 
            labelQty.AutoSize = true;
            labelQty.Location = new Point(230, 307);
            labelQty.Name = "labelQty";
            labelQty.Size = new Size(111, 25);
            labelQty.TabIndex = 7;
            labelQty.Text = "Количество:";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(177, 404);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(495, 404);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(labelQty);
            Controls.Add(labelPrice);
            Controls.Add(labelCategory);
            Controls.Add(labelProduct);
            Controls.Add(numericUpDownQty);
            Controls.Add(numericUpDownPrice);
            Controls.Add(comboBoxCategory);
            Controls.Add(textBoxName);
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Изделие";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private ComboBox comboBoxCategory;
        private NumericUpDown numericUpDownPrice;
        private NumericUpDown numericUpDownQty;
        private Label labelProduct;
        private Label labelCategory;
        private Label labelPrice;
        private Label labelQty;
        private Button buttonSave;
        private Button buttonCancel;
    }
}