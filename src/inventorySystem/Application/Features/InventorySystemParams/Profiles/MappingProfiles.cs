
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.InventorySystemParams.Queries.GetListStockStatus;

namespace Application.Features.InventorySystemParams.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GetListbyProductIdPaginatedDto, IPaginate<GetListbyProductIdPaginatedDto>>().ReverseMap();
        CreateMap<IPaginate<GetListbyProductIdPaginatedDto>, GetListResponse<GetListbyProductIdPaginatedDto>>().ReverseMap();
        CreateMap<List<GetListbyProductIdPaginatedDto>, GetListResponse<GetListbyProductIdPaginatedDto>>().ReverseMap();

        CreateMap<GetListStockStatusDto, IPaginate<GetListStockStatusDto>>().ReverseMap();
        CreateMap<IPaginate<GetListStockStatusDto>, GetListResponse<GetListStockStatusDto>>().ReverseMap();
        CreateMap<List<GetListStockStatusDto>, GetListResponse<GetListStockStatusDto>>().ReverseMap();
    }
}