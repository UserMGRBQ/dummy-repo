using Dummy.Core.Abstract.Entity;
using Dummy.Core.Models;
using Dummy.Core.Utilities;

namespace Dummy.CQS.ViewModels;

public class UserViewModel : AbstractViewModel
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

    public override AbstractViewModel FormatToResponse()
    {
        Document = Document.FormatDocument();

        return this;
    }
}