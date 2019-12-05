using AutoMapper;
using Domain;

namespace Application.Activities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Activity, ActivityDto>();

            // Auto-Mapping at its finest :)
            CreateMap<UserActivity, AttendeeDto>().
            ForMember(d => d.UserName, opts => opts.
                MapFrom(s => s.AppUser.UserName)).
            ForMember(d => d.DisplayName, o => o.
                MapFrom(s => s.AppUser.DisplayName));
        }
    }
}