using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using markoGalavićTournamentTracker.DataAcces.TextHelpers;

namespace markoGalavićTournamentTracker
{
    public class TextConnector : IDataConnection
    {
        
        public void CreatePerson(PersonModel model)
        {
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;
            if (people.Count>0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            people.Add(model);
            people.SaveToPeopleFile();
           
        }

        public void CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = GlobalConfig.PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            int currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;

            model.Id = currentId;

            prizes.Add(model);

            prizes.SaveToPrizeFile();

            
        }

        public void CreateTeam(TeamModel model)
        {
           List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            teams.Add(model);

            teams.SaveToTeamFile();
            
        }
        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentsModels();

            int currentId = 1;
            if (tournaments.Count > 0)
            {
              currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
               model.Id = currentId;
               tournaments.Add(model);
               model.SaveRoundsToFile();
               tournaments.SaveToTournamentFile();
               }

        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentsModels();
        }

        public void UptadeMatchup(MatchUpModel model)
        {
            model.UpdateMatchUpToFile();
        }
    }
}
