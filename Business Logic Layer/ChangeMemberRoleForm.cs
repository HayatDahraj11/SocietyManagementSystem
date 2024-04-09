using SocietyManagementSystem.Data_Access_Layer;


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
            GetData data = new GetData();
            roles = data.GetRoles();

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

            GetData getData = new GetData();
            getData.UpdateRole(societyId, userId, roleID);

            MessageBox.Show("Role updated successfully");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChangeMemberRoleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
