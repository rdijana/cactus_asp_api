using Application.Commands;
using Application.DataTransfer;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly CactusContext _context;
        private readonly CreatePostValidator _validator;
        private readonly IMapper _mapper;

        public EfCreatePostCommand(CactusContext context, CreatePostValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Creating new post";

        public void Execute(PostCreateDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = _mapper.Map<Post>(request);

            var guid = Guid.NewGuid();

            var extension = Path.GetExtension(request.Image.FileName);

            var newFileName = guid + "_" + request.Image.FileName;

            var path = Path.Combine("wwwroot", "Images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            post.Image = newFileName;

            foreach (var id in request.CategoryIds)
            {
                _context.PostCategories.Add(new PostCategory
                {
                    CategoryId = id,
                    Post = post
                });
            }

            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
