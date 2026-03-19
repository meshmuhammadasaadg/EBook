using EBook.Domain.Contracts.Books;
using EBook.Domain.Entities;
using Mapster;

namespace EBook.Infrastructure.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Book, BookResponse>().TwoWays();
    }
}
