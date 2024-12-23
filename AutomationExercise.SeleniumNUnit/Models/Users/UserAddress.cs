namespace AutomationExercise.SeleniumNUnit.Models.Users;

public class UserAddress(
    string firstName,
    string lastName,
    string fullAddress,
    string country,
    string state,
    string city,
    string zipcode,
    string phone
)
{
    public string firstName { get; set; } = firstName;
    public string lastName { get; set; } = lastName;
    public string fullAddress { get; set; } = fullAddress;
    public string country { get; set; } = country;
    public string state { get; set; } = state;
    public string city { get; set; } = city;
    public string zipcode { get; set; } = zipcode;
    public string phone { get; set; } = phone;
}