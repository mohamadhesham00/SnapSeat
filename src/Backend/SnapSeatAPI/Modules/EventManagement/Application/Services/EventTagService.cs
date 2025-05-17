using EventManagement.Application.DTOs.EventTag;
using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Common.Mapping;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Models;

namespace EventManagement.Application.Services
{
    public class EventTagService : IEventTagService
    {
        private readonly IEventTagRepository _repo;
        public EventTagService(IEventTagRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<IReadOnlyList<GetEventTagDTO>>> BrowseAsync(CurrentUser currentUser, CancellationToken cancellationToken)
        {
            var tags = await _repo.GetAllAsync().ToListAsync(cancellationToken);
            var getTags = tags.ToGetDtoList();
            return Result<IReadOnlyList<GetEventTagDTO>>.Success(getTags);

        }
        public async Task<Result<GetEventTagDTO>> CreateAsync(CurrentUser currentUser, EventTagDTO dto, CancellationToken cancellationToken = default)
        {
            var tag = new EventTag(dto.Name)
            {
                CreatedBy = currentUser.UserId
            };

            await _repo.AddAsync(tag, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            var getTag = tag.ToGetDto();
            return Result<GetEventTagDTO>.Success(getTag);

        }
        public async Task<Result<GetEventTagDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var tag = await _repo.GetByIdAsync(id, cancellationToken);
            if (tag is null)
            {
                return Result<GetEventTagDTO>.Failure("Tag not found", System.Net.HttpStatusCode.NotFound);
            }

            var getTag = tag.ToGetDto();
            return Result<GetEventTagDTO>.Success(getTag);

        }
        public async Task<Result<GetEventTagDTO>> UpdateAsync(CurrentUser currentUser, Guid id, EventTagDTO dto, CancellationToken cancellationToken = default)
        {
            var tag = await _repo.GetByIdAsync(id, cancellationToken);
            if (tag is null)
            {
                return Result<GetEventTagDTO>.Failure("Tag not found", System.Net.HttpStatusCode.NotFound);
            }

            tag.Name = dto.Name;

            await _repo.SaveChangesAsync(cancellationToken);

            var getTag = tag.ToGetDto();
            return Result<GetEventTagDTO>.Success(getTag);

        }
        public async Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var tag = await _repo.GetByIdAsync(id, cancellationToken);
            if (tag is null)
            {
                return Result<bool>.Failure("Tag not found", System.Net.HttpStatusCode.NotFound);
            }

            _repo.Delete(tag);
            await _repo.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
    }
}
