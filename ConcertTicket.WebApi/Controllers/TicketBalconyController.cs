using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketBalcony;
using ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketBalcony;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicket;
using ConcertTicket.Domain.Models.Entities;
using ConcertTicket.WebApi.Models.DTOs.CreateDTOs;
using ConcertTicket.WebApi.Models.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicket.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketBalconyController : BaseController
    {
        private readonly IMapper _mapper;

        public TicketBalconyController(IMapper mapper) => _mapper = mapper;

        [HttpPost("CreateBalconyTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TicketBalcony>> CreateBalcony([FromBody] CreateTicketBalconyDto createTicketBalconyDto)
        {
            var ticketBalcony = _mapper.Map<CreateTicketBalcony>(createTicketBalconyDto);
            ticketBalcony.GuestName = createTicketBalconyDto.GuestNameDto;
            ticketBalcony.GuestPhone = createTicketBalconyDto.GuestPhoneDto;
            ticketBalcony.TicketRow = createTicketBalconyDto.TicketRowDto;
            ticketBalcony.TicketPlace = createTicketBalconyDto.TicketPlaceDto;
            var ticket = await Mediator.Send(ticketBalcony);
            return Ok(ticket);
        }

        [HttpPut("UpdateBalconyTicket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateBalcony([FromBody] UpdateTicketBalconyDto updateTicketBalconyDto)
        {
            var ticketBalcony = _mapper.Map<UpdateTicketBalcony>(updateTicketBalconyDto);
            ticketBalcony.GuestName = updateTicketBalconyDto.GuestNameDto;
            ticketBalcony.GuestPhone = updateTicketBalconyDto.GuestPhoneDto;
            await Mediator.Send(ticketBalcony);
            return NoContent();
        }

        [HttpDelete("DeleteBalconyTicket {GuestPhone}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBalcony(string guestPhone)
        {
            var ticketBalcony = new DeleteTicketBalcony { GuestPhone = guestPhone };
            await Mediator.Send(ticketBalcony);
            return NoContent();
        }
    }
}
