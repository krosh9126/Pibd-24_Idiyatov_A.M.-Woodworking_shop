using Unity;
using Woodworking_shop.Reports;

namespace Woodworking_shop.Forms;

public partial class FormDirectoryReport : Form
{
    private readonly IUnityContainer _container;

    public FormDirectoryReport(IUnityContainer container)
    {
        InitializeComponent();
        _container = container ?? throw new ArgumentNullException(nameof(container));
    }

    private void ButtonBuild_Click(object sender, EventArgs e)
    {
        try
        {
            if (!checkBoxProducts.Checked && !checkBoxMaterials.Checked)
                throw new Exception("Не выбран ни один справочник.");

            using var dialog = new SaveFileDialog
            {
                Filter = "Word Files (*.docx)|*.docx",
                DefaultExt = "docx",
                AddExtension = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var result = _container.Resolve<WordReport>().CreateDoc(
                dialog.FileName,
                checkBoxProducts.Checked,
                checkBoxMaterials.Checked);

            MessageBox.Show(
                result
                    ? "Документ сформирован."
                    : "Возникли ошибки при формировании документа. Подробности в логах.",
                "Формирование Word-отчета",
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
