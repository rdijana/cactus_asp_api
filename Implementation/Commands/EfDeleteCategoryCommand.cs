using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly CactusContext _context;

        public EfDeleteCategoryCommand(CactusContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Deleting category";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if (category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            category.IsActive = false;
            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
