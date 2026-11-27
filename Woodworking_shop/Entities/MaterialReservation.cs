using System;
using System.ComponentModel.DataAnnotations;

namespace Woodworking_shop.Entities;

public class MaterialReservation
{
    [Key]
    public int Id { get; private set; }

    public int OrderId { get; private set; }
    public int MaterialId { get; private set; }

    public double Quantity { get; private set; }
    public DateTime ReservationDate { get; private set; }

    [Required]
    public string Status { get; private set; }

    public MaterialReservation()
    {
    }

    private MaterialReservation(int id, int orderId, int materialId, double quantity, DateTime reservationDate, string status)
    {
        Id = id;
        OrderId = orderId;
        MaterialId = materialId;
        Quantity = quantity;
        ReservationDate = reservationDate;
        Status = status;
    }

    public static MaterialReservation CreateEntity(int id, int? orderId, int? materialId, double? quantity, DateTime reservationDate, string status)
    {
        if (orderId == null || materialId == null)
            throw new ArgumentNullException("ID заказа и материала не должно быть null");

        if (quantity == null)
            throw new ArgumentNullException(nameof(quantity), "Количество резервируемого материала не должно быть null.");

        if (quantity <= 0)
            throw new ArgumentException("Количество резервируемого материала должно быть больше нуля.", nameof(quantity));

        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentNullException(nameof(status), "Статус резерва не может быть пустым.");

        return new MaterialReservation(id, orderId.Value, materialId.Value, quantity.Value, reservationDate, status);
    }
}