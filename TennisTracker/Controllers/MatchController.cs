using TennisTracker.Models;
using System.Collections.Generic;

namespace TennisTracker.Controllers
{
    public class MatchController
    {
        private List<MatchItem> matches = new List<MatchItem>();

        public void AddMatch(MatchItem match)
        {
            matches.Add(match);
        }

        public void RemoveMatch(MatchItem match)
        {
            matches.Remove(match);
        }

        // ESTE ES EL MÉTODO QUE FALTA
        public List<MatchItem> GetAllMatches()
        {
            return matches;
        }
    }
}