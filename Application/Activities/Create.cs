using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        // Not using type parameter bc this is not returning anything
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Add activity inside context in memory
                _context.Activities.Add(request.Activity);

                await _context.SaveChangesAsync();

                // Let ApiController know task is finished
                return Unit.Value;
            }
        }
    }
}