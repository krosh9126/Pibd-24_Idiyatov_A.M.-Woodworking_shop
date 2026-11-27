namespace Woodworking_shop.Forms;

partial class FormProductChartReport
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
        dateTimePicker = new DateTimePicker();
        buttonSelectFile = new Button();
        buttonBuild = new Button();
        labelDate = new Label();
        labelFile = new Label();
        labelFileName = new Label();
        SuspendLayout();
        // 
        // dateTimePicker
        // 
        dateTimePicker.Location = new Point(30, 60);
        dateTimePicker.Name = "dateTimePicker";
        dateTimePicker.Size = new Size(300, 31);
        dateTimePicker.TabIndex = 1;
        // 
        // buttonSelectFile
        // 
        buttonSelectFile.Location = new Point(30, 150);
        buttonSelectFile.Name = "buttonSelectFile";
        buttonSelectFile.Size = new Size(150, 40);
        buttonSelectFile.TabIndex = 4;
        buttonSelectFile.Text = "Выбрать файл";
        buttonSelectFile.Click += ButtonSelectFile_Click;
        // 
        // buttonBuild
        // 
        buttonBuild.Location = new Point(30, 210);
        buttonBuild.Name = "buttonBuild";
        buttonBuild.Size = new Size(220, 40);
        buttonBuild.TabIndex = 5;
        buttonBuild.Text = "Сформировать PDF";
        buttonBuild.Click += ButtonBuild_Click;
        // 
        // labelDate
        // 
        labelDate.AutoSize = true;
        labelDate.Location = new Point(30, 30);
        labelDate.Name = "labelDate";
        labelDate.Size = new Size(49, 25);
        labelDate.TabIndex = 0;
        labelDate.Text = "Дата";
        // 
        // labelFile
        // 
        labelFile.AutoSize = true;
        labelFile.Location = new Point(30, 110);
        labelFile.Name = "labelFile";
        labelFile.Size = new Size(57, 25);
        labelFile.TabIndex = 2;
        labelFile.Text = "Файл:";
        // 
        // labelFileName
        // 
        labelFileName.AutoSize = true;
        labelFileName.Location = new Point(90, 110);
        labelFileName.Name = "labelFileName";
        labelFileName.Size = new Size(99, 25);
        labelFileName.TabIndex = 3;
        labelFileName.Text = "не выбран";
        // 
        // FormProductChartReport
        // 
        ClientSize = new Size(400, 290);
        Controls.Add(labelDate);
        Controls.Add(dateTimePicker);
        Controls.Add(labelFile);
        Controls.Add(labelFileName);
        Controls.Add(buttonSelectFile);
        Controls.Add(buttonBuild);
        Name = "FormProductChartReport";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Распределение изделий";
        ResumeLayout(false);
        PerformLayout();
    }

    private DateTimePicker dateTimePicker;
    private Button buttonSelectFile;
    private Button buttonBuild;
    private Label labelDate;
    private Label labelFile;
    private Label labelFileName;
}
