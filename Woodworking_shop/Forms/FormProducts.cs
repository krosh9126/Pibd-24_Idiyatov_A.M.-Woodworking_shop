using Unity;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormProducts : Form
    {
        private readonly IUnityContainer _container;
        private readonly IProductRepository _productRepository;

        public FormProducts(IUnityContainer container, IProductRepository productRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        private void FormProducts_Load(object sender, EventArgs e) => LoadList();

        private void LoadList() => dataGridViewData.DataSource = _productRepository.ReadProducts();

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormProduct>().ShowDialog();
            LoadList();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;
            var form = _container.Resolve<FormProduct>();
            form.Id = findId;
            form.ShowDialog();
            LoadList();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;
            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            _productRepository.DeleteProduct(findId);
            LoadList();
        }

        private bool TryGetIdentifierFromSelectedRow(out int id)
        {
            id = 0;
            if (dataGridViewData.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка");
                return false;
            }
            id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}