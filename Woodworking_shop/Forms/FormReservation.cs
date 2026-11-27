using System;
using System.Linq;
using System.Windows.Forms;
using Woodworking_shop.Entities;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormReservation : Form
    {
        private readonly IMaterialReservationRepository _reservationRepository;

        public FormReservation(IMaterialReservationRepository reservationRepository,
                               IOrderRepository orderRepository,
                               IMaterialRepository materialRepository)
        {
            InitializeComponent();
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));

            var orders = orderRepository.ReadOrders().ToList();
           
            comboBoxOrder.DataSource = orders;
            comboBoxOrder.DisplayMember = "Client"; 
            comboBoxOrder.ValueMember = "Id";       

            var materials = materialRepository.ReadMaterials().ToList();
            
            comboBoxMaterial.DataSource = materials;
            comboBoxMaterial.DisplayMember = "Name"; 
            comboBoxMaterial.ValueMember = "Id";     
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxOrder.SelectedValue == null || comboBoxMaterial.SelectedValue == null)
                    throw new Exception("Выберите заказ и материал из списков");

                var reservation = MaterialReservation.CreateEntity(
                    0,
                    (int)comboBoxOrder.SelectedValue,
                    (int)comboBoxMaterial.SelectedValue,
                    (double)numericUpDownQty.Value,
                    DateTime.Now, 
                    "Активен"     
                );

                _reservationRepository.CreateReservation(reservation);
                Close();
            }
            catch (Exception ex)
            {
                var details = ex.InnerException != null ? $"\n\nДетали БД:\n{ex.InnerException.Message}" : "";
                MessageBox.Show(ex.Message + details, "Ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();
    }
}