using AutoMapper;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Application.TicketMediator.TicketCommands.Update.UpdateTicketVip;

namespace ConcertTicket.WebApi.Models.DTOs.UpdateDTOs
{
    public class UpdateTicketVipDto : IMapWith<UpdateTicketVip>
    {
        public string GuestNameDto { get; set; }
        public string GuestPhoneDto { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTicketVipDto, UpdateTicketVip>()
                .ForMember(ticketVip => ticketVip.GuestName, opt => opt.MapFrom(ticketVip => ticketVip.GuestNameDto))
                .ForMember(ticketVip => ticketVip.GuestPhone, opt => opt.MapFrom(ticketVip => ticketVip.GuestPhoneDto));
        }
    }
}
