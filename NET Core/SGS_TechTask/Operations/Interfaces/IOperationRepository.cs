namespace Core.Operations.Interfaces
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Operation>> GetAllAsync();
        Task<IEnumerable<Operation>> GetAllByContainerId(Guid id);
        Task AddAsync(Operation operation);
        Task UpdateAsync(Operation operation);
        Task DeleteAsync(Guid id);
    }
}
