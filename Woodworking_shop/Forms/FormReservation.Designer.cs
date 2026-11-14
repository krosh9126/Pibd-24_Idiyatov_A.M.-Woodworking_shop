namespace Woodworking_shop.Forms
{
    partial class FormReservation
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
            comboBoxOrder = new ComboBox();
            comboBoxMaterial = new ComboBox();
            numericUpDownQty = new NumericUpDown();
            buttonCancel = new Button();
            buttonSave = new Button();
            labelOrder = new Label();
            labelMaterial = new Label();
            labelQuantity = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).BeginInit();
            SuspendLayout();
            // 
            // comboBoxOrder
            // 
            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(270, 91);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(182, 33);
            comboBoxOrder.TabIndex = 0;
            // 
            // comboBoxMaterial
            // 
            comboBoxMaterial.FormattingEnabled = true;
            comboBoxMaterial.Location = new Point(270, 181);
            comboBoxMaterial.Name = "comboBoxMaterial";
            comboBoxMaterial.Size = new Size(182, 33);
            comboBoxMaterial.TabIndex = 1;
            // 
            // numericUpDownQty
            // 
            numericUpDownQty.DecimalPlaces = 2;
            numericUpDownQty.Location = new Point(272, 283);
            numericUpDownQty.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDownQty.Name = "numericUpDownQty";
            numericUpDownQty.Size = new Size(180, 31);
            numericUpDownQty.TabIndex = 2;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(473, 404);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(112, 34);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(155, 404);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(112, 34);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Location = new Point(167, 91);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(61, 25);
            labelOrder.TabIndex = 12;
            labelOrder.Text = "Заказ:";
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Location = new Point(132, 181);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(96, 25);
            labelMaterial.TabIndex = 13;
            labelMaterial.Text = "Материал:";
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(117, 283);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(111, 25);
            labelQuantity.TabIndex = 14;
            labelQuantity.Text = "Количество:";
            // 
            // FormReservation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(722, 450);
            Controls.Add(labelQuantity);
            Controls.Add(labelMaterial);
            Controls.Add(labelOrder);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(numericUpDownQty);
            Controls.Add(comboBoxMaterial);
            Controls.Add(comboBoxOrder);
            Name = "FormReservation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Резерв";
            ((System.ComponentModel.ISupportInitialize)numericUpDownQty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxOrder;
        private ComboBox comboBoxMaterial;
        private NumericUpDown numericUpDownQty;
        private Button buttonCancel;
        private Button buttonSave;
        private Label labelOrder;
        private Label labelMaterial;
        private Label labelQuantity;
    }
}