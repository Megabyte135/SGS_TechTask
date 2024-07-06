namespace Core.Containers.Interfaces
{
    public interface IContainerRepository
    {
        Task<IEnumerable<Container>> GetAllAsync();
        Task<Container?> FindByIdAsync(Guid id);
        Task AddAsync(Container container);
        Task UpdateAsync(Container container);
        Task DeleteAsync(Guid id);
    }
}
