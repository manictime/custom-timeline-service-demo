using CustomTimelineServiceDemo.Models;
using CustomTimelineServiceDemo.Models.Dto;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CustomTimelineServiceDemo.Controllers
{
    //Dto objects are easily reusable, all you need to do is fill them with your own data. You will find them in Models/Dto folder.

    /*
        Sample links:<br />
        /MTService/OnlyTimes/?fromTime=2011-03-10T00:00:00&toTime=2011-03-11T00:00:00
        /MTService/TimesAndTitle/?fromTime=2011-03-10T00:00:00&toTime=2011-03-11T00:00:00
        /MTService/ActivitiesAndGroups/?fromTime=2011-03-10T00:00:00&toTime=2011-03-11T00:00:00
    */

    public class MTServiceController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage OnlyTimes(DateTimeOffset? fromTime, DateTimeOffset? toTime)
        {
            var timeline = new TimelineDto();

            if (fromTime.HasValue && toTime.HasValue && fromTime < toTime)
            {
                var activity = new ActivityDto();
                activity.StartTime = new DateTimeOffset(fromTime.Value.Year, fromTime.Value.Month, fromTime.Value.Day, 12, 0, 0, fromTime.Value.Offset);
                activity.EndTime = activity.StartTime.AddHours(1);

                timeline.Activities = new[] { activity };
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(HelperFunctions.ToXml(timeline), Encoding.UTF8, "application/xml")
            };
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage TimesAndTitle(DateTimeOffset? fromTime, DateTimeOffset? toTime)
        {
            var timeline = new TimelineDto();

            if (fromTime.HasValue && toTime.HasValue && fromTime < toTime)
            {
                var activity = new ActivityDto();
                activity.StartTime = new DateTimeOffset(fromTime.Value.Year, fromTime.Value.Month, fromTime.Value.Day, 12, 0, 0, fromTime.Value.Offset);
                activity.EndTime = activity.StartTime.AddHours(1);
                activity.DisplayName = "My activity";

                timeline.Activities = new[] { activity };
                timeline.Color = HelperFunctions.GetRandomColor();
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(HelperFunctions.ToXml(timeline), Encoding.UTF8, "application/xml")
            };
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage ActivitiesAndGroups(DateTimeOffset? fromTime, DateTimeOffset? toTime)
        {
            var timeline = new TimelineDto();

            if (fromTime.HasValue && toTime.HasValue && fromTime < toTime)
            {
                var group = new GroupDto();
                group.Color = HelperFunctions.GetRandomColor();
                group.DisplayName = "My Group";
                group.DisplayKey = "MyGroup";
                group.GroupId = "1";

                var activity = new ActivityDto();
                activity.StartTime = new DateTimeOffset(fromTime.Value.Year, fromTime.Value.Month, fromTime.Value.Day, 12, 0, 0, fromTime.Value.Offset);
                activity.EndTime = activity.StartTime.AddHours(1);
                activity.DisplayName = "My activity";
                activity.GroupId = group.GroupId;

                timeline.Activities = new[] { activity };
                timeline.Groups = new[] { group };
                timeline.Color = HelperFunctions.GetRandomColor();
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(HelperFunctions.ToXml(timeline), Encoding.UTF8, "application/xml")
            };
        }
    }
}
