using CsvHelper;
using CsvHelper.Configuration;
using ParseExeptions.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO; // Output, Input
using System.Linq;
using static System.Console;


namespace ParseExeptions.DBcontext
{
    class DBContext
    {
        public string filePath = @".\bugs-2002.csv";
        public List<Ticket> Tickets = new List<Ticket>();

        public void ReadFromFile()
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var CsvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    CsvReader.Context.RegisterClassMap(typeof(EntityMap));
                    Tickets.AddRange(CsvReader.GetRecords<Ticket>());
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void SaveAsStatistic(string pathToSave)
        {


            string[] priorities = { "Blocker", "Critical", "Major", "Medium", "Minor", "Normal", "Total", "Unresolved" };
            string[] Labels = { "TEAM_BEAUJOLAIS", "TEAM_BORDEAUX", "TEAM_BURGUNDY", "TEAM_LOIRE", "TEAM_PROVENCE", "TEAM_RHONE", "MISC" };

            List<Team> Teams = new List<Team>();

            foreach (var priority in priorities)
            {
                Team team = new Team();
                team.Name = priority;

                foreach (var label in Labels)
                {
                    switch (priority)
                    {
                        case "Unresolved":
                            team.GetType().GetProperty(label).SetValue(team,
                                Tickets.Count(ticket => !ticket.Status.Contains("Closed") && ticket.Labels == label));
                            break;
                        case "Total":
                            team.GetType().GetProperty(label)
                                .SetValue(team, Tickets.Count(ticket => ticket.Labels == label));
                            break;
                        default:
                            int count = Tickets.Count(ticket => ticket.Priority == priority && ticket.Labels == label);
                            team.GetType().GetProperty(label).SetValue(team, count);
                            break;
                    }
                }

                Teams.Add(team);
            }



            try
            {
                using (var writer = new StreamWriter(pathToSave))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.Context.RegisterClassMap(typeof(TeamInfoMap));
                    csvWriter.WriteRecords<Team>(Teams);
                }
            }
            catch (Exception e) {
                WriteLine(e.Message);
            }

        }
    };

    public sealed class EntityMap : ClassMap<Ticket>
    {
        public EntityMap()
        {
            Map(m => m.Key).Name("Key");
            Map(m => m.Summary).Name("Summary");
            Map(m => m.Status).Name("Status");
            Map(m => m.Assignee).Name("Assignee");
            Map(m => m.Labels).Name("Labels");
            Map(m => m.FixVersion).Name("Fix Version/s");
            Map(m => m.Reporter).Name("Reporter");
            Map(m => m.IssueType).Name("Issue Type");
            Map(m => m.OriginalEstimate).Name("? Original Estimate");
            Map(m => m.Priority).Name("Priority");
            Map(m => m.Sprint).Name("Sprint");
            Map(m => m.DueDate).Name("Due Date");
            Map(m => m.Created).Name("Created");
            Map(m => m.QADueDate).Name("QA Due Date");
        }
    }
    public sealed class TeamInfoMap : ClassMap<Team>
    {
        public TeamInfoMap()
        {
            Map(m => m.Name).Name("");
            Map(m => m.TEAM_BEAUJOLAIS).Name("TEAM_BEAUJOLAIS");
            Map(m => m.TEAM_BORDEAUX).Name("TEAM_BORDEAUX");
            Map(m => m.TEAM_BURGUNDY).Name("TEAM_BURGUNDY");
            Map(m => m.TEAM_LOIRE).Name("TEAM_LOIRE");
            Map(m => m.TEAM_PROVENCE).Name("TEAM_PROVENCE");
            Map(m => m.TEAM_RHONE).Name("TEAM_RHONE");
            Map(m => m.MISC).Name("MISC");
            Map(m => m.Total).Name("Total");

        }
    }
}
