using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace markoGalavićTournamentTracker.DataAcces.TextHelpers
{
    public static class TextConnectorProccesor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string>LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }
        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach(string line in lines)
            {
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAddress = cols[3];
                p.CellphoneNumber =cols[4];
               
            }
            return output;
        }
        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                TeamModel t = new TeamModel();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string Id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x =>x.Id==int.Parse(Id)).First());
                }
                output.Add(t);
            }
            return output;
        }
        public static List<TournamentModel> ConvertToTournamentsModels(this List<string>lines) {
            //id,TournamentName,EntryFee,(id|id|id-Entered Teams),(id|id|id -Prizes),(Rounds-id^id^id^|id^id^id^|id^id^id^)
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<PrizeModel>prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchUpModel> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchUpModels();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TournamentModel tm = new TournamentModel();
                tm.Id = int.Parse(cols[0]);
                tm.TournamentName = cols[1];
                tm.EntryFee = decimal.Parse(cols[2]);

                string[] teamIds = cols[2].Split('|');
                foreach (string Id in teamIds)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(Id)).First());
                }
                if (cols[4].Length>0) {
                    string[] prizeId = cols[4].Split('|');

                    foreach (string Id in prizeId)
                    {
                        tm.Prizes.Add(prizes.Where(x => x.Id == int.Parse(Id)).First());
                    }
                }
               
                string[] rounds = cols[5].Split('|');
                foreach (string round in rounds)
                {
                   
                    string[] msText = round.Split('^');
                    List<MatchUpModel> ms = new List<MatchUpModel>();
                    foreach (string matchupModelTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                    }
                    tm.Rounds.Add(ms);
                }
                output.Add(tm);

            }
            return output;
        }
        public static void SaveToPrizeFile(this List<PrizeModel>models)
        {
            List<string> lines = new List<string>();

            foreach(PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }
            File.WriteAllLines(GlobalConfig.PrizesFile.FullFilePath(), lines);
        }
        public static void SaveToPeopleFile(this List<PersonModel>models)
        {
            List<string> lines = new List<string>();
            foreach(PersonModel p in models)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
                File.WriteAllLines(GlobalConfig.PeopleFile.FullFilePath(), lines);
            }
        }
        public static void SaveToTeamFile(this List<TeamModel> models)
        {
            List<string> lines = new List<string>();
            foreach (TeamModel t in models)
            {
                lines.Add($"{t.Id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
            }
            File.WriteAllLines(GlobalConfig.TeamFile.FullFilePath(), lines);
        }
        public static void SaveToTournamentFile(this List<TournamentModel>models)
        {
            List<string> lines = new List<string>();
            foreach (TournamentModel tm in models)
            {
                lines.Add($"{tm.Id},{tm.TournamentName},{tm.EntryFee}{ConvertTeamListToString(tm.EnteredTeams)},{ConvertPrizeListToString(tm.Prizes)}");
            }
            File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
        }
        public static void SaveRoundsToFile(this TournamentModel model)
        {
            foreach (List<MatchUpModel> round in model.Rounds)
            {
                foreach (MatchUpModel matchup in round)
                {
                    matchup.SaveMatchUpToFile();
                }
            }
        }
        public static void UpdateMatchUpToFile(this MatchUpModel matchup)
        {
            List<MatchUpModel> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchUpModels();
            MatchUpModel oldMatchUp = new MatchUpModel();

            foreach (MatchUpModel m in matchups)
            {
                if (m.Id==matchup.Id)
                {
                    oldMatchUp = m;
                }
            }
            matchups.Remove(oldMatchUp);
            matchups.Add(matchup);
            foreach (MatchUpEntryModel entry in matchup.Entries)
            {
                entry.UpdateEntryToFile();
            }
            List<string> lines = new List<string>();
            foreach (MatchUpModel m in matchups)
            {
                string winner = "";
                if (m.Winner!=null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchUpEntryListToString(m.Entries)},{winner},{m.MatchUpRound}");
            }
            File.WriteAllLines(GlobalConfig.MatchUpFile.FullFilePath(),lines);
        }
        public static List<MatchUpEntryModel> ConvertToMatchUpEntryModels(this List<string>lines)
        {
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchUpEntryModel me = new MatchUpEntryModel();
                me.Id = int.Parse(cols[0]);
                me.TeamCompeting = LookUpTeamById(int.Parse(cols[1]));
                me.Score = double.Parse(cols[2]);
                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    me.ParentMatchup = LookUpMatchupById(int.Parse(cols[3]));
                }
                else
                {
                    me.ParentMatchup = null;
                }

                output.Add(me);
            }
            return output;
        }
        private static List<MatchUpEntryModel> ConvertStringToMatchUpEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchUpEntryModel> output = new List<MatchUpEntryModel>();
            List<string> entries = GlobalConfig.MatchUpEntryFile.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();
            foreach (string id in ids)
            {
               foreach(string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0]==id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchUpEntryModels();
            return output;
        }
        private static TeamModel LookUpTeamById(int id)
        {
            List<string> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile();
            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels(GlobalConfig.PeopleFile).First();
                }
            }
            return null;
        }
        private static MatchUpModel LookUpMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile();
            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);
                    return matchingMatchups.ConvertToMatchUpModels().First();
                }
            }
            return null;
        }
        public static List<MatchUpModel> ConvertToMatchUpModels(this List<string> lines)
        {
            List<MatchUpModel> output = new List<MatchUpModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchUpModel p = new MatchUpModel();
                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchUpEntryModels(cols[1]);
                p.Winner = LookUpTeamById(int.Parse(cols[2]));
                p.MatchUpRound = int.Parse(cols[3]);
               
                output.Add(p);
            }
            return output;
        }
        public static void SaveMatchUpToFile(this MatchUpModel matchup)
        {
            List<MatchUpModel> matchups = GlobalConfig.MatchUpFile.FullFilePath().LoadFile().ConvertToMatchUpModels();
            int currentId = 1;
            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }
            matchup.Id = currentId;
            matchups.Add(matchup);
         
            foreach (MatchUpEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile();
            }
            List<string> lines = new List<string>();
            foreach (MatchUpModel m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchUpEntryListToString(m.Entries)},{winner},{m.MatchUpRound}");
            }

        }
        public static void SaveEntryToFile(this MatchUpEntryModel entry)
        {
            List<MatchUpEntryModel> entries = GlobalConfig.MatchUpEntryFile.FullFilePath().LoadFile().ConvertToMatchUpEntryModels();
            int currentId = 1;
            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            entry.Id = currentId;
            entries.Add(entry);

            List<string> lines = new List<string>();
            foreach (MatchUpEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchup !=null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (e.TeamCompeting!=null)
                {
                    teamCompeting = e.TeamCompeting.Id.ToString();
                }
                lines.Add($"{e.Id},{e.TeamCompeting.Id},{e.Score},{e.ParentMatchup.Id}");
                File.WriteAllLines(GlobalConfig.MatchUpEntryFile.FullFilePath(),lines);
            }
        }
        public static void UpdateEntryToFile(this MatchUpEntryModel entry)
        {
            List<MatchUpEntryModel> entries = GlobalConfig.MatchUpEntryFile.FullFilePath().LoadFile().ConvertToMatchUpEntryModels();
            MatchUpEntryModel oldEntry = new MatchUpEntryModel();
            foreach (MatchUpEntryModel e in entries)
            {
                if (e.Id==entry.Id)
                {
                    oldEntry = e;
                }
            }
            entries.Remove(oldEntry);
            entries.Add(entry);
            List<string> lines = new List<string>();
            foreach (MatchUpEntryModel e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string teamCompeting = "";
                if (e.TeamCompeting != null)
                {
                    teamCompeting = e.TeamCompeting.Id.ToString();
                }
                lines.Add($"{e.Id},{e.TeamCompeting.Id},{e.Score},{e.ParentMatchup.Id}");
                File.WriteAllLines(GlobalConfig.MatchUpEntryFile.FullFilePath(), lines);
            }
        }
        private static string ConvertRoundListToString(List<List<MatchUpModel>> rounds)
        {
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }
            foreach (List<MatchUpModel> r in rounds)
            {
                output += $"{ConvertMatchupListToString(r)}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertTeamListToString(List<TeamModel>teams )
        {
            string output = "";
            if (teams.Count == 0)
            {
                return "";
            }
            foreach (TeamModel t in teams)
            {
                output += $"{t.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return "";
            }
            foreach (PrizeModel t in prizes)
            {
                output += $"{t.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchUpEntryListToString(List<MatchUpEntryModel> entries)
        {
            string output = "";
            if (entries.Count == 0)
            {
                return "";
            }
            foreach (MatchUpEntryModel e in entries)
            {
                output += $"{e.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchupListToString(List<MatchUpModel> matchups)
        {
            string output = "";
            if (matchups.Count == 0)
            {
                return "";
            }
            foreach (MatchUpModel m in matchups)
            {
                output += $"{m.Id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPeopleListToString(List<PersonModel> people)
        {
            string output = "";
            if (people.Count == 0)
            {
                return "";
            }
            foreach (PersonModel p in people)
            {
                output += $"{p.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
