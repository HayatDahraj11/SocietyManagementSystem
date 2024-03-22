using MySql.Data.MySqlClient;
using SocietyManagementSystem;

public class SessionManager
{
    private static SessionManager _instance;
    public int UserId { get; private set; }
    public string FullName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public string UserType { get; private set; }

    // Private constructor ensures that an object is not instantiated outside the class (Singleton pattern)
    private SessionManager() { }

    // The public method to get the instance of the class
    public static SessionManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SessionManager();
        }
        return _instance;
    }

    // Start the user session
    public void StartUserSession(int userId)
    {
        UserId = userId;

        // Get Details of user
        string connectionString = GlobalConfig.ConnectionString;
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT full_name, username, user_type, email FROM users WHERE user_id=@id;";
            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        FullName = reader.GetString(0);
                        Username = reader.GetString(1);
                        UserType = reader.GetString(2);
                        Email = reader.GetString(3);
                    }
                }
            }
        }
    }

    // End the user session
    public void EndUserSession()
    {
        UserId = 0;
        FullName = null;
        Username = null;
        Email = null;
        UserType = null;
    }

    // Reload Session in case of updates in user details
    public void ReloadSession()
    {
        if (UserId != 0)
        {
            StartUserSession(UserId);
        }
    }

    // Check if the user is logged in
    public bool IsUserLoggedIn()
    {
        return UserId != 0;
    }
    // Get the user type
    public string GetUserType()
    {
        return UserType;
    }
    // Get the user id
    public int GetUserId()
    {
        return UserId;
    }
    // Get the user full name
    public string GetUserFullName()
    {
        return FullName;
    }
    // Get the user email
    public string GetUserEmail()
    {
        return Email;
    }
    // Get the username
    public string GetUsername()
    {
        return Username;
    }




}
