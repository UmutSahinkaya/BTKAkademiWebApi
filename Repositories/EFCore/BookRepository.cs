﻿using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    //sealed sınıfı zırhlıyor ve miras alınmasını engelliyoruz
    public sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {

        }
        public void UpdateOneBook(Book book) => Update(book);
        public void CreateOneBook(Book book) => Create(book);
        public void DeleteOneBook(Book book) => Delete(book);
        public async Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,
            bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                             .FilterBooks(bookParameters.MinPrice,bookParameters.MaxPrice)
                             .Search(bookParameters.SearchTerm)
                             .Sort(bookParameters.OrderBy)
                             .ToListAsync();

            return PagedList<Book>
                .ToPagedList(books,
                bookParameters.PageNumber,
                bookParameters.PageSize);
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books=await FindAll(trackChanges).OrderBy(b=>b.Id).ToListAsync();
            return books;
        }

        public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges)
        {
            var bookDetails=await _context.Books.Include(b=>b.Category)
                .OrderBy(b=>b.Id).ToListAsync(); 
            return bookDetails;
        }
    }
}
