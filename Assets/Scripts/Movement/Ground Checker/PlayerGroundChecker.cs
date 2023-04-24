
namespace GameLogic
{
    public class PlayerGroundChecker : GroundChecker
    {
        ILocalPlayerData LocalPlayerData;

        protected override float CheckSphereRadius { get ; set; }

        protected override void Awake()
        {
            base.Awake();

            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
        }

        protected override void Start()
        {
            base.Start();

            CheckSphereRadius = LocalPlayerData.PlayerData.CheckSphereRadius;
        }
    }
}