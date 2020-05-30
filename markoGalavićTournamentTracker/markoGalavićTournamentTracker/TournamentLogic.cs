using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markoGalavićTournamentTracker
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);
            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(model, rounds);
        }
       
        }
        private static void CreateOtherRounds(TournamentModel model ,int rounds)
        {
            int round = 2;
            List<MatchUpModel> previusRound = model.Rounds[0];
            List<MatchUpModel> currRound = new List<MatchUpModel>();
            MatchUpModel currMatchUp = new MatchUpModel();
            while (round <= rounds)
            {
                foreach (MatchUpModel match in previusRound)
                {
                    currMatchUp.Entries.Add(new MatchUpEntryModel { ParentMatchup=match });
                    if (currMatchUp.Entries.Count>1)
                    {
                        currMatchUp.MatchUpRound = round;
                        currRound.Add(currMatchUp);
                        currMatchUp = new MatchUpModel();
                    }
                    model.Rounds.Add(currRound);
                    previusRound = currRound;
                    currRound = new List<MatchUpModel>();
                    round += 1;
                }
            }
        }
        private static List<MatchUpEntryModel>CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();
            MatchUpModel curr = new MatchUpModel();
            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchUpEntryModel { TeamCompeting = team });
                if (byes > 0 || curr.Entries.Count>1)
                {
                    curr.MatchUpRound = 1;
                    output.Add(curr);
                    curr = new MatchUpModel();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }
        private static int NumberOfByes(int rounds,int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 0;
            for (int i=1 ;i<=rounds;i++)
            {
                totalTeams *= 2;
            }
            output = totalTeams - numberOfTeams;
            return output;
        }
        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }
            return output;
        }
    private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
    {
        return teams.OrderBy(x => Guid.NewGuid()).ToList();
    }
    
    public static void UpdateTournamentResult(TournamentModel model)
    {
        List<MatchUpModel> toScore = new List<MatchUpModel>();
        foreach (List<MatchUpModel>round in model.Rounds)
        {
            foreach (MatchUpModel rm in round)
            {
                if(rm.Winner==null &&(rm.Entries.Any(x=>x.Score!=0) || rm.Entries.Count == 1))
                {
                    toScore.Add(rm);
                }
            }
        }
        MarkWinnerInMatchups(toScore);
        AdvanceWinners(toScore,model);
    }
    private static void MarkWinnerInMatchups(List<MatchUpModel>models)
    {
        string greaterWins = ConfigurationManager.AppSettings["greaterWins"];
        foreach (MatchUpModel m in models)
        {
            if (m.Entries.Count == 1)
            {
                m.Winner = m.Entries[0].TeamCompeting;
                continue;
            }
            if (greaterWins == "0")
            {
                if (m.Entries[0].Score < m.Entries[1].Score)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                }
                else if (m.Entries[1].Score < m.Entries[0].Score)
                {
                    m.Winner = m.Entries[1].TeamCompeting;
                }
                else
                {
                    throw new Exception("We do not allow ties in this application");
                }
            }
            else
            {
                if (m.Entries[0].Score > m.Entries[1].Score)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                }
                else if (m.Entries[1].Score > m.Entries[0].Score)
                {
                    m.Winner = m.Entries[1].TeamCompeting;
                }
                else
                {
                    throw new Exception("We do not allow ties in this application");
                }
            }
        }
    }
    private static void AdvanceWinners(List<MatchUpModel> models,TournamentModel tournament)
    {
        foreach (MatchUpModel m in models)
        {
            foreach (List<MatchUpModel>round in tournament.Rounds)
            {
                foreach (MatchUpModel rm in round)
                {
                    foreach (MatchUpEntryModel me in rm.Entries)
                    {
                        if (me.ParentMatchup != null)
                        {
                            if (me.ParentMatchup.Id==m.Id)
                            {
                                me.TeamCompeting = m.Winner;
                                GlobalConfig.Connection.UpdateMatchup(rm);
                            }
                        }
                    }
                }
            }
        }
    }
    }

