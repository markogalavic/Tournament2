using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markoGalavićTournamentTracker
{
    public class MatchUpEntryModel
    {
        public int Id { get; set; }
        public int TeamCompetingId { get; set; }
        public TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        public int ParentMatchupId { get; set; }
        public MatchUpModel ParentMatchup { get; set; }
       
    }
}
