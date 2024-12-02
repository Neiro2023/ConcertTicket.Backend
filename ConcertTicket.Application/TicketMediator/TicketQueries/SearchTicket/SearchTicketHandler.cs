using AutoMapper;
using ConcertTicket.Application.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicket.Application.TicketMediator.TicketQueries.SearchTicket
{
    public class SearchTicketHandler : IRequestHandler<SearchTicket, SearchTicketVm>
    {
        private readonly IPostgreDbContext _dbContext;
        private readonly IMapper _mapper;

        public SearchTicketHandler(IPostgreDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<SearchTicketVm> Handle(SearchTicket request,CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TicketAmphitheaters.FirstOrDefaultAsync(n => n.GuestPhone == request.GuestPhone, cancellationToken);

            if (entity == null || entity.GuestPhone != request.GuestPhone)
            {
                throw new Exception("Нет такого билета, либо номер телефона не содержит 11 цифр");
            }

            return _mapper.Map<SearchTicketVm>(entity);
        }
    }
}
