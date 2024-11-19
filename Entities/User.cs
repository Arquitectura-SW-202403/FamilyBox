namespace Entities;

public enum UserType {
    USER,
    ADMIN,
    MEMBER
}

public class User
{
    public string id {get; set;}
    public string password {get; set;}
    public string name {get; set;}
    public string phone {get; set;}
    public int phoneCode {get; set;}
    public UserType type {get; set;}
    public string email {get; set;}
    public bool verified {get; set;}
   public string? billingInfoId {get; set;}
}
