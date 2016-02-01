using System;
using System.Xml;
using System.Xml.Serialization;

namespace CustomTimelineServiceDemo.Models.Dto
{
    [Serializable]
    public class ActivityDto
    {
        public string DisplayName { get; set; }
        public string GroupId { get; set; }
        
        [XmlIgnore]
        public DateTimeOffset StartTime { get; set; }

        [XmlElement("StartTime")]
        public string StartTimeTextValue
        {
            get { return XmlConvert.ToString(StartTime); }
            set { StartTime = XmlConvert.ToDateTimeOffset(value); }
        }

        [XmlIgnore]
        public DateTimeOffset EndTime { get; set; }

        [XmlElement("EndTime")]
        public string EndTimeTextValue
        {
            get { return XmlConvert.ToString(EndTime); }
            set { EndTime = XmlConvert.ToDateTimeOffset(value); }
        }
    }
}
