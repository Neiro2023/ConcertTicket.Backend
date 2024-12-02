using AutoMapper;
using ConcertTicket.Application.TicketGeneral.Mappings;
using ConcertTicket.Domain.Models.Entities;

namespace ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket
{
    public class SearchTicketVm : IMapWith<TicketAmphitheater>
    {
        public string GuestName { get; set; }
        public string GuestPhone { get; set; }
        public int TicketRow { get; set; }
        public int TicketPlace { get; set; }
        public DateTime OrderDate { get; private set; }
        public DateOnly ConcertDate { get; private set; }
        public string ConcertPlace { get; private set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TicketAmphitheater, SearchTicketVm>()
                .ForMember(vm => vm.GuestName, opt => opt.MapFrom(n => n.GuestName))
                .ForMember(vm => vm.GuestPhone, opt => opt.MapFrom(n => n.GuestPhone))
                .ForMember(vm => vm.TicketRow, opt => opt.MapFrom(n => n.TicketRow))
                .ForMember(vm => vm.TicketPlace, opt => opt.MapFrom(n => n.TicketPlace));
        }
    }
}
