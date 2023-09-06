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
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(AppDbContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        }

        public IBookRepository Book => _bookRepository.Value;//nesne kullanıldığı anda new lenecek!! 

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
