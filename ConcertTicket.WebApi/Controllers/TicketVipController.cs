using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicket;
using ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketBalcony;
using ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeliteTicket;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketVip;
using ConcertTicket.Domain.Models.Entities;
using ConcertTicket.WebApi.Models.DTOs.CreateDTOs;
using ConcertTicket.WebApi.Models.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicket.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketVipController : BaseController
    {
        private readonly IMapper _mapper;

        public TicketVipController(IMapper mapper) => _mapper = mapper;

        [HttpPost("CreateVipTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TicketVip>> CreateVip([FromBody] CreateTicketVipDto createTicketVipDto)
        {
            var ticketVip = _mapper.Map<CreateTicketVip>(createTicketVipDto);
            ticketVip.GuestName = createTicketVipDto.GuestNameDto;
            ticketVip.GuestPhone = createTicketVipDto.GuestPhoneDto;
            ticketVip.TicketRow = createTicketVipDto.TicketRowDto;
            ticketVip.TicketPlace = createTicketVipDto.TicketPlaceDto;
            var ticket = await Mediator.Send(ticketVip);
            return Ok(ticket);
        }

        [HttpPut("UpdateVipTicket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateVip([FromBody] UpdateTicketVipDto updateTicketVipDto)
        {
            var ticketVip = _mapper.Map<UpdateTicketVip>(updateTicketVipDto);
            ticketVip.GuestName = updateTicketVipDto.GuestNameDto;
            ticketVip.GuestPhone = updateTicketVipDto.GuestPhoneDto;
            await Mediator.Send(ticketVip);
            return NoContent();
        }

        [HttpDelete("DeleteVipTicket {GuestPhone}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteVip(string guestPhone)
        {
            var ticketVip = new DeleteTicketVip { GuestPhone = guestPhone };
            await Mediator.Send(ticketVip);
            return NoContent();
        }
    }
}
