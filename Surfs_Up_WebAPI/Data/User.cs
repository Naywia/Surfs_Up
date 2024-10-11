using Microsoft.AspNetCore.Identity;

namespace Surfs_Up_WebAPI.Data;

public class User : IdentityUser
{
    public bool IsAdmin { get; } = false;
}