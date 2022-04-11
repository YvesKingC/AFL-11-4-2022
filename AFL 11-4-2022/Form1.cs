using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AFL_11_4_2022
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string sqlConnection = "server=localhost;uid=root;pwd=;database=premier_league";
        MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);           
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuerry;

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            DataTable dtTimA = new DataTable();
            sqlQuerry = "SELECT team_name, team_id FROM team";
            sqlCommand = new MySqlCommand(sqlQuerry, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTimA);
            cBoxTimA.DataSource = dtTimA;

            cBoxTimA.DisplayMember = "team_name";
            cBoxTimA.ValueMember = "team_id";

            DataTable dtTimB = new DataTable();
            sqlQuerry = "SELECT team_name, team_id FROM team";
            sqlCommand = new MySqlCommand(sqlQuerry, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTimB);
            cBoxTimB.DataSource = dtTimB;

            cBoxTimB.DisplayMember = "team_name";
            cBoxTimB.ValueMember = "team_id";

        }

        private void cBoxTimA_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlQuerry = "SELECT t.home_stadium, t.capacity , m.manager_name, p.player_name FROM team t, manager m, player p where t.manager_id = m.manager_id and p.player_id = t.captain_id";
            sqlCommand = new MySqlCommand(sqlQuerry, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);

            DataTable dtStadium = new DataTable();
            sqlAdapter.Fill(dtStadium);
            lblStadium.Text = dtStadium.Rows[cBoxTimA.SelectedIndex][0].ToString();

            DataTable dtCapacity = new DataTable();
            sqlAdapter.Fill(dtCapacity);
            lblStadiumCap.Text = dtCapacity.Rows[cBoxTimA.SelectedIndex][1].ToString();

            DataTable dtManager = new DataTable();
            sqlAdapter.Fill(dtManager);
            lblManagerTimA.Text = dtManager.Rows[cBoxTimA.SelectedIndex][2].ToString();

            DataTable dtCaptain = new DataTable();
            sqlAdapter.Fill(dtCaptain);
            lblCaptTimA.Text = dtCaptain.Rows[cBoxTimA.SelectedIndex][3].ToString();
        }

        private void cBoxTimB_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlQuerry = "SELECT m.manager_name, p.player_name FROM team t, manager m, player p where t.manager_id = m.manager_id and p.player_id = t.captain_id";
            sqlCommand = new MySqlCommand(sqlQuerry, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);

            DataTable dtManager = new DataTable();
            sqlAdapter.Fill(dtManager);
            lblManagerTimB.Text = dtManager.Rows[cBoxTimB.SelectedIndex][0].ToString();

            DataTable dtCaptain = new DataTable();
            sqlAdapter.Fill(dtCaptain);
            lblCaptTimB.Text = dtCaptain.Rows[cBoxTimB.SelectedIndex][1].ToString();
        }
    }
}
