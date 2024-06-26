﻿namespace WebApp.Models;

public class ProfileInfoModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string ProfileImageUrl { get; set; } = null!;
    public bool IsExternalAccount { get; set; }
}

