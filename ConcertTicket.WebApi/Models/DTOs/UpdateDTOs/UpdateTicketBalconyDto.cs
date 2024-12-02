using AutoMapper;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicket;

namespace ConcertTicket.WebApi.Models.DTOs.UpdateDTOs
{
    public class UpdateTicketBalconyDto : IMapWith<UpdateTicketBalcony>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTicketBalconyDto, UpdateTicketBalcony>()
                .ForMember(ticketBalcony => ticketBalcony.GuestName, opt => opt.MapFrom(ticketBalcony => ticketBalcony.GuestNameDto))
                .ForMember(ticketBalcony => ticketBalcony.GuestPhone, opt => opt.MapFrom(ticketBalcony => ticketBalcony.GuestPhoneDto));
        }
    }
}
