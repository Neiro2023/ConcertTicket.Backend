using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicket;
using ConcertTicket.Application.TicketGeneral.Mappings;

namespace ConcertTicket.WebApi.Models.DTOs.CreateDTOs
{
    public class CreateTicketVipDto : IMapWith<CreateTicketVip>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }
        public int TicketRowDto { get; set; }
        public int TicketPlaceDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketVipDto, CreateTicketVip>()
                .ForMember(ticketVip => ticketVip.GuestName, opt => opt.MapFrom(ticketVip => ticketVip.GuestNameDto))
                .ForMember(ticketVip => ticketVip.GuestPhone, opt => opt.MapFrom(ticketVip => ticketVip.GuestPhoneDto))
                .ForMember(ticketVip => ticketVip.TicketRow, opt => opt.MapFrom(ticketVip => ticketVip.TicketRowDto))
                .ForMember(ticketVip => ticketVip.TicketPlace, opt => opt.MapFrom(ticketVip => ticketVip.TicketPlaceDto));
        }
    }
}
