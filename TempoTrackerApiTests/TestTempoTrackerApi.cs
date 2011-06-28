using System;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TempoTrackerApi;

namespace TempoTrackerApiTests
{
    [TestClass]
    public class TestTempoTrackerApi
    {
        [TestMethod]
        public void TestGetProjects()
        {
            var api = new TempoTracker("nwcr@nwcr.net", "e7EPtd17", "https://kempit.keeptempo.com");

            var projects = api.GetProjects();

            foreach (var project in projects)
            {
                Trace.WriteLine(string.Format("{0} {1}", project.Id, project.Name));
            }
        }

        [TestMethod]
        public void TestGetEntries()
        {
            var api = new TempoTracker("beaugunderson", "pukechugger", "https://kempit.keeptempo.com");

            var entries = api.GetEntries();

            foreach (var entry in entries)
            {
                Trace.WriteLine(string.Format("{0} {1}", entry.Id, entry.Notes));
            }
        }

        [TestMethod]
        public void TestCreateEntry()
        {
            var api = new TempoTracker("beaugunderson", "pukechugger", "https://kempit.keeptempo.com");

            var result = api.CreateEntry(DateTime.Now, 5, "Testing...", 4647, "tag1 tag2 tag3");

            Trace.WriteLine(result.ResponseStatus);
        }
    }
}
