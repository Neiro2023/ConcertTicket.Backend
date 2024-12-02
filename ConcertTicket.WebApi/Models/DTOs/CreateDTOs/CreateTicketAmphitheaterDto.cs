using AutoMapper;
using ConcertTicket.Application.Ticket.TicketCommands.Create.CreateTicketAmphitheater;
using ConcertTicket.Application.TicketGeneral.Mappings;

namespace ConcertTicket.WebApi.Models.DTOs.CreateDTOs
{
    public class CreateTicketAmphitheaterDto : IMapWith<CreateTicketAmphitheater>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }
        public int TicketRowDto { get; set; }
        public int TicketPlaceDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTicketAmphitheaterDto, CreateTicketAmphitheater>()
                .ForMember(ticketAmphitheater => ticketAmphitheater.GuestName, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.GuestNameDto))
                .ForMember(ticketAmphitheater => ticketAmphitheater.GuestPhone, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.GuestPhoneDto))
                .ForMember(ticketAmphitheater => ticketAmphitheater.TicketRow, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.TicketRowDto))
                .ForMember(ticketAmphitheater => ticketAmphitheater.TicketPlace, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.TicketPlaceDto));
        }
    }
}
