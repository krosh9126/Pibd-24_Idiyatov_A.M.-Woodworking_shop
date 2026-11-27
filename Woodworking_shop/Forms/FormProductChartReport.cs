using Unity;
using Woodworking_shop.Reports.Builders;

namespace Woodworking_shop.Forms;

public partial class FormProductChartReport : Form
{
    private readonly IUnityContainer _container;
    private string _fileName = string.Empty;

    public FormProductChartReport(IUnityContainer container)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
    }

    private void ButtonSelectFile_Click(object sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "PDF Files (*.pdf)|*.pdf",
            DefaultExt = "pdf",
            AddExtension = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            _fileName = dialog.FileName;
            labelFileName.Text = Path.GetFileName(_fileName);
        }
    }

    private void ButtonBuild_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_fileName))
                throw new Exception("Не выбран файл для отчета.");

            var result = _container.Resolve<ChartReport>()
                .CreateChart(_fileName, dateTimePicker.Value.Date);

            MessageBox.Show(
                result
                    ? "PDF-документ сформирован."
                    : "Возникли ошибки при формировании документа. Подробности в логах.",
                "Формирование PDF-отчета",
                MessageBoxButtons.OK,
                result ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Ошибка при создании отчета",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
