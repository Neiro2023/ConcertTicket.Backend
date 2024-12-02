using AutoMapper;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketAmphitheater;

namespace ConcertTicket.WebApi.Models.DTOs.UpdateDTOs
{
    public class UpdateTicketAmphitheaterDto : IMapWith<UpdateTicketAmphitheater>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTicketAmphitheaterDto, UpdateTicketAmphitheater>()
                .ForMember(ticketAmphitheater => ticketAmphitheater.GuestName, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.GuestNameDto))
                .ForMember(ticketAmphitheater => ticketAmphitheater.GuestPhone, opt => opt.MapFrom(ticketAmphitheater => ticketAmphitheater.GuestPhoneDto));
        }
    }
}
