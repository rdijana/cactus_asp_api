using Application;
using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly CactusContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteCommentCommand(CactusContext context, IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 12;

        public string Name => "Deleting comment";

        public void Execute(int request)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == request && x.UserId == _actor.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException(request, typeof(Comment));
            }

            comment.IsActive = false;
            comment.IsDeleted = true;
            comment.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();

            
        }
    }
}
