using System;
using System.Xml.Serialization;

namespace CustomTimelineServiceDemo.Models.Dto
{
    [Serializable]
    [XmlRoot("Timeline")]
    public class TimelineDto
    {
        public string Color { get; set; }

        public string DisplayName { get; set; }

        [XmlArrayItem("Activity")]
        public ActivityDto[] Activities { get; set; }

        [XmlArrayItem("Group")]
        public GroupDto[] Groups { get; set; }
    }
}