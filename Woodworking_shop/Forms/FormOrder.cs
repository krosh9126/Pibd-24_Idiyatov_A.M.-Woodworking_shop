using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormOrder : Form
    {
        private readonly IOrderRepository _orderRepository;

        public FormOrder(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));

            ColumnProduct.DataSource = productRepository.ReadProducts().ToList();
            ColumnProduct.DisplayMember = "Name"; 
            ColumnProduct.ValueMember = "Id";     
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxClient.Text) || string.IsNullOrWhiteSpace(textBoxType.Text))
                    throw new Exception("Имеются незаполненные поля (Клиент или Тип заказа)");

                var orderItems = CreateListOrderItemsFromDataGrid();

                if (orderItems.Count == 0)
                    throw new Exception("Добавьте хотя бы одно изделие в заказ");

                var order = Order.CreateOperation(
                    0,
                    textBoxClient.Text,
                    "Новый",
                    textBoxType.Text,
                    orderItems);

                _orderRepository.CreateOrder(order);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<OrderItem> CreateListOrderItemsFromDataGrid()
        {
            var list = new List<OrderItem>();

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (row.Cells["ColumnProduct"].Value == null || row.Cells["ColumnQuantity"].Value == null)
                {
                    continue;
                }

                list.Add(OrderItem.CreateEntity(
                    0,
                    0, 
                    Convert.ToInt32(row.Cells["ColumnProduct"].Value),
                    Convert.ToInt32(row.Cells["ColumnQuantity"].Value)
                ));
            }
            return list;
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();
    }
}