using Unity;

namespace Woodworking_shop.Forms
{
    public partial class FormMain : Form
    {
        private readonly IUnityContainer _container;

        public FormMain(IUnityContainer container)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormProducts>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormMaterials>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormOrders>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormReservations>().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}