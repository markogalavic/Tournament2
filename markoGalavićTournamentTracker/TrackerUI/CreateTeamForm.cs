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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        private ITeamRequester callingForm;
        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            callingForm = caller;
            //CreateSampleData();
            WireUpLists();
        }
        private void LoadListData()
        {
            availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        }
        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Ime1", LastName = "Prezime1" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Ime2", LastName = "Prezime2" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Ime3", LastName = "Prezime3" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Ime3", LastName = "Prezime4" });
        }
        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = memberFirstNametextBox.Text;
                p.LastName = memberLastNameTextBox.Text;
                p.EmailAddress = memberEmailTextBox.Text;
                p.CellphoneNumber = memberPhoneNumberTextBox.Text;

                 GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

                memberFirstNametextBox.Text = "";
                memberLastNameTextBox.Text = "";
                memberEmailTextBox.Text = "";
                memberPhoneNumberTextBox.Text = "";
            }
            else
            {
                MessageBox.Show("Trebaš ispuniti sva polja");
            }

        }

        private bool ValidateForm()
        {
            if (memberFirstNametextBox.Text.Length == 0)
            {
                return false;
            }
            if (memberLastNameTextBox.Text.Length == 0)
            {
                return false;
            }
            if (memberEmailTextBox.Text.Length == 0)
            {
                return false;
            }
            if (memberPhoneNumberTextBox.Text.Length == 0)
            {
                return false;
            }
            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedMembersButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();

            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(t);
            callingForm.TeamComplete(t);

            this.Close();
        }

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }
    }
}
