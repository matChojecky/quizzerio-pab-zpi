using AutoMapper;
using Quizerio.Application.User.Dtos;
using Quizerio.Domain.User.Model;

namespace Quizerio.Api.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserReadModel>();
        }
    }
}