using System;

namespace CustomTimelineServiceDemo.Models.Dto
{
    [Serializable]
    public class GroupDto
    {
        public string GroupId { get; set; }
        public string DisplayName { get; set; }
        public string Color { get; set; }
        public string DisplayKey { get; set; }
    }
}