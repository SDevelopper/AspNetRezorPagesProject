using AspNetRezorPagesProject.Models.DTO;
using AspNetRezorPagesProject.Models.Entity;
using AspNetRezorPagesProject.Models.ViewModels;
using AutoMapper;

namespace AspNetRezorPagesProject.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
