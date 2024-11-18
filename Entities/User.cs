namespace Entities;

public enum UserType {
    USER,
    ADMIN,
    MEMBER
}

public class User
{
    String id {get; set;}
    String name {get; set;}
    String phone {get; set;}
    int phoneCode {get; set;}
    UserType type {get; set;}
    String email {get; set;}
    bool verified {get; set;}
    String billingInfoId {get; set;}
}
