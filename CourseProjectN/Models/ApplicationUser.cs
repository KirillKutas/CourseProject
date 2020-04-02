using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationUser : IdentityUser
{
    public string Nick { get; set; }
    public ApplicationUser()
    {
    }
}