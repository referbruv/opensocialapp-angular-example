using System;

namespace OpenSocialApp.Api.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ToDoItemType ToDoType { get; set; }
        public bool IsComplete { get; set; }
        public string NoteColor { get; set; }
        public LatLng Location { get; set; }
        public DateTime ToRemindOn { get; set; }
    }

    public class LatLng
    {
        public LatLng(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public enum ToDoItemType
    {
        SimpleNote,
        Location,
        Birthday,
        Dinner
    }
}