using markoGalavićTournamentTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerUI
{
    public partial class TournamentViewer : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchUpModel> selectedMatchups = new BindingList<MatchUpModel>();

        
        public TournamentViewer(TournamentModel tournamentModel)
        {
            InitializeComponent();
            tournament = tournamentModel;
            WireUpLists();
            LoadFormData();
            LoadRounds();
           
        }
        private void WireUpLists()
        {
            matchuplistBox1.DataSource = selectedMatchups;
            matchuplistBox1.DisplayMember = "DisplayName";
            roundValue.DataSource = rounds;
        }
        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }
        private void LoadRounds()
        {
            
            rounds.Clear();
            rounds.Add(1);
            int currRound = 1;
            foreach (List<MatchUpModel>matchups in tournament.Rounds)
            {
                if (matchups.First().MatchUpRound>currRound)
                {
                    currRound = matchups.First().MatchUpRound;
                    rounds.Add(currRound);
                }
            }
            LoadMatchUps(1);
        }

        private void roundValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchUps((int)roundValue.SelectedItem);
        }

        private void LoadMatchUps(int round)
        {
            foreach (List<MatchUpModel>matchups in tournament.Rounds)
            {
                if (matchups.First().MatchUpRound == round)
                {
                    selectedMatchups.Clear();
                    foreach (MatchUpModel m in matchups)
                    {
                        if(m.Winner!=null||!unplayedOnly.Checked){
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }
            if (selectedMatchups.Count>0)
            {
                LoadMatchups(selectedMatchups.First());
            }
            DisplayMatchUpInfo();
           
        }
        private void DisplayMatchUpInfo()
        {
            bool isVisiable =(selectedMatchups.Count>0);
            teamone.Visible = isVisiable;
            scoreLabel1.Visible = isVisiable;
            scoreTeamOneValue.Visible = isVisiable;
            teamtwo.Visible = isVisiable;
            scoreLabel2.Visible = isVisiable;
            scoreTeamTwoValue.Visible = isVisiable;
        }
        private void LoadMatchups(MatchUpModel m)
        {
            for (int i=0;i<m.Entries.Count;i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting !=null)
                    {
                        teamOneValue.Text = m.Entries[0].TeamCompeting.TeamName;
                        scoreTeamOneValue.Text = m.Entries[0].Score.ToString();
                        teamTwoValue.Text = "<bye>";
                        scoreTeamTwoValue.Text = "0";
                    }
                    else
                    {
                        teamOneValue.Text = "No Yet Set";
                        scoreTeamOneValue.Text = "";
                    }
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoValue.Text = m.Entries[1].TeamCompeting.TeamName;
                        scoreTeamTwoValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoValue.Text = "No Yet Set";
                        scoreTeamTwoValue.Text = "";
                    }
                }
            }
        }
        private void matchuplistBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups((MatchUpModel)matchuplistBox1.SelectedItem);
        }

        private void unplayedOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups((int)roundValue.SelectedItem);
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchUpModel m = (MatchUpModel)matchuplistBox1.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;
            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                       
                        bool scoreValid = double.TryParse(scoreTeamOneValue.Text,out teamOneScore);
                        
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid score for team 1");
                            return;
                        }
                    }
     
                }
                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        
                        bool scoreValid = double.TryParse(scoreTeamTwoValue.Text, out teamTwoScore);

                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid score for team 2");
                            return;
                        }
                        
                    }
                   
                }
            }
            TournamentLogic.UpdateTournamentResult(tournament);
            LoadMatchups((MatchUpModel)matchuplistBox1.SelectedItem);
            GlobalConfig.Connection.UpdateMatchup(m);
        }
        }
    }

