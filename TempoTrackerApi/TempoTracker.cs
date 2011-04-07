using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace TempoTrackerApi
{
    public class TempoTracker
    {
        private string ApiUrl { get; set; }

        private string Username { get; set; }
        private string Password { get; set; }

        public TempoTracker(string apiUrl, string username, string password)
        {
            ApiUrl = apiUrl;

            Username = username;
            Password = password;
        }

        public IEnumerable<Project> GetEvents()
        {
            var projects = new Collection<Project>();

            var reader = CreateReader(string.Format("{0}/projects.xml?per_page=1000", ApiUrl));

            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || reader.Name != "project")
                {
                    continue;
                }

                reader.ReadToDescendant("id");

                int id = Convert.ToInt32(reader.ReadString());

                reader.ReadToFollowing("name");

                string name = reader.ReadString();

                projects.Add(new Project(id, name));
            }

            return projects;
        }

        private XmlReader CreateReader(string url, string xml = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            request.AllowAutoRedirect = false;
            request.UserAgent = "TempoTracker.NET";
            request.Method = "GET";
            request.Credentials = new NetworkCredential(Username, Password);
            request.Accept = "application/xml";
            request.ContentType = "application/xml";

            if (!String.IsNullOrEmpty(xml))
            {
                var byteData = Encoding.UTF8.GetBytes(xml);

                request.ContentLength = byteData.Length;
                request.Method = "POST";

                using (var postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }
            }

            try
            {
                var response = request.GetResponse() as HttpWebResponse;

                if (response == null)
                {
                    return null;
                }

                var stream = response.GetResponseStream();

                if (stream == null)
                {
                    return null;
                }

                var reader = new StreamReader(stream);

                try
                {
                    return XmlReader.Create(reader);
                }
                catch (XmlException exception)
                {
                    Console.WriteLine(exception);
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception);

                return null;
            }

            return null;
        }

        public bool CreateEvent(decimal hours, string notes, DateTime dateTime, int id, string tags)
        {
            string xml =
                string.Format(
                    "<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry><hours>{0:N2}</hours><notes>{1}</notes><project-id>{2:G}</project-id><occurred-on>{3:s}</occurred-on><tag-s>{4}</tag-s></entry>",
                    hours, notes, id, dateTime, tags);

            string url = string.Format("{0}/entries", ApiUrl);

            var reader = CreateReader(url, xml);

            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element)
                {
                    continue;
                }

                if (reader.Name == "entry")
                {
                    return true;
                }
            }

            return false;
        }
    }
}