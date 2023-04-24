
namespace UI
{
    public interface ILocalUIDataForSetter
    {
        Data.GlobalData GlobalData { get; set; }
        Data.PlayerData PlayerData { get; set; }
        GameLogic.ILocalPlayerData LocalPlayerData { get; set; }
        int PlayerStartHealth { get; set; }
        float EndGameMenuTimer { get; set; }
    }
}