using System;
using System.Xml.Serialization;
using RestSharp.Serializers;

namespace TempoTrackerApi
{
    [Serializable]
    [SerializeAs(Name="entry")]
    public class Entry
    {
        /*
   <entry>
    <command nil="true"></command>
    <creator-id type="integer">3567</creator-id>
    <hours type="decimal">1.0</hours>
    <id type="integer">90411</id>
    <is-locked type="boolean">true</is-locked>
    <is-timing type="boolean">false</is-timing>
    <notes>New images for Keith.</notes>
    <occurred-on type="date">2009-02-26</occurred-on>
    <project-id type="integer">4647</project-id>
    <source>app</source>
    <timer-sessions nil="true"></timer-sessions>
    <user-id type="integer">3567</user-id>
    <tag-s></tag-s>
    <user>
      <email>beau@beaugunderson.com</email>
      <id type="integer">3567</id>
      <is-active type="boolean">true</is-active>
      <login>beaugunderson</login>
      <name>Beau Gunderson</name>
    </user>
    <creator>
      <email>beau@beaugunderson.com</email>
      <id type="integer">3567</id>
      <is-active type="boolean">true</is-active>
      <login>beaugunderson</login>
      <name>Beau Gunderson</name>
    </creator>
    <project>
      <id>4647</id>
      <name>NWIRP</name>
    </project>
  </entry>
        */

        [SerializeAs(Name="hours")]
        public decimal Hours { get; set; }
        
        [SerializeAs(Name="notes")]
        public string Notes { get; set; }
        
        [SerializeAs(Name="project-id")]
        public int ProjectId { get; set; }

        [SerializeAs(Name="tag-s")]
        public string Tags { get; set; }

        [SerializeAs(Name="occurred-on")]
        public DateTime OccurredOn { get; set; }

        [SerializeAs(Name="id")]
        public int Id { get; set; }

        [SerializeAs(Name="source")]
        public string Source { get; set; }

        [SerializeAs(Name="user-id")]
        public int UserId { get; set; }

        [SerializeAs(Name="project")]
        public Project Project { get; set; }
    }
}
