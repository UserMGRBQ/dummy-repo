namespace Dummy.Core.Models;

public class UserModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Document { get; private set; }

    public UserModel(string name, string email, string document)
    {
        Name = name;
        Email = email;
        Document = document;
    }
}