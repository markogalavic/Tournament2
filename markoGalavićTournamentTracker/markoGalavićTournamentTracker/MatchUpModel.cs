using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markoGalavićTournamentTracker
{
    public class MatchUpModel
    {
        public int Id { get; set; }
        public List<MatchUpEntryModel> Entries { get; set; } = new List<MatchUpEntryModel>();
        public int WinnerId { get; set; }
        public TeamModel Winner { get; set; }
        public int MatchUpRound { get; set; }
        public string DisplayName {
            get
            {
                string output="";
                foreach (MatchUpEntryModel me in Entries)
                {
                    if (me.TeamCompeting !=null) {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. {me.TeamCompeting.TeamName}";
                        }
                    }
                    else
                    {
                        output = "Matchup Not Yet Determined";
                        break;
                    }
                }
                return output;
            }
        }
    }
}
