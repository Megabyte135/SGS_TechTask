using Core.Containers.Interfaces;
using Core.Operations.Interfaces;
using System.Data;

namespace Core
{
    public interface IUnitOfWork
    {
        IContainerRepository ContainerRepository();
        IOperationRepository OperationRepository();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
