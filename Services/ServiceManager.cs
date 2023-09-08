﻿using AutoMapper;
using Entities.DataTransferObject;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;
        
        public ServiceManager(IRepositoryManager repositoryManager,ILoggerService logger,IMapper mapper,IDataShaper<BookDto> shaper)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager,logger, mapper,shaper));
        }
        public IBookService BookService => _bookService.Value;
    }
}
