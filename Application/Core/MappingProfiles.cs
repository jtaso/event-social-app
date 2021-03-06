using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Map Activity to Activity
            CreateMap<Activity, Activity>();
        }
    }
}