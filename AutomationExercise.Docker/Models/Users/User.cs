namespace AutomationExercise.Docker.Models.Users;

public class User(
    string name,
    string email,
    bool isMale,
    string password,
    string birthDay,
    string birthMonth,
    string birthYear,
    bool isSubscribedNewsletter,
    bool isSubscribedSpecialOffers,
    UserAddress address
    )
{
    public string name { get; set; } = name;
    public string email { get; set; } = email;
    public bool isMale { get; set; } = isMale;
    public string password { get; set; } = password;
    public string birthDay { get; set; } = birthDay;
    public string birthMonth { get; set; } = birthMonth;
    public string birthYear { get; set; } = birthYear;
    public bool isSubscribedNewsletter { get; set; } = isSubscribedNewsletter;
    public bool isSubscribedSpecialOffers { get; set; } = isSubscribedSpecialOffers;
    public UserAddress address { get; set; } = address;
}