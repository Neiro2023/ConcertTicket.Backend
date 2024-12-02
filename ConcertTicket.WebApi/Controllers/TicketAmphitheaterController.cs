using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketAmphitheater;
using ConcertTicket.Application.TicketMediator.TicketCommands.Delete.DeleteTicketAmphitheater;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketAmphitheater;
using ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket;
using ConcertTicket.Domain.Models.Entities;
using ConcertTicket.WebApi.Models.DTOs.CreateDTOs;
using ConcertTicket.WebApi.Models.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicket.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketAmphitheaterController : BaseController
    {
        private readonly IMapper _mapper;

        public TicketAmphitheaterController(IMapper mapper) => _mapper = mapper;

        [HttpPost("CreateAmphitheaterTicket")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TicketAmphitheater>> CreateAmphitheater([FromBody] CreateTicketAmphitheaterDto createTicketAmphitheaterDto)
        {
            var ticketAmphitheater = _mapper.Map<CreateTicketAmphitheater>(createTicketAmphitheaterDto);
            ticketAmphitheater.GuestName = createTicketAmphitheaterDto.GuestNameDto;
            ticketAmphitheater.GuestPhone = createTicketAmphitheaterDto.GuestPhoneDto;
            ticketAmphitheater.TicketRow = createTicketAmphitheaterDto.TicketRowDto;
            ticketAmphitheater.TicketPlace = createTicketAmphitheaterDto.TicketPlaceDto;
            var ticket = await Mediator.Send(ticketAmphitheater);
            return Ok(ticket);
        }

        [HttpPut("UpdateAmphitheaterTicket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateAmphitheater([FromBody] UpdateTicketAmphitheaterDto updateTicketAmphitheaterDto)
        {
            var ticketAmphitheater = _mapper.Map<UpdateTicketAmphitheater>(updateTicketAmphitheaterDto);
            ticketAmphitheater.GuestName = updateTicketAmphitheaterDto.GuestNameDto;
            ticketAmphitheater.GuestPhone = updateTicketAmphitheaterDto.GuestPhoneDto;
            await Mediator.Send(ticketAmphitheater);
            return NoContent();
        }

        [HttpDelete("DeleteAmphitheaterTicket {GuestPhone}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAmphitheater(string guestPhone)
        {
            var ticketAmphitheater = new DeleteTicketAmphitheater { GuestPhone = guestPhone };
            await Mediator.Send(ticketAmphitheater);
            return NoContent();
        }
    }
}
