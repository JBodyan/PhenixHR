using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Entities;
using PhenixProject.Interfaces;

namespace PhenixProject.Repositories
{
    public class LinkRepository : IRepository<Link>
    {
        public IEnumerable<Link> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Link>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Link GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Link> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Link> Find(Func<Link, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Link>> FindAsync(Func<Link, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Link item)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Link item)
        {
            throw new NotImplementedException();
        }

        public void Update(Link item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Link item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
