using AutoMapper;

namespace ConcertTicket.Application.TicketGeneral.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
