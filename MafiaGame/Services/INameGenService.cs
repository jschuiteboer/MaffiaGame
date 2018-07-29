namespace MafiaGame.Services
{
    public interface INameGenService
    {
        string GetNextNameForAStore();
        string GetNextNameForABank();
        string GetNextNameForAPoliceStation();
        string GetNextNameForAnAirport();
    }
}