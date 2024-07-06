using AutoMapper;
using Core;
using Core.Containers;
using Core.Containers.Interfaces;
using Services.Containers.DTOs;
using Services.Containers.Interfaces;

namespace Services.Containers
{
    public class ContainerService : IContainerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IContainerRepository _containerRepository;

        public ContainerService(IMapper mapper,
            IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
            _containerRepository = _uow.ContainerRepository();
        }

        public async Task AddAsync(ContainerCreateDto containerDto)
        {
            Container container = _mapper.Map<Container>(containerDto);
            await _containerRepository.AddAsync(container);
            await _uow.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _containerRepository.DeleteAsync(id);
            await _uow.CommitAsync();
        }

        public async Task<ContainerDto?> FindByIdAsync(Guid id)
        {
            Container? container = await _containerRepository.FindByIdAsync(id);
            if (container == null)
                return null;
            ContainerDto containerDto = _mapper.Map<ContainerDto>(container);
            return containerDto;
        }

        public async Task<List<ContainerDto>> GetAllAsync()
        {
            List<Container> containers = (List<Container>) await _containerRepository.GetAllAsync(); 
            List<ContainerDto> containerDtos = new List<ContainerDto>();
            foreach (var container in containers)
            {
                ContainerDto containerDto = _mapper.Map<ContainerDto>(container);
                containerDtos.Add(containerDto);
            }
            return containerDtos;
        }

        public async Task UpdateAsync(ContainerDto containerDto)
        {
            Container container = _mapper.Map<Container>(containerDto);
            await _containerRepository.UpdateAsync(container);
            await _uow.CommitAsync();
        }
    }
}
