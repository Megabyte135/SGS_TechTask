using AutoMapper;
using Services.Containers.DTOs;
using Core.Containers;
using Core.Operations;
using Services.Operations.DTOs;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Container, ContainerDto>().ReverseMap();
            CreateMap<Container, ContainerCreateDto>().ReverseMap();
            CreateMap<OperationDto, Operation>()
                .ForMember(dest => dest.Operator, opt => opt.MapFrom(src => new Operator { FullName = src.OperatorFullName }));
            CreateMap<Operation, OperationDto>()
                .ForMember(dest => dest.OperatorFullName, opt => opt.MapFrom(src => src.Operator.FullName));
            CreateMap<OperationCreateDto, Operation>()
                .ForMember(dest => dest.Operator, opt => opt.MapFrom(src => new Operator { FullName = src.OperatorFullName }));
            CreateMap<Operation, OperationCreateDto>()
                .ForMember(dest => dest.OperatorFullName, opt => opt.MapFrom(src => src.Operator.FullName));
        }
    }
}
