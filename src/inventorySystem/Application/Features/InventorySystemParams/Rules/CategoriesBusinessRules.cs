using Application.Features.InventorySystemParams.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.InventorySystemParams.Rules;

public class CategoriesBusinessRules : BaseBusinessRules
{
    public Task CategoriesShouldExistWhenSelected(Categories? categories)
    {
        if (categories == null)
            throw new BusinessException(CategoriesBusinessMessages.CategoriesNotExists);
        return Task.CompletedTask;
    }
}