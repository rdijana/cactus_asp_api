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
    public class EfDeleteMarkCommand : IDeleteMarkCommand
    {
        private readonly CactusContext _context;
        private readonly IApplicationActor _actor;

        public EfDeleteMarkCommand(CactusContext context,IApplicationActor actor)
        {
            _context = context;
            _actor = actor;
        }

        public int Id => 15;

        public string Name => "Deleting mark";

        public void Execute(int request)
        {
            var mark = _context.Marks.FirstOrDefault(x => x.Id == request && x.UserId == _actor.Id);

            if (mark == null)
            {
                throw new EntityNotFoundException(request, typeof(Mark));
            }

            mark.IsActive = false;
            mark.IsDeleted = true;
            mark.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();


        }
    }
}
