using AutoMapper;
using Core.Containers.Interfaces;
using Core;
using Services.Operations.DTOs;
using Services.Operations.Interfaces;
using Core.Operations.Interfaces;
using Core.Operations;
using Services.Containers.DTOs;

namespace Services.Operations
{
    public class OperationService : IOperationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IOperationRepository _operationRepository;

        public OperationService(IMapper mapper,
            IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _operationRepository = _uow.OperationRepository();
        }

        public async Task AddAsync(OperationCreateDto operationDto)
        {
            Operation operation = _mapper.Map<Operation>(operationDto);
            await _operationRepository.AddAsync(operation);
            await _uow.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _operationRepository.DeleteAsync(id);
            await _uow.CommitAsync();
        }

        public async Task<List<OperationDto>> GetAllAsync()
        {
            List<Operation> operations = (List<Operation>)await _operationRepository.GetAllAsync();
            return ListToDtos(operations);
        }


        public async Task<List<OperationDto>> GetAllByContainerId(Guid id)
        {
            List<Operation> operations = (List<Operation>)await _operationRepository.GetAllByContainerId(id);
            return ListToDtos(operations);
        }
        private List<OperationDto> ListToDtos(List<Operation> operations)
        {
            List<OperationDto> operationDtos = new List<OperationDto>();
            foreach (var operation in operations)
            {
                OperationDto operationDto = _mapper.Map<OperationDto>(operation);
                operationDtos.Add(operationDto);
            }
            return operationDtos;
        }

        public async Task UpdateAsync(OperationDto operationDto)
        {
            Operation operation = _mapper.Map<Operation>(operationDto);
            await _operationRepository.UpdateAsync(operation);
            await _uow.CommitAsync();
        }
    }
}
