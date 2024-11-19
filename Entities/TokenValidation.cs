namespace Entities;

public class TokenValidation 
{
    public string? token {get; set;}
    public string? id {get; set;}
}

public class Username
{
    public string user {get; set;}
    public string password {get; set;}
}

public class EncryptQuery
{
    public string? encode {get; set;}
    public string? decode {get; set;}
}