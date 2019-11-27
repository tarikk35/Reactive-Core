using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            // Cancellation token is useful when user sends same request multiple times and user aborts the previous request/s.
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {

                var activity = await _context.Activities.FindAsync(request.Id);

                if (activity == null)
                {
                    throw new RESTException(HttpStatusCode.NotFound, new { activity = "Not Found" });
                }

                return activity;
            }
        }
    }
}