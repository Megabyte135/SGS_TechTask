using Services.Operations.DTOs;

namespace Services.Operations.Interfaces
{
    public interface IOperationService
    {
        Task<List<OperationDto>> GetAllAsync();
        Task<List<OperationDto>> GetAllByContainerId(Guid id);
        Task AddAsync(OperationCreateDto operation);
        Task UpdateAsync(OperationDto operation);
        Task DeleteAsync(Guid id);
    }
}
