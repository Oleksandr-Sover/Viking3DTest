
namespace GameLogic
{
    public class PlayerAttackCornerHandler : CharactersAttackCornerHandler, IPlayerAttackCornerHandler
    {
        ILocalPlayerData LocalPlayerData;

        protected override int AngleOfAttack { get; set; }

        void Awake()
        {
            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
        }

        protected override void Start()
        {
            AngleOfAttack = LocalPlayerData.PlayerData.AngleOfAttack;

            base.Start();
        }
    }
}