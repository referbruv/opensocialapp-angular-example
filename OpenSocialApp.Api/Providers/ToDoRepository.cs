using OpenSocialApp.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OpenSocialApp.Api.Providers
{
    public class ToDoRepository
    {
        private static List<ToDo> _toDoItems;

        public ToDoRepository()
        {
        }

        static ToDoRepository()
        {
            _toDoItems = new List<ToDo>()
            {
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Note = "Work on these items",
                    CreatedOn = DateTime.Now,
                    IsComplete = false,
                    Location = null,
                    NoteColor = "#efefef",
                    ToDoType = ToDoItemType.SimpleNote,
                    ToRemindOn = DateTime.MinValue,
                    UpdatedOn = DateTime.MinValue
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Note = "Submit these items by tomorrow",
                    CreatedOn = DateTime.Now,
                    IsComplete = false,
                    Location = null,
                    NoteColor = "#efefef",
                    ToDoType = ToDoItemType.SimpleNote,
                    ToRemindOn = DateTime.Now.AddDays(1),
                    UpdatedOn = DateTime.MinValue
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Note = "Her Birthday! Don't forget to wish!",
                    CreatedOn = DateTime.Now,
                    IsComplete = false,
                    Location = null,
                    NoteColor = "#efefef",
                    ToDoType = ToDoItemType.Birthday,
                    ToRemindOn = DateTime.Now.AddDays(5),
                    UpdatedOn = DateTime.MinValue
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Note = "Bike wash should be done here.",
                    CreatedOn = DateTime.Now,
                    IsComplete = false,
                    NoteColor = "#efefef",
                    ToDoType = ToDoItemType.Location,
                    ToRemindOn = DateTime.MinValue,
                    UpdatedOn = DateTime.MinValue,
                    Location = new LatLng(37.7510, -97.8220)
                },
            };
        }

        public IQueryable<ToDo> ToDos => _toDoItems.AsQueryable();

        public List<ToDo> Get(Expression<Func<ToDo, bool>> predicate)
        {
            return ToDos.Where(predicate).OrderByDescending(x => x.UpdatedOn).ToList();
        }

        public ToDo GetSingle(Guid id)
        {
            return Get(x => x.Id == id).FirstOrDefault();
        }

        public ToDo CreateSingle(ToDo item)
        {
            var newItem = new ToDo();
            newItem.Note = item.Note;
            newItem.IsComplete = false;
            newItem.NoteColor = item.NoteColor;
            newItem.ToDoType = item.ToDoType;
            newItem.ToRemindOn = item.ToRemindOn;
            newItem.UpdatedOn = DateTime.Now;
            newItem.CreatedOn = DateTime.Now;
            newItem.Id = Guid.NewGuid();

            _toDoItems.Add(newItem);
            return newItem;
        }

        public void DeleteSingle(Guid id)
        {
            var item = GetSingle(id);
            var index = _toDoItems.IndexOf(item);

            _toDoItems.RemoveAt(index);
        }

        public ToDo UpdateSingle(Guid id, ToDo updated)
        {
            var unmodified = GetSingle(id);
            var index = _toDoItems.IndexOf(unmodified);

            if (unmodified != null)
            {
                if (updated.Note != null && unmodified.Note != updated.Note)
                    unmodified.Note = updated.Note;
                if (updated.NoteColor != null && unmodified.NoteColor != updated.NoteColor)
                    unmodified.NoteColor = updated.NoteColor;
                if (unmodified.ToDoType != updated.ToDoType)
                    unmodified.ToDoType = updated.ToDoType;
                if (unmodified.IsComplete != updated.IsComplete)
                    unmodified.IsComplete = updated.IsComplete;
                if (updated.ToRemindOn != DateTime.MinValue && unmodified.ToRemindOn != updated.ToRemindOn)
                    unmodified.ToRemindOn = updated.ToRemindOn;

                unmodified.UpdatedOn = DateTime.Now;

                _toDoItems.Insert(index, updated);
            }
            return unmodified;
        }
    }
}
