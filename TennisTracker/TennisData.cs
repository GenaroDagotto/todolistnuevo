using System.Collections.Generic;

namespace TennisTracker.Models
{
    public class TennisData
    {
        public List<string> Trainings { get; set; } = new List<string>();
        public List<string> Matches { get; set; } = new List<string>();
        public List<string> Goals { get; set; } = new List<string>();
        public List<string> Notes { get; set; } = new List<string>();
    }
}