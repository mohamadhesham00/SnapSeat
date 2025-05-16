using EventManagement.Application.DTOs.EventCategory;
using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Common.Mapping;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Models;

namespace EventManagement.Application.Services
{
    internal class EventCategoryService : IEventCategoryService
    {
        private readonly IEventCategoryRepository _repo;
        public EventCategoryService(IEventCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<IReadOnlyList<GetEventCategoryDTO>>> BrowseAsync(CurrentUser currentUser, CancellationToken cancellationToken)
        {
            var categories = await _repo.GetAllAsync().ToListAsync(cancellationToken);
            var getCategories = categories.ToGetDtoList();
            return Result<IReadOnlyList<GetEventCategoryDTO>>.Success(getCategories);

        }
        public async Task<Result<GetEventCategoryDTO>> CreateAsync(CurrentUser currentUser, EventCategoryDTO dto, CancellationToken cancellationToken = default)
        {
            var category = dto.ToEntity();
            category.CreatedBy = currentUser.UserId;

            await _repo.AddAsync(category, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            var getCategory = category.ToGetDto();
            return Result<GetEventCategoryDTO>.Success(getCategory);

        }
        public async Task<Result<GetEventCategoryDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _repo.GetByIdAsync(id, cancellationToken);
            if (category is null)
            {
                return Result<GetEventCategoryDTO>.Failure("Category not found", System.Net.HttpStatusCode.NotFound);
            }

            var getCategory = category.ToGetDto();
            return Result<GetEventCategoryDTO>.Success(getCategory);

        }
        public async Task<Result<GetEventCategoryDTO>> UpdateAsync(CurrentUser currentUser, Guid id, EventCategoryDTO dto, CancellationToken cancellationToken = default)
        {
            var category = await _repo.GetByIdAsync(id, cancellationToken);
            if (category is null)
            {
                return Result<GetEventCategoryDTO>.Failure("Category not found", System.Net.HttpStatusCode.NotFound);
            }

            category.Name = dto.Name;

            await _repo.SaveChangesAsync(cancellationToken);

            var getCategory = category.ToGetDto();
            return Result<GetEventCategoryDTO>.Success(getCategory);

        }
        public async Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var category = await _repo.GetByIdAsync(id, cancellationToken);
            if (category is null)
            {
                return Result<bool>.Failure("Category not found", System.Net.HttpStatusCode.NotFound);
            }

            _repo.Delete(category);
            await _repo.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }

    }
}
