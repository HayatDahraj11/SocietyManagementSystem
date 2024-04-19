using MySql.Data.MySqlClient;

namespace SocietyManagementSystem.Data_Access_Layer
{
    internal class GetData
    {
        private string connectionString = GlobalConfig.ConnectionString;

        public Dictionary<int, string> GetRoles()
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            return roles;
        }


        public void UpdateRole(int societyId, int userId, int roleId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE society_members SET role_id = @roleId WHERE society_id = @society"
                    + " AND user_id = @userId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    cmd.Parameters.AddWithValue("@society", societyId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string GetPassword(int userId)
        {
            string password = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT `password` FROM users WHERE user_id = @UserId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    password = cmd.ExecuteScalar()?.ToString();
                }
            }

            return password;
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE users SET `password` = @NewPassword WHERE user_id = @UserId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public Dictionary<int, string> GetUserSocieties(int userId)
        {
            Dictionary<int, string> userSocieties = new Dictionary<int, string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT society_id, name FROM societies WHERE founder_id = @UserId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int societyId = reader.GetInt32(0);
                            string societyName = reader.GetString(1);
                            userSocieties.Add(societyId, societyName);
                        }
                    }
                }
            }

            return userSocieties;
        }
        public List<Society> GetApprovedSocieties()
        {
            List<Society> approvedSocieties = new List<Society>();

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT society_id, name, description, status FROM societies";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string societyId = reader["society_id"].ToString();
                                string name = reader["name"].ToString();
                                string description = reader["description"].ToString();
                                string status = reader["status"].ToString();

                                if (status == "approved")
                                {
                                    Society society = new Society
                                    {
                                        SocietyId = Convert.ToInt32(societyId),
                                        Name = name,
                                        Description = description
                                    };
                                    approvedSocieties.Add(society);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return approvedSocieties;
        }

        public List<Society> GetAvailableSocieties(int userId)
        {
            List<Society> availableSocieties = new List<Society>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT society_id, name FROM societies WHERE society_id NOT IN (SELECT society_id FROM society_members WHERE user_id = @userId)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int societyId = reader.GetInt32(0);
                            string societyName = reader.GetString(1);
                            availableSocieties.Add(new Society { SocietyId = societyId, Name = societyName });
                        }
                    }
                }
            }

            return availableSocieties;
        }

        public bool JoinSociety(int userId, int societyId)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO society_members (user_id, society_id, role_id, join_date) VALUES (@user_id, @society_id, 2, CURDATE());";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@society_id", societyId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
            }

            return success;
        }

        public int LoginUser(string username, string password)
        {
            int userId = -1;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT user_id FROM users WHERE username=@username AND password=@password;";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // Use hashed passwords in a real app
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }

            return userId;
        }

        public int GetPendingSocietiesCount()
        {
            int count = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT COUNT(*) FROM societies WHERE status = 'Pending'", connection);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return count;
        }

        public void LoadPendingSocietiesIntoGrid(DataGridView dataGridView)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT name, description, status FROM societies WHERE status = 'Pending'", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowIndex = dataGridView.Rows.Add();
                        DataGridViewRow row = dataGridView.Rows[rowIndex];

                        row.Cells["SocietyName"].Value = reader["name"].ToString();
                        row.Cells["SocietyDescription"].Value = reader["description"].ToString();
                        row.Cells["Status"].Value = reader["status"].ToString();

                        row.Cells["AcceptButton"].Value = "Accept";
                        row.Cells["RejectButton"].Value = "Reject";
                    }
                }
            }
        }

        public void HandleSocietyAction(object sender, DataGridViewCellEventArgs e, DataGridView dataGridView)
        {
            if (e.ColumnIndex == dataGridView.Columns["AcceptButton"].Index)
            {
                string societyName = dataGridView.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();
                UpdateSocietyStatus(societyName, "Approved");
                RefreshDataGridView(dataGridView);
            }
            else if (e.ColumnIndex == dataGridView.Columns["RejectButton"].Index)
            {
                string societyName = dataGridView.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();
                UpdateSocietyStatus(societyName, "Rejected");
                RefreshDataGridView(dataGridView);
            }
        }

        private void UpdateSocietyStatus(string societyName, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"UPDATE societies SET status = @status, mentor_id = @mentor_id WHERE name = @name", connection);
                cmd.Parameters.AddWithValue("@name", societyName);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@mentor_id", SessionManager.GetInstance().GetUserId());
                cmd.ExecuteNonQuery();
            }
        }

        private void RefreshDataGridView(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            LoadPendingSocietiesIntoGrid(dataGridView);
        }

        public void UpdateUserProfile(int userId, string username, string email, string fullName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("UPDATE users SET username = @Username, email = @Email, full_name = @FullName WHERE user_id = @UserId", connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
            }
        }

        public UserProfileDetails GetUserProfileDetails(int userId)
        {
            UserProfileDetails userDetails = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT username, email, full_name, user_type FROM users WHERE user_id = @UserId", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userDetails = new UserProfileDetails
                        {
                            Username = reader["username"].ToString(),
                            Email = reader["email"].ToString(),
                            FullName = reader["full_name"].ToString(),
                            UserType = reader["user_type"].ToString()
                        };
                    }
                }
            }

            return userDetails;
        }

        public List<UserSociety> GetUser_Societies(int userId)
        {
            List<UserSociety> societiesList = new List<UserSociety>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT societies.name AS SocietyName, sr.role_name AS RoleName 
                     FROM societies 
                     JOIN society_members sm ON societies.society_id = sm.society_id 
                     JOIN society_roles sr ON sm.role_id = sr.role_id 
                     WHERE sm.user_id = @UserId", connection);

                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        societiesList.Add(new UserSociety
                        {
                            SocietyName = reader["SocietyName"].ToString(),
                            RoleName = reader["RoleName"].ToString()
                        });
                    }
                }
            }

            return societiesList;
        }

        public List<UserEvent> GetUserEvents(int userId)
        {
            List<UserEvent> eventsList = new List<UserEvent>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT events.name AS EventName, societies.name AS SocietyName 
                                     FROM events 
                                     JOIN event_registrations ON events.event_id = event_registrations.event_id 
                                     JOIN societies ON events.society_id = societies.society_id 
                                     WHERE event_registrations.user_id = @UserId", connection);

                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventsList.Add(new UserEvent
                        {
                            EventName = reader["EventName"].ToString(),
                            SocietyName = reader["SocietyName"].ToString()
                        });
                    }
                }
            }

            return eventsList;
        }

        public bool RegisterSociety(string name, string description, int founderId, DateTime creationDate)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO societies (name, description, creation_date, founder_id) VALUES (@name, @description, @creation_date, @founder_id)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@creation_date", creationDate);
                    command.Parameters.AddWithValue("@founder_id", founderId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }

                connection.Close();
            }

            return success;
        }

        public bool RegisterUser(string fullName, string username, string email, string password, string userType, DateTime joinDate)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO users (full_name, username, email, password, user_type, join_date) VALUES (@fullName, @username, @email, @password, @userType, @joinDate)";
                    command.Parameters.AddWithValue("@fullName", fullName);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@userType", userType);
                    command.Parameters.AddWithValue("@joinDate", joinDate);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }

                connection.Close();
            }

            return success;
        }

        public SocietyDetailsData GetSocietyDetails(int societyId)
        {
            SocietyDetailsData detailsData = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand("SELECT s.*, u.full_name AS founder, m.full_name AS mentor FROM societies s LEFT JOIN users u ON s.founder_id = u.user_id LEFT JOIN users m ON s.mentor_id = m.user_id WHERE s.society_id = @societyId", connection);
                cmd.Parameters.AddWithValue("@societyId", societyId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        detailsData = new SocietyDetailsData
                        {
                            SocietyId = Convert.ToInt32(reader["society_id"]),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString(),
                            Status = reader["status"].ToString(),
                            CreationDate = reader.GetDateTime("creation_date"),
                            Founder = reader["founder"].ToString(),
                            Mentor = reader["mentor"].ToString(),
                            Members = new List<SocietyMemberData>()
                        };
                    }
                }

                if (detailsData != null)
                {
                    cmd = new MySqlCommand("SELECT u.full_name, sr.role_name AS role FROM society_members sm JOIN users u ON sm.user_id = u.user_id JOIN society_roles sr ON sm.role_id = sr.role_id WHERE sm.society_id = @societyId;", connection);
                    cmd.Parameters.AddWithValue("@societyId", societyId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SocietyMemberData member = new SocietyMemberData
                            {
                                FullName = reader["full_name"].ToString(),
                                Role = reader["role"].ToString()
                            };

                            detailsData.Members.Add(member);
                        }
                    }
                }

                connection.Close();
            }

            return detailsData;
        }

        public SocietyMembersData GetSocietyMembers(int societyId)
        {
            SocietyMembersData membersData = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(@"SELECT users.user_id, users.full_name AS name, society_roles.role_name AS role 
                    FROM society_members 
                    INNER JOIN users ON society_members.user_id = users.user_id 
                    INNER JOIN society_roles ON society_members.role_id = society_roles.role_id 
                    WHERE society_members.society_id = @societyId;", connection);
                cmd.Parameters.AddWithValue("@societyId", societyId);

                using (var reader = cmd.ExecuteReader())
                {
                    membersData = new SocietyMembersData
                    {
                        Members = new List<SocietyMemberData>()
                    };

                    while (reader.Read())
                    {
                        SocietyMemberData member = new SocietyMemberData
                        {
                            UserId = Convert.ToInt32(reader["user_id"]),
                            FullName = reader["name"].ToString(),
                            Role = reader["role"].ToString()
                        };

                        membersData.Members.Add(member);
                    }
                }

                connection.Close();
            }

            return membersData;
        }

        public void RemoveMemberFromSociety(int societyId, int memberId)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM society_members WHERE society_id = @societyId AND user_id = @userId;";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    cmd.Parameters.AddWithValue("@userId", memberId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsersSocietiesData GetAllUserSocieties(int userId)
        {
            UsersSocietiesData socitiesData = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(@"SELECT s.society_id AS SocietyID, s.name AS SocietyName, sr.role_name AS RoleName 
                                     FROM societies s 
                                     JOIN society_members sm ON s.society_id = sm.society_id 
                                     JOIN society_roles sr ON sm.role_id = sr.role_id 
                                     WHERE sm.user_id = @UserId;", connection);
                cmd.Parameters.AddWithValue("@UserId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    socitiesData = new UsersSocietiesData
                    {
                        Societies = new List<SocitiesList>()
                    };

                    while (reader.Read())
                    {
                        SocitiesList member = new SocitiesList
                        {
                            SocietyID = Convert.ToInt32(reader["SocietyID"]),
                            SocietyName = reader["SocietyName"].ToString(),
                            RoleName = reader["RoleName"].ToString()
                        };

                        socitiesData.Societies.Add(member);
                    }
                }

                connection.Close();
            }

            return socitiesData;
        }




        public List<EventData> GetEventsForSociety(int societyId)
        {
            List<EventData> events = new List<EventData>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM events WHERE society_id = @societyId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@societyId", societyId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EventData eventData = new EventData
                            {
                                EventId = Convert.ToInt32(reader["event_id"]),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                EventDate = Convert.ToDateTime(reader["event_date"]),
                                SocietyId = Convert.ToInt32(reader["society_id"])
                            };
                            events.Add(eventData);
                        }
                    }
                }
            }

            return events;
        }
        public bool AddEvent(string name, string description, DateTime eventDate, int societyId, string location)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO events (society_id, name, description, event_date, location) VALUES (@societyId, @name, @description, @eventDate, @location)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@eventDate", eventDate);
                    command.Parameters.AddWithValue("@societyId", societyId);
                    command.Parameters.AddWithValue("@location", location);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }

                connection.Close();
            }

            return success;
        }

        public bool DeleteEvent(int eventId)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM events WHERE event_id = @eventId";
                    command.Parameters.AddWithValue("@eventId", eventId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        success = true;
                    }
                }

                connection.Close();
            }

            return success;
        }

        internal bool RequestBudget(int societyId, int userId, string description, int eventId)
        {
            bool success = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO resource_requests (society_id, user_id, description, event_id) VALUES (@societyId, @userId, @"
                        + "description, @eventId)";
                    command.Parameters.AddWithValue("@societyId", societyId);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@description", description);
                    command.Parameters.AddWithValue("@eventId", eventId);
                    command.ExecuteNonQuery();
                    success = true;
                }
                connection.Close();
            }
            return success;
        }

        public List<BudgetRequestData> GetBudgetRequestsForSociety(int societyId)
        {
            List<BudgetRequestData> budgetRequests = new List<BudgetRequestData>();
            string query = "SELECT r.request_id, e.name AS event_name, r.status, r.description " +
                           "FROM resource_requests r " +
                           "INNER JOIN events e ON r.event_id = e.event_id " +
                           "WHERE r.society_id = @societyId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@societyId", societyId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BudgetRequestData budgetRequest = new BudgetRequestData
                            {
                                RequestId = Convert.ToInt32(reader["request_id"]),
                                EventName = reader["event_name"].ToString(),
                                Status = reader["status"].ToString(),
                                Description = reader["description"].ToString()
                            };
                            budgetRequests.Add(budgetRequest);
                        }
                    }
                }
            }
            return budgetRequests;
        }

        public int GetPendingResourceRequestsCount()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM resource_requests WHERE status = 'pending'";
                MySqlCommand command = new MySqlCommand(query, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }

        public void LoadPendingResourceRequestsIntoGrid(DataGridView dataGridView)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"SELECT e.name AS EventName, s.name AS SocietyName, r.description AS ResourceName, r.status AS Status " +
                               "FROM events e " +
                               "JOIN resource_requests r ON e.event_id = r.event_id " +
                               "JOIN societies s ON r.society_id = s.society_id " +
                               "WHERE r.status = 'pending'", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowIndex = dataGridView.Rows.Add();
                        DataGridViewRow row = dataGridView.Rows[rowIndex];

                        row.Cells["EventName"].Value = reader["EventName"].ToString();
                        row.Cells["SocietyName"].Value = reader["SocietyName"].ToString();
                        row.Cells["ResourceName"].Value = reader["ResourceName"].ToString();
                        row.Cells["Status"].Value = reader["Status"].ToString();

                        row.Cells["ApproveButton"].Value = "Approve";
                        row.Cells["RejectButton"].Value = "Reject";
                    }
                }
            }
        }

        public void HandleResourceRequestAction(object sender, DataGridViewCellEventArgs e, DataGridView dataGridView)
        {
            if (e.ColumnIndex == dataGridView.Columns["ApproveButton"].Index)
            {
                string eventName = dataGridView.Rows[e.RowIndex].Cells["EventName"].Value.ToString();
                string societyName = dataGridView.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();
                string resourceName = dataGridView.Rows[e.RowIndex].Cells["ResourceName"].Value.ToString();
                UpdateResourceRequestStatus(eventName, societyName, resourceName, "Approved");
                RefreshDataGridViewEvents(dataGridView);
            }
            else if (e.ColumnIndex == dataGridView.Columns["RejectButton"].Index)
            {
                string eventName = dataGridView.Rows[e.RowIndex].Cells["EventName"].Value.ToString();
                string societyName = dataGridView.Rows[e.RowIndex].Cells["SocietyName"].Value.ToString();
                string resourceName = dataGridView.Rows[e.RowIndex].Cells["ResourceName"].Value.ToString();
                UpdateResourceRequestStatus(eventName, societyName, resourceName, "Rejected");
                RefreshDataGridViewEvents(dataGridView);
            }
        }

        private void UpdateResourceRequestStatus(string eventName, string societyName, string resourceName, string status)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(@"UPDATE resource_requests r " +
                                           "JOIN events e ON r.event_id = e.event_id " +
                                           "JOIN societies s ON r.society_id = s.society_id " +
                                           "SET r.status = @status " +
                                           "WHERE e.name = @eventName AND s.name = @societyName AND r.description = @resourceName", connection);
                cmd.Parameters.AddWithValue("@eventName", eventName);
                cmd.Parameters.AddWithValue("@societyName", societyName);
                cmd.Parameters.AddWithValue("@resourceName", resourceName);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }
        }

        private void RefreshDataGridViewEvents(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            LoadPendingResourceRequestsIntoGrid(dataGridView);
        }

    }

    public class BudgetRequestData
    {
        public int RequestId { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }


    public class SocitiesList
    {
        public int SocietyID { get; set; }
        public string SocietyName { get; set; }
        public string RoleName { get; set; }
    }

    public class UsersSocietiesData
    {
        public List<SocitiesList> Societies { get; internal set; }
    }

    public class SocietyMembersData
    {
        public List<SocietyMemberData> Members { get; internal set; }
    }

    public class SocietyMemberData
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public int UserId { get; internal set; }
    }

    public class SocietyDetailsData
    {
        public int SocietyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Founder { get; set; }
        public string Mentor { get; set; }

        public List<SocietyMemberData> Members { get; set; }

    }

    public class UserEvent
    {
        public string EventName { get; set; }
        public string SocietyName { get; set; }
    }

    public class UserSociety
    {
        public string SocietyName { get; set; }
        public string RoleName { get; set; }
    }

    public class UserProfileDetails
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserType { get; set; }
    }

    public class Society
    {
        public int SocietyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class EventData
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public int SocietyId { get; set; }
    }
}
