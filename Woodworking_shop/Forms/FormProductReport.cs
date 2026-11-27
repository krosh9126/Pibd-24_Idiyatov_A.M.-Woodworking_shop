using Unity;
using Woodworking_shop.Repositories;
using Woodworking_shop.Reports;

namespace Woodworking_shop.Forms;

public partial class FormProductReport : Form
{
    private readonly IUnityContainer _container;
    private readonly IProductRepository _productRepository;

    public FormProductReport(
        IUnityContainer container,
        IProductRepository productRepository)
    {
        InitializeComponent();

        _container = container ?? throw new ArgumentNullException(nameof(container));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        comboBoxProduct.DataSource = _productRepository.ReadProducts().ToList();
        comboBoxProduct.DisplayMember = "Name";
        comboBoxProduct.ValueMember = "Id";
    }

    private void ButtonSelectFile_Click(object sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Filter = "Excel Files (*.xlsx)|*.xlsx",
            DefaultExt = "xlsx",
            AddExtension = true
        };

        if (dialog.ShowDialog() == DialogResult.OK)
            textBoxFilePath.Text = dialog.FileName;
    }

    private void ButtonBuild_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(textBoxFilePath.Text))
                throw new Exception("Не выбран файл для отчета.");

            if (comboBoxProduct.SelectedIndex < 0)
                throw new Exception("Не выбрано изделие.");

            if (dateTimePickerEnd.Value.Date < dateTimePickerBegin.Value.Date)
                throw new Exception("Дата окончания должна быть не раньше даты начала.");

            var result = _container.Resolve<ExcelReport>().CreateTable(
                textBoxFilePath.Text,
                (int)comboBoxProduct.SelectedValue!,
                dateTimePickerBegin.Value.Date,
                dateTimePickerEnd.Value.Date);

            MessageBox.Show(
                result
                    ? "Excel-документ сформирован."
                    : "Возникли ошибки при формировании документа. Подробности в логах.",
                "Формирование Excel-отчета",
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
