
namespace UI
{
    public interface ILocalUIData
    {
        int Score { get; }
        int PlayerStartHealth { get; }
        int PlayerCurrentHealth { get; }
        float EndGameMenuTimer { get; }
        bool CursorLocked { get; set; }
        bool CursorInputForLook { get; set; }
    }
}