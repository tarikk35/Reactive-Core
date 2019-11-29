using System.Threading;
using System.Threading.Tasks;
using Application.Activities;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Users
{
    public class CurrentUser
    {
        public class Query : IRequest<User>
        {
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IJWTGenerator _jWTGenerator;
            private readonly IUserAccessor _userAccessor;

            public Handler(UserManager<AppUser> userManager, IJWTGenerator jWTGenerator,
            IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _jWTGenerator = jWTGenerator;
                _userManager = userManager;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUsername());
                return new User
                {
                    DisplayName = user.DisplayName,
                    Username = user.UserName,
                    Token = _jWTGenerator.CreateToken(user),
                    Image = null
                };
            }
        }
    }
}