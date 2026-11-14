using System;
using System.Windows.Forms;
using Unity;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormMaterials : Form
    {
        private readonly IUnityContainer _container;
        private readonly IMaterialRepository _materialRepository;

        public FormMaterials(IUnityContainer container, IMaterialRepository materialRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));
        }

        private void FormMaterials_Load(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadList()
        {
            dataGridViewData.DataSource = _materialRepository.ReadMaterials().ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormMaterial>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при добавлении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            try
            {
                var form = _container.Resolve<FormMaterial>();
                form.Id = findId; // Передаем ID для заполнения полей
                form.ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при изменении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!TryGetIdentifierFromSelectedRow(out var findId)) return;

            if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                _materialRepository.DeleteMaterial(findId);
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при удалении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательный метод для получения ID из выделенной строки
        private bool TryGetIdentifierFromSelectedRow(out int id)
        {
            id = 0;
            if (dataGridViewData.SelectedRows.Count < 1)
            {
                MessageBox.Show("Нет выбранной записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);
            return true;
        }
    }
}