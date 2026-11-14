namespace Woodworking_shop.Forms
{
    partial class FormReservations
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
            dataGridViewData = new DataGridView();
            panel = new Panel();
            buttonAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewData
            // 
            dataGridViewData.AllowUserToAddRows = false;
            dataGridViewData.AllowUserToDeleteRows = false;
            dataGridViewData.AllowUserToResizeColumns = false;
            dataGridViewData.AllowUserToResizeRows = false;
            dataGridViewData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Dock = DockStyle.Fill;
            dataGridViewData.Location = new Point(0, 0);
            dataGridViewData.MultiSelect = false;
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.ReadOnly = true;
            dataGridViewData.RowHeadersVisible = false;
            dataGridViewData.RowHeadersWidth = 62;
            dataGridViewData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewData.Size = new Size(620, 450);
            dataGridViewData.TabIndex = 2;
            // 
            // panel
            // 
            panel.Controls.Add(buttonAdd);
            panel.Dock = DockStyle.Right;
            panel.Location = new Point(620, 0);
            panel.Name = "panel";
            panel.Size = new Size(180, 450);
            panel.TabIndex = 3;
            // 
            // buttonAdd
            // 
            buttonAdd.BackgroundImage = Properties.Resources.add;
            buttonAdd.BackgroundImageLayout = ImageLayout.Zoom;
            buttonAdd.Location = new Point(28, 175);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(127, 111);
            buttonAdd.TabIndex = 0;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // FormReservations
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewData);
            Controls.Add(panel);
            Name = "FormReservations";
            Text = "Резервы";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewData;
        private Panel panel;
        private Button buttonAdd;
    }
}