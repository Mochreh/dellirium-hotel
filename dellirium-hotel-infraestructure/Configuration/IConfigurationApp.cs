namespace dellirium_hotel_infraestructure.Configuration
{
    public interface IConfigurationApp
    {
        string GetConnectionString(string name);
    }
}
