using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PhenixProject.Entities;
using PhenixProject.Interfaces;
using PhenixProject.Models;

namespace PhenixProject.Services
{
    public class HistoryService : IHistoryService
    {

        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public HistoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddHistoryAsync(HistoryViewModel model)
        {
            var history = _mapper.Map<EmployeeHistory>(model);
            await _db.Histories.CreateAsync(history);
            _db.Save();
        }

        public async Task<IEnumerable<HistoryViewModel>> GetHistoryByMemberIdAsync(Guid id)
        {
            var histories = (await _db.Members.GetByIdAsync(id)).EmployeeInfo.Histories;
            return _mapper.Map<IEnumerable<HistoryViewModel>>(histories);
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
