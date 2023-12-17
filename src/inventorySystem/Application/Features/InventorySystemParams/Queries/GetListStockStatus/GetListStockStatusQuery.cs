using Application.Services.InventorySystemParams;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InventorySystemParams.Queries.GetListStockStatus;
public class GetListStockStatusQuery : IRequest<GetListResponse<GetListStockStatusDto>>
{
    public PageRequest? PageRequest { get; set; }
    public class GetListStockStatusQueryHandler : IRequestHandler<GetListStockStatusQuery, GetListResponse<GetListStockStatusDto>>
    {
        private readonly IInventorySystemService _categoriesService;
        private readonly IMapper _mapper;

        public GetListStockStatusQueryHandler(IInventorySystemService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStockStatusDto>> Handle(GetListStockStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GetListStockStatusDto> categories = await _categoriesService.GetList(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStockStatusDto> response = _mapper.Map<GetListResponse<GetListStockStatusDto>>(categories);
            return response;
        }
    }
}
