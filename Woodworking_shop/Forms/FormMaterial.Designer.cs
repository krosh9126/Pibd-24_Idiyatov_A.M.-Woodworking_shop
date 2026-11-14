namespace Woodworking_shop.Forms
{
    partial class FormMaterial
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
            textBoxUnit = new TextBox();
            labelQty = new Label();
            labelPrice = new Label();
            numericUpDownStock = new NumericUpDown();
            numericUpDownPrice = new NumericUpDown();
            labelMaterial = new Label();
            labelUnit = new Label();
            checkedListBoxType = new CheckedListBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(268, 48);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(241, 31);
            textBoxName.TabIndex = 1;
            // 
            // textBoxUnit
            // 
            textBoxUnit.Location = new Point(268, 132);
            textBoxUnit.Name = "textBoxUnit";
            textBoxUnit.Size = new Size(241, 31);
            textBoxUnit.TabIndex = 2;
            // 
            // labelQty
            // 
            labelQty.AutoSize = true;
            labelQty.Location = new Point(148, 302);
            labelQty.Name = "labelQty";
            labelQty.Size = new Size(111, 25);
            labelQty.TabIndex = 11;
            labelQty.Text = "Количество:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(202, 231);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(57, 25);
            labelPrice.TabIndex = 10;
            labelPrice.Text = "Цена:";
            // 
            // numericUpDownStock
            // 
            numericUpDownStock.DecimalPlaces = 2;
            numericUpDownStock.Location = new Point(329, 297);
            numericUpDownStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownStock.Name = "numericUpDownStock";
            numericUpDownStock.Size = new Size(180, 31);
            numericUpDownStock.TabIndex = 9;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(329, 231);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(180, 31);
            numericUpDownPrice.TabIndex = 8;
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(51, 54);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(185, 25);
            labelMaterial.TabIndex = 12;
            labelMaterial.Text = "Название материала:";
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Location = new Point(51, 138);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(179, 25);
            labelUnit.TabIndex = 13;
            labelUnit.Text = "Единица измерения:";
            // 
            // checkedListBoxType
            // 
            checkedListBoxType.FormattingEnabled = true;
            checkedListBoxType.Location = new Point(301, 368);
            checkedListBoxType.Name = "checkedListBoxType";
            checkedListBoxType.Size = new Size(180, 88);
            checkedListBoxType.TabIndex = 14;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(505, 483);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 16;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(187, 483);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 15;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // FormMaterial
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 567);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(checkedListBoxType);
            Controls.Add(labelUnit);
            Controls.Add(labelMaterial);
            Controls.Add(labelQty);
            Controls.Add(labelPrice);
            Controls.Add(numericUpDownStock);
            Controls.Add(numericUpDownPrice);
            Controls.Add(textBoxUnit);
            Controls.Add(textBoxName);
            Name = "FormMaterial";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Материал";
            ((System.ComponentModel.ISupportInitialize)numericUpDownStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxUnit;
        private Label labelQty;
        private Label labelPrice;
        private NumericUpDown numericUpDownStock;
        private NumericUpDown numericUpDownPrice;
        private Label labelMaterial;
        private Label labelUnit;
        private CheckedListBox checkedListBoxType;
        private Button buttonCancel;
        private Button buttonSave;
    }
}