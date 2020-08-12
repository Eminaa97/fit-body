using AutoMapper;
using FitBody.Common.Contracts;
using FitBody.Common.Requests;
using FitBody.Models;

namespace FitBody.Api.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // Request mapping
            CreateMap<UserInsertRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<PostInsertModel, Post>();
            CreateMap<CategoryInsertModel, Category>();
            CreateMap<CommentInsertModel, Comment>();
            CreateMap<SubcategoryInsertModel, Subcategory>();
            CreateMap<TagInsertModel, Tag>();
            CreateMap<ThreadInsertModel, Thread>();
            CreateMap<TopicSuggestedInsertModel, TopicSuggested>();

            // DTO mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Tag, TagDto>();
            CreateMap<User, AuthenticatedUser>();
            CreateMap<Post, PostDto>()
                .ForMember(x => x.Username, y => y.MapFrom(src => src.User.UserName))
                .ForMember(x => x.Subcategoryname, y => y.MapFrom(src => src.Subcategory.Title))
                .ForMember(x => x.Categoryname, y => y.MapFrom(src => src.Subcategory.Category.Title))
                .ForMember(x => x.CategoryId, y => y.MapFrom(src => src.Subcategory.CategoryId));
            CreateMap<Category, CategoryDto>();
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.Username, y => y.MapFrom(src => src.User.UserName));
            CreateMap<Thread, ThreadDto>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.User.UserName));
            CreateMap<TopicSuggested, TopicSuggestedDto>()
                .ForMember(x => x.Username, y => y.MapFrom(src => src.User.UserName));
            CreateMap<User, UserFollowDto>();

        }
    }
}
