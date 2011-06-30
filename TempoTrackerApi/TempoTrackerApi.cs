using System;
using System.Collections.Generic;
using RestSharp;

namespace TempoTrackerApi
{
    public class TempoTracker
    {
        public string BaseUrl { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public TempoTracker(string username, string password, string baseUrl = null)
        {
            BaseUrl = string.IsNullOrEmpty(baseUrl) ? "https://app.keeptempo.com" : baseUrl;

            Username = username;
            Password = password;
        }

        public RestResponse Execute(RestRequest request)
        {
            var client = new RestClient
            {
                BaseUrl = BaseUrl, 
                Authenticator = new HttpBasicAuthenticator(Username, Password)
            };

            var response = client.Execute(request);
            
            return response;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient
            {
                BaseUrl = BaseUrl, 
                Authenticator = new HttpBasicAuthenticator(Username, Password)
            };

            var response = client.Execute<T>(request);
            
            return response.Data;
        }

        public RestResponse CreateEntry(DateTime occurredOn, decimal hours, string notes, int projectId, string tags)
        {
            var request = new RestRequest
            {
                Resource = "entries",
                Method = Method.POST,
            };

            // TODO: Only serialize these 5 properties
            var entry = new Entry
            {
                OccurredOn = occurredOn,
                Hours = hours, 
                Notes = notes, 
                ProjectId = projectId,
                Tags = tags
            };

            request.AddBody(entry);

            return Execute(request);
        }

        public IEnumerable<Entry> GetEntries()
        {
            var request = new RestRequest
            {
                Resource = "entries"
            };

            return Execute<List<Entry>>(request);
        }

        public IEnumerable<Project> GetProjects()
        {
            var request = new RestRequest
            {
                Resource = "projects",
            };

            request.AddParameter("per_page", 1000);

            return Execute<List<Project>>(request);
        }
    }
}