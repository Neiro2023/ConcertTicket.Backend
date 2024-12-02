using AutoMapper;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket;

namespace ConcertTicket.WebApi.Models.DTOs
{
    public class SearchTicketAmphitheaterDto : IMapWith<SearchTicket>
    {
        public string GuestPhoneDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SearchTicketAmphitheaterDto, SearchTicket>()
                .ForMember(ticketAmphitheater => ticketAmphitheater.GuestPhone, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.GuestPhoneDto));
        }
    }
}
