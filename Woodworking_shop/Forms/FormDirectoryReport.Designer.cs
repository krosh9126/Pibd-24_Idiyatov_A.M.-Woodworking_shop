namespace Woodworking_shop.Forms;

partial class FormDirectoryReport
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        checkBoxProducts = new CheckBox();
        checkBoxMaterials = new CheckBox();
        buttonBuild = new Button();
        SuspendLayout();

        checkBoxProducts.AutoSize = true;
        checkBoxProducts.Location = new Point(35, 35);
        checkBoxProducts.Text = "Изделия";
        checkBoxProducts.Checked = true;

        checkBoxMaterials.AutoSize = true;
        checkBoxMaterials.Location = new Point(35, 75);
        checkBoxMaterials.Text = "Материалы";
        checkBoxMaterials.Checked = true;

        buttonBuild.Location = new Point(35, 125);
        buttonBuild.Size = new Size(220, 40);
        buttonBuild.Text = "Сформировать Word";
        buttonBuild.Click += ButtonBuild_Click;

        ClientSize = new Size(300, 210);
        Controls.Add(checkBoxProducts);
        Controls.Add(checkBoxMaterials);
        Controls.Add(buttonBuild);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Отчет по справочникам";
        ResumeLayout(false);
        PerformLayout();
    }

    private CheckBox checkBoxProducts;
    private CheckBox checkBoxMaterials;
    private Button buttonBuild;
}
