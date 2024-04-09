using MySql.Data.MySqlClient;


namespace SocietyManagementSystem
{

    public partial class ChangeMemberRoleForm : Form
    {
        private int societyId;
        private int userId;

        public ChangeMemberRoleForm(int societyId, int userId)
        {
            InitializeComponent();
            this.societyId = societyId;
            this.userId = userId;
            LoadRoles();
        }

        private Dictionary<int, string> roles;

        private void LoadRoles()
        {
            roles = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var query = "SELECT role_id, role_name FROM society_roles";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int roleId = reader.GetInt32(0);
                            string roleName = reader.GetString(1);
                            roles.Add(roleId, roleName);
                        }
                    }
                }
            }

            cmbRoles.DataSource = new BindingSource(roles, null);
            cmbRoles.DisplayMember = "Value";
            cmbRoles.ValueMember = "Key";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedItem == null)
            {
                MessageBox.Show("Please select a role");
                return;
            }
            if (MessageBox.Show("Are you sure you want to update the role?", "Update Role", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            if (this.userId == SessionManager.GetInstance().GetUserId())
            {
                MessageBox.Show("You cannot change your own role");
                return;
            }
            // Get the selected role
            KeyValuePair<int, string> selectedRole = (KeyValuePair<int, string>)cmbRoles.SelectedItem;
            int roleID = selectedRole.Key;

            using (MySqlConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
            {
                connection.Open();
                var query = "UPDATE society_members SET role_id = @roleID WHERE society_id = @societyId AND user_id = @userId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@roleID", roleID);
                    cmd.Parameters.AddWithValue("@societyId", this.societyId);
                    cmd.Parameters.AddWithValue("@userId", this.userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Role updated successfully");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
