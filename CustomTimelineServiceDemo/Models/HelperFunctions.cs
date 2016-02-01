using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CustomTimelineServiceDemo.Models
{
    public class HelperFunctions
    {
        public static string GetRandomColor()
        {
            var random = new Random((int)DateTime.Now.Ticks);
            var randomColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            return randomColor.R.ToString("X2") + randomColor.G.ToString("X2") + randomColor.B.ToString("X2");
        }

        public static string ToXml<T>(T timeline)
        {
            var encoding = Encoding.UTF8;
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                var writer = XmlWriter.Create(stream, new XmlWriterSettings() { Encoding = encoding });
                serializer.Serialize(writer, timeline);
                writer.Close();
                return encoding.GetString(stream.ToArray());
            }
        }
    }
}