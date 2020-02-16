using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using PhenixProject.Data;

namespace PhenixProject.Repositories
{
    public class PositionRepository : IRepository<Position>
    {

        private readonly AppIdentityDbContext _db;

        public PositionRepository(AppIdentityDbContext appContext)
        {
            _db = appContext;
        }

        public IEnumerable<Position> GetAll()
        {
            return _db.Positions;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return _db.Positions;
        }

        public Position GetById(Guid id)
        {
            var position = _db.Positions.FirstOrDefault(x => x.Id == id);
            return position;
        }

        public async Task<Position> GetByIdAsync(Guid id)
        {
            var position = await _db.Positions.FirstOrDefaultAsync(x => x.Id == id);
            return position;
        }

        public IEnumerable<Position> Find(Func<Position, bool> predicate)
        {
            var position = _db.Positions.Where(predicate).ToList();
            return position;
        }

        public async Task<IEnumerable<Position>> FindAsync(Func<Position, bool> predicate)
        {
            var position = _db.Positions.Where(predicate).ToList();
            return position;
        }

        public void Create(Position item)
        {
            _db.Add(item);
        }

        public async Task CreateAsync(Position item)
        {
            await _db.AddAsync(item);
        }

        public void Update(Position item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public async Task UpdateAsync(Position item)
        {
            _db.Entry(item).State = EntityState.Modified;
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
