using AutoMapper;
using EducationalBlog.Contracts.Models.Articles;
using EducationalBlog.Contracts.Models.Comments;
using EducationalBlog.Contracts.Models.Tags;
using EducationalBlog.Contracts.Models.User;
using EducationalBlog.Data.Models;

namespace EducationalBlog.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
            CreateMap<AddTagRequest, Tag>();
            CreateMap<AddArticleReqest, Article>();
            CreateMap<AddCommentReqest, Comment>()
                .ForMember(x => x.Content, opt => opt.MapFrom(c => c.CommentContext));

            CreateMap<User, UserView>();
            CreateMap<Comment, CommentView>();
            CreateMap<Article, ArticleView>();
            CreateMap<Tag, TagView>();
        }
    }
}
