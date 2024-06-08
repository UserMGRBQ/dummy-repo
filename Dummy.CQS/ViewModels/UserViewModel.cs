using Dummy.Core.Models;

namespace Dummy.CQS.ViewModels;

public class UserViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Document { get; set; }

    public UserViewModel(UserModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Email = model.Email;
        Document = model.Document;
    }
}