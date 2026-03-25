public static class RegistrationData
{
    public static object GetDefaultUser()
    {
        return new
        {
            FirstName = "Sheldon ",
            LastName = "Cooper",
            Address = "Street 123",
            State = "California",
            City = "Los Angeles",
            Zip = "90210",
            Mobile = "5550123"
        };
    }
}