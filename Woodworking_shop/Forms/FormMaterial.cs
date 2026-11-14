using System.ComponentModel;
using Woodworking_shop.Entities;
using Woodworking_shop.Entities.Enums;
using Woodworking_shop.Repositories;

namespace Woodworking_shop.Forms
{
    public partial class FormMaterial : Form
    {
        private readonly IMaterialRepository _materialRepository;
        private int? _materialId;

        public FormMaterial(IMaterialRepository materialRepository)
        {
            InitializeComponent();
            _materialRepository = materialRepository ?? throw new ArgumentNullException(nameof(materialRepository));

            foreach (var elem in Enum.GetValues(typeof(MaterialType)))
            {
                checkedListBoxType.Items.Add(elem);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Id
        {
            set
            {
                try
                {
                    var material = _materialRepository.ReadMaterialById(value);
                    if (material == null) throw new InvalidDataException(nameof(material));

                    textBoxName.Text = material.Name;
                    textBoxUnit.Text = material.Unit;
                    numericUpDownPrice.Value = (decimal)material.UnitPrice;
                    numericUpDownStock.Value = (decimal)material.StorageQty;

                    foreach (MaterialType elem in Enum.GetValues(typeof(MaterialType)))
                    {
                        if ((elem & material.Type) != 0)
                        {
                            checkedListBoxType.SetItemChecked(checkedListBoxType.Items.IndexOf(elem), true);
                        }
                    }
                    _materialId = value;
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
                if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxUnit.Text) || checkedListBoxType.CheckedItems.Count == 0)
                    throw new Exception("Имеются незаполненные поля");

                MaterialType type = MaterialType.None;
                foreach (var elem in checkedListBoxType.CheckedItems)
                {
                    type |= (MaterialType)elem;
                }

                var material = Material.CreateEntity(
                    _materialId ?? 0,
                    textBoxName.Text,
                    type,
                    textBoxUnit.Text,
                    (double)numericUpDownPrice.Value,   
                    (double)numericUpDownStock.Value,
                    0);


                if (_materialId.HasValue) _materialRepository.UpdateMaterial(material);
                else _materialRepository.CreateMaterial(material);

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