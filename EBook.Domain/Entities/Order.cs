using EBook.Domain.Enums;

namespace EBook.Domain.Entities;

public class Order : AuditableEntity
{
    public int Id { get; set; }
    public string ShipAddress { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    // Pending(Not-Paid), Delivering, Delivered, Canceled
    public OrderStatus Status { get; set; }

    // Has Many Books
    public ICollection<Book> Books { get; set; } = [];
    // Has Many BookOrders
    public ICollection<BookOrder> BookOrders { get; set; } = [];
}
