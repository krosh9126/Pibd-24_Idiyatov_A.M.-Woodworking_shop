namespace Woodworking_shop.Forms;

partial class FormProductReport
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
        comboBoxProduct = new ComboBox();
        dateTimePickerBegin = new DateTimePicker();
        dateTimePickerEnd = new DateTimePicker();
        textBoxFilePath = new TextBox();
        buttonSelectFile = new Button();
        buttonBuild = new Button();
        labelProduct = new Label();
        labelBegin = new Label();
        labelEnd = new Label();
        labelFile = new Label();
        SuspendLayout();

        labelProduct.AutoSize = true;
        labelProduct.Location = new Point(30, 25);
        labelProduct.Text = "Изделие";

        comboBoxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
        comboBoxProduct.Location = new Point(30, 50);
        comboBoxProduct.Size = new Size(340, 33);

        labelBegin.AutoSize = true;
        labelBegin.Location = new Point(30, 95);
        labelBegin.Text = "Дата начала";

        dateTimePickerBegin.Location = new Point(30, 120);
        dateTimePickerBegin.Size = new Size(340, 31);

        labelEnd.AutoSize = true;
        labelEnd.Location = new Point(30, 165);
        labelEnd.Text = "Дата окончания";

        dateTimePickerEnd.Location = new Point(30, 190);
        dateTimePickerEnd.Size = new Size(340, 31);

        labelFile.AutoSize = true;
        labelFile.Location = new Point(30, 235);
        labelFile.Text = "Файл отчета";

        textBoxFilePath.Location = new Point(30, 260);
        textBoxFilePath.Size = new Size(340, 31);

        buttonSelectFile.Location = new Point(390, 258);
        buttonSelectFile.Size = new Size(130, 35);
        buttonSelectFile.Text = "Выбрать";
        buttonSelectFile.Click += ButtonSelectFile_Click;

        buttonBuild.Location = new Point(30, 315);
        buttonBuild.Size = new Size(220, 40);
        buttonBuild.Text = "Сформировать Excel";
        buttonBuild.Click += ButtonBuild_Click;

        ClientSize = new Size(560, 390);
        Controls.Add(labelProduct);
        Controls.Add(comboBoxProduct);
        Controls.Add(labelBegin);
        Controls.Add(dateTimePickerBegin);
        Controls.Add(labelEnd);
        Controls.Add(dateTimePickerEnd);
        Controls.Add(labelFile);
        Controls.Add(textBoxFilePath);
        Controls.Add(buttonSelectFile);
        Controls.Add(buttonBuild);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Отчет по изделию";
        ResumeLayout(false);
        PerformLayout();
    }

    private ComboBox comboBoxProduct;
    private DateTimePicker dateTimePickerBegin;
    private DateTimePicker dateTimePickerEnd;
    private TextBox textBoxFilePath;
    private Button buttonSelectFile;
    private Button buttonBuild;
    private Label labelProduct;
    private Label labelBegin;
    private Label labelEnd;
    private Label labelFile;
}
