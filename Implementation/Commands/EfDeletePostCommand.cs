using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly CactusContext _context;

        public EfDeletePostCommand(CactusContext context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "Deleting post";

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);

            if (post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }

            post.IsActive = false;
            post.IsDeleted = true;
            post.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
