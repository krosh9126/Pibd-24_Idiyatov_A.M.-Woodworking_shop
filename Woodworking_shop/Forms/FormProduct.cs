using System.ComponentModel;
using Woodworking_shop.Entities;
using Woodworking_shop.Entities.Enums;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormProduct : Form
    {
        private readonly IProductRepository _productRepository;
        private int? _productId;

        public FormProduct(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            comboBoxCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id
        {
            set
            {
                try
                {
                    var product = _productRepository.ReadProductById(value);
                    if (product == null) throw new InvalidDataException(nameof(product));

                    textBoxName.Text = product.Name;
                    comboBoxCategory.SelectedItem = product.Category;
                    numericUpDownPrice.Value = (decimal)product.Price;
                    numericUpDownQty.Value = (decimal)product.StorageQty;
                    _productId = value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text) || comboBoxCategory.SelectedIndex < 1)
                    throw new Exception("Имеются незаполненные поля");

                var product = Product.CreateEntity(
                    _productId ?? 0,
                    textBoxName.Text,
                    (ProductCategory)comboBoxCategory.SelectedItem!,
                    (double)numericUpDownPrice.Value,
                    Convert.ToInt32(numericUpDownQty.Value));

                if (_productId.HasValue) _productRepository.UpdateProduct(product);
                else _productRepository.CreateProduct(product);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();
    }
}