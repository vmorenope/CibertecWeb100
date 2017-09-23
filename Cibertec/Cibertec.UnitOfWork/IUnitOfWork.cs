using Cibertec.Repositories.Northwind;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Se agregar una propiedad por cada repositorio
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IOrderItemRepository OrderItems { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        IUserRepository Users { get; }
    }
}
