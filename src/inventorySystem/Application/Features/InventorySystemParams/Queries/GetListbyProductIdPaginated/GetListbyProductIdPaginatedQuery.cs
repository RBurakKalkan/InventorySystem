
using Domain.Entities;
using AutoMapper;

using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Application.Services.InventorySystemParams;

namespace Application.Features.InventorySystemParams.Queries.GetListStockStatus;

public class GetListbyProductIdPaginatedQuery : IRequest<GetListResponse<GetListbyProductIdPaginatedDto>>
{
    public int productId { get; set; }
    public PageRequest? PageRequest { get; set; }

    public class GetListCategoriesQueryHandler : IRequestHandler<GetListbyProductIdPaginatedQuery, GetListResponse<GetListbyProductIdPaginatedDto>>
    {
        private readonly IInventorySystemService _categoriesService;
        private readonly IMapper _mapper;

        public GetListCategoriesQueryHandler(IInventorySystemService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListbyProductIdPaginatedDto>> Handle(GetListbyProductIdPaginatedQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GetListbyProductIdPaginatedDto> categories = await _categoriesService.GetListByProductId(request.productId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListbyProductIdPaginatedDto> response = _mapper.Map<GetListResponse<GetListbyProductIdPaginatedDto>>(categories);
            return response;
        }
    }
}