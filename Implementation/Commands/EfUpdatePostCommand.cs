using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdatePostCommand : IUpdatePostCommand
    {

        private readonly CactusContext _context;
        private readonly UpdatePostValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdatePostCommand(CactusContext context, UpdatePostValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Updating post";

        public void Execute(PostCreateDto request)
        {
            var post = _context.Posts.Include(p => p.PostCategories)
                                        .FirstOrDefault(p => p.Id == request.Id);

            if (post == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(Post));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, post);

            if (request.Image != null)
            {
                var guid = Guid.NewGuid();

                var extension = Path.GetExtension(request.Image.FileName);

                var newFileName = guid + "_" + request.Image.FileName;

                var path = Path.Combine("wwwroot", "Images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }

                post.Image = newFileName;
            }

           
            post.PostCategories.Where(pc => !request.CategoryIds.Contains(pc.CategoryId)).ToList()
                .ForEach(pc => post.PostCategories.Remove(pc));
            var categoryIds = post.PostCategories.Select(pc => pc.CategoryId);
            _context.Categories.Where(c => request.CategoryIds.Except(categoryIds).Contains(c.Id)).ToList()
                .ForEach(category => _context.PostCategories.Add(new PostCategory
            {
                Category = category,
                Post = post
            }));

            _context.SaveChanges();
        }
    }
}
