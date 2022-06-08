namespace Personal.Admin.Model.Login.Result;

public class RegisterResult
{
    public bool Successful { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
