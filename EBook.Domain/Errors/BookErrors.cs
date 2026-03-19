using EBook.Domain.Abstractions;

namespace EBook.Domain.Errors;

public static class BookErrors
{
    public static readonly Error BookNotFound =
        new("Book.NotFound", "We not found any books with this ID");
}
