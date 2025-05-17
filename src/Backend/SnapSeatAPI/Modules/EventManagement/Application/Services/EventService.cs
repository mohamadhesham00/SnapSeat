using EventManagement.Application.DTOs.Event;
using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Common.Mapping;
using EventManagement.Domain.Entities;
using Shared.Application.Services;
using Shared.Domain.Models;

namespace EventManagement.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public EventService(IEventRepository repo
            , IEventCategoryRepository eventCategoryRepository)
        {
            _repo = repo;
            _eventCategoryRepository = eventCategoryRepository;
        }
        // I know this isn't the best solution but I am running out of time
        public IQueryable<Event> ApplyFiltering(GetEventRequest request)
        {
            var events = _repo.GetAllAsync();
            if (!string.IsNullOrEmpty(request.Name))
                events.Where(e => e.Name.Contains(request.Name));
            if (request.StartTime.HasValue)
                events.Where(e => e.StartTime == request.StartTime.Value);
            if (request.Location != null)
                events.Where(e => e.Location == request.Location);
            if (request.EventCategoryId != null)
                events.Where(e => e.EventCategoryId == request.EventCategoryId);
            if (request.EventTagId != null)
                events.Where(e => e.Tags.Any(t => t.Id == request.EventTagId));

            return events;
        }
        public async Task<Result<Pagination<GetEventDTO>>> BrowsePaginatedAsync(CurrentUser currentUser, GetEventRequest request, PaginationRequest paginationRequest, CancellationToken cancellationToken)
        {
            var events = this.ApplyFiltering(request);
            var paginated = await events.GetPaginationAsync(paginationRequest
                , EventMappingExtensions.ToGetDtoList, cancellationToken);
            return Result<Pagination<GetEventDTO>>.Success(paginated);
        }

        public async Task<Result<GetEventDTO>> CreateAsync(CurrentUser currentUser, EventDTO dto, CancellationToken cancellationToken = default)
        {
            var eventCategoryExists = await _eventCategoryRepository.Exists(dto.EventCategoryId);
            if (!eventCategoryExists)
            {
                return Result<GetEventDTO>.Failure("Cannot find event with this id"
                    , System.Net.HttpStatusCode.NotFound);
            }
            var _event = dto.ToEntity();
            _event.CreatedBy = currentUser.UserId;
            if (dto.Image != null)
            {
                string url = await ImageStoringService.UploadImageAsync(dto.Image, _event.Id);
                _event.ImageUrl = url;
            }

            await _repo.AddAsync(_event, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            var getCategory = _event.ToGetDto();
            return Result<GetEventDTO>.Success(getCategory);
        }

        public async Task<Result<GetEventDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var _event = await _repo.GetByIdAsync(id, cancellationToken);
            if (_event is null)
            {
                return Result<GetEventDTO>.Failure("Event not found", System.Net.HttpStatusCode.NotFound);
            }

            var getEvent = _event.ToGetDto();
            return Result<GetEventDTO>.Success(getEvent);

        }

        public async Task<Result<GetEventDTO>> UpdateAsync(CurrentUser currentUser, Guid id, PutEventDTO dto, CancellationToken cancellationToken = default)
        {
            var _event = await _repo.GetByIdAsync(id, cancellationToken);
            if (_event is null)
            {
                return Result<GetEventDTO>.Failure("Event not found", System.Net.HttpStatusCode.NotFound);
            }
            _event = dto.ToEntity(_event);
            if (dto.Image != null)
            {
                string url = await ImageStoringService.UploadImageAsync(dto.Image, _event.Id);
                _event.ImageUrl = url;
            }
            _repo.Update(_event);
            await _repo.SaveChangesAsync(cancellationToken);

            var getEvent = _event.ToGetDto();
            return Result<GetEventDTO>.Success(getEvent);
        }

        public async Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var _event = await _repo.GetByIdAsync(id, cancellationToken);
            if (_event is null)
            {
                return Result<bool>.Failure("event not found", System.Net.HttpStatusCode.NotFound);
            }
            if (_event.IsDeleted)
            {
                return Result<bool>.Failure("event already is deleted", System.Net.HttpStatusCode.Conflict);
            }
            _event.IsDeleted = true;
            _repo.Update(_event);
            await _repo.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
    }
}
