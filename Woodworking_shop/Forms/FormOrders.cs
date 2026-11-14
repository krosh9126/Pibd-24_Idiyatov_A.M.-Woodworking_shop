using System;
using System.Linq;
using System.Windows.Forms;
using Unity;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormOrders : Form
    {
        private readonly IUnityContainer _container;
        private readonly IOrderRepository _orderRepository;

        public FormOrders(IUnityContainer container, IOrderRepository orderRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        private void FormOrders_Load(object sender, EventArgs e) => LoadList();
        private void LoadList() => dataGridViewData.DataSource = _orderRepository.ReadOrders().ToList();

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            _container.Resolve<FormOrder>().ShowDialog();
            LoadList();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewData.SelectedRows.Count < 1) return;
            var id = Convert.ToInt32(dataGridViewData.SelectedRows[0].Cells["Id"].Value);

            if (MessageBox.Show("Удалить (отменить) заказ?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            _orderRepository.DeleteOrder(id);
            LoadList();
        }
    }
}