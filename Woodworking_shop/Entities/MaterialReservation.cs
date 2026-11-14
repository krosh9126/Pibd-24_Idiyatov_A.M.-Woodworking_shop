using System;

namespace Woodworking_shop.Entities;

public class MaterialReservation
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int MaterialId { get; private set; }
    public double Quantity { get; private set; }
    public DateTime ReservationDate { get; private set; }
    public string Status { get; private set; }

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
            throw new ArgumentException("ID заказа и материала не должно быть null");

        if (quantity <= 0 || quantity == null)
            throw new ArgumentException("Количество резервируемого материала должно быть больше нуля.", nameof(quantity));

        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Статус резерва не может быть пустым.", nameof(status));

        return new MaterialReservation(id, orderId.Value, materialId.Value, quantity.Value, reservationDate, status);
    }
}