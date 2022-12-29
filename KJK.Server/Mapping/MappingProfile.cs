using AutoMapper;
using KJK.Data.Models;
using KJK.Server.ViewModels;

namespace KJK.Server.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Paragraph, ParagraphViewModel>().ReverseMap();
            CreateMap<Monster, MonsterViewModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
