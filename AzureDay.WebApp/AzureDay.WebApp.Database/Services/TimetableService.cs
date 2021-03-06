using System.Collections.Generic;
using System.Linq;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public class TimetableService : BaseService<TimetableEntity, int>
    {
        private readonly List<TimetableEntity> _timetables = new List<TimetableEntity>();

        private readonly RoomService _roomService = new RoomService();
        private readonly TopicService _topicService = new TopicService();

        protected override List<TimetableEntity> PopulateStorage()
        {
            _timetables.AddRange(new List<TimetableEntity>
            {
                new TimetableEntity { TimeStart = "8:15", TimeEnd = "9:00", Room = _roomService.CoffeeBreak, Topic = _topicService.Registration },
                new TimetableEntity { TimeStart = "10:00", TimeEnd = "10:15", Room = _roomService.CoffeeBreak},
                new TimetableEntity { TimeStart = "11:15", TimeEnd = "11:45", Room = _roomService.CoffeeBreak, Topic = _topicService.CoffeeBreak },
                new TimetableEntity { TimeStart = "12:45", TimeEnd = "13:00", Room = _roomService.CoffeeBreak },
                new TimetableEntity { TimeStart = "14:00", TimeEnd = "14:45", Room = _roomService.CoffeeBreak, Topic = _topicService.Lunch },
                new TimetableEntity { TimeStart = "15:45", TimeEnd = "16:00", Room = _roomService.CoffeeBreak },
                new TimetableEntity { TimeStart = "17:00", TimeEnd = "17:30", Room = _roomService.CoffeeBreak, Topic = _topicService.CoffeeBreak }
            });

            _timetables.AddRange(new List<TimetableEntity> // orange
			{
			    new TimetableEntity { TimeStart = "9:00", TimeEnd = "10:00", Room = _roomService.Room1, Topic = _topicService.Keynote },
                new TimetableEntity { TimeStart = "10:15", TimeEnd = "11:15", Room = _roomService.Room1, Topic = _topicService.SPoplavskiy_01 },
                new TimetableEntity { TimeStart = "11:45", TimeEnd = "12:45", Room = _roomService.Room1, Topic = _topicService.ASurkov_01 },
                new TimetableEntity { TimeStart = "13:00", TimeEnd = "14:00", Room = _roomService.Room1, Topic = _topicService.EWasilewski_01 },
                new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room1, Topic = _topicService.KBaczyk_01 },
                new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room1, Topic = _topicService.AVidishchev_01 },
                new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room1, Topic = _topicService.ABoyko_01 },
			    new TimetableEntity { TimeStart = "18:30", TimeEnd = "19:15", Room = _roomService.Room1, Topic = _topicService.Endnote }
            });

            _timetables.AddRange(new List<TimetableEntity> // blue
			{
                new TimetableEntity { TimeStart = "10:15", TimeEnd = "11:15", Room = _roomService.Room2, Topic = _topicService.SLebedenko_01 },
                new TimetableEntity { TimeStart = "11:45", TimeEnd = "12:45", Room = _roomService.Room2, Topic = _topicService.SBielskyi_01 },
                new TimetableEntity { TimeStart = "13:00", TimeEnd = "14:00", Room = _roomService.Room2, Topic = _topicService.ILeontiev_01 },
                new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room2, Topic = _topicService.SSultanov_01 },
                new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room2, Topic = _topicService.EAuberix_01 },
                new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room2, Topic = _topicService.SPoplavskiy_02 }
            });

            _timetables.AddRange(new List<TimetableEntity> // red
			{
                new TimetableEntity { TimeStart = "10:15", TimeEnd = "11:15", Room = _roomService.Room3, Topic = _topicService.VTsykunov_01 },
                new TimetableEntity { TimeStart = "11:45", TimeEnd = "12:45", Room = _roomService.Room3, Topic = _topicService.NDranchuk_01 },
                new TimetableEntity { TimeStart = "13:00", TimeEnd = "14:00", Room = _roomService.Room3, Topic = _topicService.OKrakovetskyi_02 },
                new TimetableEntity { TimeStart = "14:45", TimeEnd = "15:45", Room = _roomService.Room3, Topic = _topicService.EPolonychko_01 },
                new TimetableEntity { TimeStart = "16:00", TimeEnd = "17:00", Room = _roomService.Room3, Topic = _topicService.ILubenets_01 },
                new TimetableEntity { TimeStart = "17:30", TimeEnd = "18:30", Room = _roomService.Room3, Topic = _topicService.NMykhailenko_01 }
            });

            return _timetables;
        }

        public List<TimetableEntity> GetTimetable()
        {
            return Storage
                .OrderBy(t => t.TimeStartHours)
                .ThenBy(t => t.TimeStartMinutes)
                .ThenBy(t => t.Room.RoomType.ToString())
                .ThenBy(t => t.Room.Title)
                .ToList();
        }
    }
}