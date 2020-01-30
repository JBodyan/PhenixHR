using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhenixProject.Models;

namespace PhenixProject.Interfaces
{
    interface ICalendarService
    {
        CalendarEventViewModel GetEventById(Guid eventId);
        Task<CalendarEventViewModel> GetEventByIdAsync(Guid eventId);
        IEnumerable<CalendarEventViewModel> GetAllEvents();
        Task<IEnumerable<CalendarEventViewModel>> GetAllEventsAsync();
        IEnumerable<CalendarEventViewModel> GetEventsByDate(DateTime date);
        Task<IEnumerable<CalendarEventViewModel>> GetEventsByDateAsync(DateTime date);
        void AddEvent(CalendarEventViewModel model);
        Task AddEventAsync(CalendarEventViewModel model);
        void UpdateEvent(CalendarEventViewModel model);
        Task UpdateEventAsync(CalendarEventViewModel model);
        Task RemoveEventAsync(Guid id);
        void Dispose();
    }
}
