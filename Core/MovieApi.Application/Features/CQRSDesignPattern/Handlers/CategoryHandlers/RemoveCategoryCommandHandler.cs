using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly MovieContext _context;

        public RemoveCategoryCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(RemoveCategoryCommand command)
        {

            var value = await _context.Categories.FindAsync(command.CategoryId);
            
            if(value == null)
            {
                throw new KeyNotFoundException($"Category with id {command.CategoryId} not found.");
            }
            else
            {
                _context.Categories.Remove(value);
                await _context.SaveChangesAsync();
            }
                
        }


    }
}
