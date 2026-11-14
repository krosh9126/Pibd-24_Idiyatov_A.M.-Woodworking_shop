namespace Woodworking_shop.Forms
{
    partial class FormProducts
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
            buttonDelete = new Button();
            buttonUpdate = new Button();
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
            dataGridViewData.TabIndex = 0;
            // 
            // panel
            // 
            panel.Controls.Add(buttonDelete);
            panel.Controls.Add(buttonUpdate);
            panel.Controls.Add(buttonAdd);
            panel.Dock = DockStyle.Right;
            panel.Location = new Point(620, 0);
            panel.Name = "panel";
            panel.Size = new Size(180, 450);
            panel.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.BackgroundImage = Properties.Resources.delete;
            buttonDelete.BackgroundImageLayout = ImageLayout.Zoom;
            buttonDelete.Location = new Point(34, 302);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(127, 108);
            buttonDelete.TabIndex = 2;
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += ButtonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackgroundImage = Properties.Resources.update;
            buttonUpdate.BackgroundImageLayout = ImageLayout.Zoom;
            buttonUpdate.Location = new Point(34, 170);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(127, 97);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += ButtonUpdate_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackgroundImage = Properties.Resources.add;
            buttonAdd.BackgroundImageLayout = ImageLayout.Zoom;
            buttonAdd.Location = new Point(34, 23);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(127, 111);
            buttonAdd.TabIndex = 0;
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += ButtonAdd_Click;
            // 
            // FormProducts
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridViewData);
            Controls.Add(panel);
            Name = "FormProducts";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Изделия";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewData;
        private Panel panel;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonAdd;
    }
}