using UnityEngine;

namespace GameLogic
{
    public class PlayerMoveState : CharacterMoveState
    {
        ILocalPlayerData LocalPlayerData;
        IInputController InputController;
        IPlayerMovement PlayerMovement;

        protected override Vector2 MoveDirection { get => InputController.Move; }
        protected override float SprintSpeed { get; set; }
        protected override float MoveSpeed { get; set; }
        protected override float SpeedChangeRate { get; set; }
        protected override float InputMagnitude { get; set; }
        protected override bool Sprint { get => InputController.Sprint; }

        protected override void Awake()
        {
            base.Awake();

            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
            InputController = GetComponentInParent<IInputController>();
            PlayerMovement = GetComponentInParent<IPlayerMovement>();
        }

        void Start()
        {
            SprintSpeed = LocalPlayerData.PlayerData.SprintSpeed;
            MoveSpeed = LocalPlayerData.PlayerData.MoveSpeed;
            SpeedChangeRate = LocalPlayerData.PlayerData.SpeedChangeRate;
            InputMagnitude = InputController.InputMagnitude;

            rotationSmoothTime = LocalPlayerData.PlayerData.RotationSmoothTime;
        }

        public override void Execute()
        {
            base.Execute();

            PlayerMovement.Move(MoveDirection, speed, rotationSmoothTime);
        }

        public override void Exit()
        {
            PlayerMovement.Move(Vector3.zero, 0, rotationSmoothTime);

            base.Exit();
        }
    }
}