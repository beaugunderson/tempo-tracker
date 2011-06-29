namespace TempoTrackerApi
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Project()
        {
        }

        public Project(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}