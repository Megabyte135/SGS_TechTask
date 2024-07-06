using Services.Containers.DTOs;

namespace Services.Containers.Interfaces
{
    public interface IContainerService
    {
        Task<List<ContainerDto>> GetAllAsync();
        Task<ContainerDto?> FindByIdAsync(Guid id);
        Task AddAsync(ContainerCreateDto container);
        Task UpdateAsync(ContainerDto container);
        Task DeleteAsync(Guid id);
    }
}
