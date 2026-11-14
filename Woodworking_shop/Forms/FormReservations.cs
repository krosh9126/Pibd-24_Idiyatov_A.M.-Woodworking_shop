using System;
using System.Linq;
using System.Windows.Forms;
using Unity;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormReservations : Form
    {
        private readonly IUnityContainer _container;
        private readonly IMaterialReservationRepository _reservationRepository;

        public FormReservations(IUnityContainer container, IMaterialReservationRepository reservationRepository)
        {
            InitializeComponent();
            _container = container ?? throw new ArgumentNullException(nameof(container));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        private void FormReservations_Load(object sender, EventArgs e) => LoadList();

        private void LoadList()
        {
            dataGridViewData.DataSource = _reservationRepository.ReadReservations().ToList();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _container.Resolve<FormReservation>().ShowDialog();
                LoadList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}