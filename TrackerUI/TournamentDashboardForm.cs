using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI;

public partial class TournamentDashboardForm : Form
{
    List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();
    public TournamentDashboardForm()
    {
        InitializeComponent();

        WireUpLists();
    }

    private void WireUpLists()
    {
        loadExistingTournamentDropDown.DataSource = tournaments;
        loadExistingTournamentDropDown.DisplayMember= "TournamentName";
    }

    private void createTorunamentButton_Click(object sender, EventArgs e)
    {
        CreateTournamentForm frm = new CreateTournamentForm();
        frm.Show();
    }

    private void loadTorunamentButton_Click(object sender, EventArgs e)
    {
        TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
        TournamentViewerForm frm = new TournamentViewerForm(tm);
        frm.Show();
    }
}
