using AutoMapper;
using Domain.Core.Interfaces;
using MediatR;

namespace Application.Core.AppService;

public class AppServiceCore<T> where T: IBaseRepository
{
    protected IMapper Mapper { get; set; }
    protected T Repository { get; set; }
    protected IMediator Mediator { get; set; }
    protected IBus Bus { get; set; }

    public AppServiceCore(IMapper mapper, T repository, IMediator mediator, IBus bus)
    {
        Mapper = mapper;
        Repository = repository;
        Mediator = mediator;
        Bus = bus;
    }
}