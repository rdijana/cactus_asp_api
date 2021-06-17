using Application.DataTransfer;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dto => dto.Categories, opt => opt.MapFrom(post => post.PostCategories.Select(c => c.Category.Name)))
                .ForMember(dto => dto.CategoryIds, opt => opt.MapFrom(post => post.PostCategories.Select(c => c.Category.Id)))
                .ForMember(dto => dto.ImageSrc, opt => opt.MapFrom(post => post.Image))
                .ForMember(dto => dto.Image, opt => opt.Ignore())
                .ForMember(dto => dto.Mark, opt => opt.MapFrom(post => post.Marks.Count() > 0 ? post.Marks.Sum(r => r.Value) / post.Marks.Count() : 0))
                .ForMember(dto => dto.CommentsCount, opt => opt.MapFrom(post => post.Comments.Count()))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(post => post.Comments.Select(comment => new CommentDto
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    PostId = comment.PostId,
                    UserId = comment.UserId,
                    User = comment.User.FirstName + " " + comment.User.LastName,
                    CreatedAt = comment.CreatedAt
                }).ToList()));

            CreateMap<PostCreateDto, Post>();
                
                
        }
    }
}
