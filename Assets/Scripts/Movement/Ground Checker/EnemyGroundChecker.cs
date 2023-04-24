
namespace GameLogic
{
    public class EnemyGroundChecker : GroundChecker
    {
        ILocalEnemyData LocalEnemyData;

        protected override float CheckSphereRadius { get; set; }

        protected override void Awake()
        {
            base.Awake();

            LocalEnemyData = GetComponentInParent<ILocalEnemyData>();
        }

        protected override void Start()
        {
            base.Start();

            CheckSphereRadius = LocalEnemyData.MutantData.CheckSphereRadius;
        }
    }
}