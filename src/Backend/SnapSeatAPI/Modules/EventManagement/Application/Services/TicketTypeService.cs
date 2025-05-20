using EventManagement.Application.DTOs.TicketType;
using EventManagement.Application.Interfaces.IRepos;
using EventManagement.Application.Interfaces.IServices;
using EventManagement.Common.Mapping;
using EventManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Models;

namespace EventManagement.Application.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly ITicketTypeRepository _repo;
        private readonly IEventRepository _eventRepository;

        public TicketTypeService(ITicketTypeRepository repo, IEventRepository eventRepository)
        {
            _repo = repo;
            _eventRepository = eventRepository;
        }

        public async Task<Result<IReadOnlyList<GetTicketTypeDTO>>> BrowseAsync(Guid eventId, CurrentUser currentUser, CancellationToken cancellationToken)
        {
            var ticketTypes = await _repo.GetAllTypeForEvent(eventId, cancellationToken).ToListAsync();
            var getTickets = ticketTypes.ToGetDtoList();
            return Result<IReadOnlyList<GetTicketTypeDTO>>.Success(getTickets);
        }

        public async Task<Result<GetTicketTypeDTO>> CreateAsync(CurrentUser currentUser, TicketTypeDTO dto, CancellationToken cancellationToken = default)
        {
            var _event = await _eventRepository.GetByIdAsync(dto.EventId);
            if (_event is null)
            {
                return Result<GetTicketTypeDTO>.Failure("Cannot find event with this id", System.Net.HttpStatusCode.NotFound);
            }
            var ticketType = new TicketType
                (
                dto.Name,
                dto.Capacity,
                dto.Price,
                dto.EventId
                );
            await _repo.AddAsync(ticketType, cancellationToken);
            await _repo.SaveChangesAsync(cancellationToken);
            var getTicketType = ticketType.ToGetDto();
            return Result<GetTicketTypeDTO>.Success(getTicketType);

        }

        public async Task<Result<GetTicketTypeDTO>> GetAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var ticketType = await _repo.GetByIdAsync(id, cancellationToken);
            if (ticketType is null)
            {
                return Result<GetTicketTypeDTO>.Failure("Ticket type not found", System.Net.HttpStatusCode.NotFound);
            }

            var getTicketTypeDTO = ticketType.ToGetDto();
            return Result<GetTicketTypeDTO>.Success(getTicketTypeDTO);
        }

        public async Task<Result<GetTicketTypeDTO>> UpdateAsync(CurrentUser currentUser, Guid id, PutTicketTypeDTO dto, CancellationToken cancellationToken = default)
        {
            var ticketType = await _repo.GetByIdAsync(id, cancellationToken);
            if (ticketType is null)
            {
                return Result<GetTicketTypeDTO>.Failure("Ticket type not found", System.Net.HttpStatusCode.NotFound);
            }
            ticketType = dto.ToEntity(ticketType);
            _repo.Update(ticketType);
            await _repo.SaveChangesAsync(cancellationToken);

            var getTicketType = ticketType.ToGetDto();
            return Result<GetTicketTypeDTO>.Success(getTicketType);

        }

        public async Task<Result<string>> HandleBooking(CurrentUser currentUser, Guid id, int seats)
        {
            var ticketType = await _repo.GetByIdAsync(id);
            if (ticketType is null)
            {
                return Result<string>.Failure(
                    "We could not find this type of ticket, make sure you " +
                    "sent the right data"
                    , System.Net.HttpStatusCode.NotFound);
            }
            if (ticketType.SeatsLeft < seats)
            {

                return Result<string>.Failure(
                    "Unfortunately, there are not enough available seats to " +
                    "complete your booking."
                    , System.Net.HttpStatusCode.Conflict);
            }
            ticketType.SeatsBooked += seats;
            ticketType.UpdatedAt = DateTime.UtcNow;
            ticketType.UpdatedBy = currentUser.UserId;
            _repo.Update(ticketType);
            return Result<string>.Success("Successfully updated ticket");
        }


        public async Task<Result<bool>> DeleteAsync(CurrentUser currentUser, Guid id, CancellationToken cancellationToken = default)
        {
            var ticketType = await _repo.GetByIdAsync(id, cancellationToken);
            if (ticketType is null)
            {
                return Result<bool>.Failure("Ticket type not found", System.Net.HttpStatusCode.NotFound);
            }

            _repo.Delete(ticketType);
            await _repo.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
    }
}
