public class User
{
    public string Name { get; set; }

    public string Password { get; set; }
}

public class UserService
{

    private List<User> users;

    public UserService()
    {
        users = new List<User> {
            new User {
                Name = "eb@gmail",
                Password = "123456"
            }
        };
    }
    public bool Login(User user)
    {
        var existingUser = users.SingleOrDefault(u => u.Name == user.Name);
        if (existingUser == null)
        {
            return false;
        }

        if (existingUser.Password != user.Password)
        {
            return false;
        }

        return true;
    }
}