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
    public class CalendarService : ICalendarService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public CalendarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            _mapper = mapper;
        }
        public CalendarEventViewModel GetEventById(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<CalendarEventViewModel> GetEventByIdAsync(Guid eventId)
        {
            var calendarEvent = await _db.CalendarEvents.GetByIdAsync(eventId);
            return _mapper.Map<CalendarEventViewModel>(calendarEvent);
        }

        public IEnumerable<CalendarEventViewModel> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalendarEventViewModel>> GetAllEventsAsync()
        {
            var calendarEvents = await _db.CalendarEvents.GetAllAsync();
            return _mapper.Map<IEnumerable<CalendarEventViewModel>>(calendarEvents);
        }

        public IEnumerable<CalendarEventViewModel> GetEventsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CalendarEventViewModel>> GetEventsByDateAsync(DateTime date)
        {
            var calendarEvents = await _db.CalendarEvents.FindAsync(x=>x.StartDate == date);
            return _mapper.Map<IEnumerable<CalendarEventViewModel>>(calendarEvents);
        }

        public void AddEvent(CalendarEventViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task AddEventAsync(CalendarEventViewModel model)
        {
            var calendarEvent = _mapper.Map<CalendarEvent>(model);
            await _db.CalendarEvents.CreateAsync(calendarEvent);
            _db.Save();
        }

        public void UpdateEvent(CalendarEventViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEventAsync(CalendarEventViewModel model)
        {
            var calendarEvent = await _db.CalendarEvents.GetByIdAsync(model.Id);
            if (calendarEvent != null)
            {
                calendarEvent.StartDate = model.StartDate;
                calendarEvent.EndDate = model.EndDate;
                calendarEvent.Color = model.Color;
                calendarEvent.Description = model.Description;
                calendarEvent.Title = model.Title;
            }
            await _db.CalendarEvents.UpdateAsync(calendarEvent);
            _db.Save();
        }

        public async Task RemoveEventAsync(Guid id)
        {
            await _db.CalendarEvents.DeleteAsync(id);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
