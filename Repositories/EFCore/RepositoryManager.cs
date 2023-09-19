using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(ICategoryRepository categoryRepository, IBookRepository bookRepository, AppDbContext context)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _context = context;
        }

        public IBookRepository Book => _bookRepository;//nesne kullanıldığı anda new lenecek!! 
        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
