using AutoMapper;
using ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicket.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : BaseController
    {


        [HttpGet("SearchGuestByPhone{GuestPhone}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SearchTicketVm>> SearchByPhone(string guestPhone)
        {

            SearchTicket query = new SearchTicket { GuestPhone = guestPhone };
            SearchTicketVm vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
