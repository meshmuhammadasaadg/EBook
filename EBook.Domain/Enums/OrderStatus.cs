namespace EBook.Domain.Enums;

public enum OrderStatus : byte
{
    Pending = 1,
    Delivering = 2,
    Delivered = 3,
    Canceled = 4
}
