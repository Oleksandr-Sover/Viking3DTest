
namespace GameLogic
{
    public class ThirdPersonController : CharactersController
    {
        ILocalPlayerData LocalPlayerData;

        IInputController InputController;
        ICameraRootMovement CameraRootMovement;

        PlayerMoveState playerMoveState;
        PlayerAttackState playerAttackState;
        CharacterDamageState playerDamageState;
        CharacterDieState playerDieState;

        protected override IState MoveState { get => playerMoveState; }
        protected override IState AttackState { get => playerAttackState; }
        protected override IState DamageState { get => playerDamageState; }
        protected override IState DieState { get => playerDieState; }

        protected override int Health { get => LocalPlayerData.Health; }
        protected override bool Attack { get => InputController.Attack; }


        protected override void Awake()
        {
            base.Awake();

            LocalPlayerData = GetComponent<ILocalPlayerData>();
            InputController = GetComponent<IInputController>();
            CameraRootMovement = GetComponentInChildren<ICameraRootMovement>();

            playerMoveState = GetComponentInChildren<PlayerMoveState>();
            playerAttackState = GetComponentInChildren<PlayerAttackState>();
            playerDamageState = GetComponentInChildren<CharacterDamageState>();
            playerDieState = GetComponentInChildren<CharacterDieState>();
        }

        void LateUpdate()
        {
            CameraRootMovement.RotateCamera(InputController);
        }
    }
}