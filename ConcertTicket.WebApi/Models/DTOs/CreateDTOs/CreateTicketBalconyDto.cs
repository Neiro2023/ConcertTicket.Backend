using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketBalcony;
using ConcertTicket.Application.TicketGeneral.Mappings;

namespace ConcertTicket.WebApi.Models.DTOs.CreateDTOs
{
    public class CreateTicketBalconyDto : IMapWith<CreateTicketBalcony>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }
        public int TicketRowDto { get; set; }
        public int TicketPlaceDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketBalconyDto, CreateTicketBalcony>()
                .ForMember(ticketBalcony => ticketBalcony.GuestName, opt => opt.MapFrom(ticketBalcony => ticketBalcony.GuestNameDto))
                .ForMember(ticketBalcony => ticketBalcony.GuestPhone, opt => opt.MapFrom(ticketBalcony => ticketBalcony.GuestPhoneDto))
                .ForMember(ticketBalcony => ticketBalcony.TicketRow, opt => opt.MapFrom(ticketBalcony => ticketBalcony.TicketRowDto))
                .ForMember(ticketBalcony => ticketBalcony.TicketPlace, opt => opt.MapFrom(ticketBalcony => ticketBalcony.TicketPlaceDto));
        }
    }
}
