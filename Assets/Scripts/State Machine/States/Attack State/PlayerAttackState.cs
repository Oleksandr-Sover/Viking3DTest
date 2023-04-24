using UnityEngine;

namespace GameLogic
{
    public class PlayerAttackState : CharacterAttackState
    {
        ILocalCharacterData LocalCharacterData;
        ILocalPlayerData LocalPlayerData;
        IPlayerAttackDistanceHandler PlayerAttackDistanceHandler;
        IPlayerAttackCornerHandler PlayerAttackCornerHandler;
        IInputController InputController;

        protected override float SpeedChangeRate { get; set; }
        protected override Vector2 RotateDirection { get => InputController.Move; }

        bool inAffectedArea;

        protected override void Awake()
        {
            base.Awake();

            LocalCharacterData = GetComponentInParent<ILocalCharacterData>();
            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
            PlayerAttackDistanceHandler = GetComponent<IPlayerAttackDistanceHandler>();
            PlayerAttackCornerHandler = GetComponent<IPlayerAttackCornerHandler>();
            InputController = GetComponentInParent<IInputController>();
        }

        void Start()
        {
            SpeedChangeRate = LocalPlayerData.PlayerData.SpeedChangeRate;
            rotationSmoothTime = LocalPlayerData.PlayerData.RotationSmoothTime;
        }

        public override void Execute()
        {
            base.Execute();

            if (attackAchieved && !damageIsDone && PlayerAttackDistanceHandler.EnemiesInAffectedArea != null)
            {
                foreach (var enemy in PlayerAttackDistanceHandler.EnemiesInAffectedArea)
                {
                    inAffectedArea = PlayerAttackCornerHandler.InAffectedArea(enemy.transform.position);

                    if (inAffectedArea)
                    {
                        SetDataForDefeat(enemy);
                    }
                }
                damageIsDone = true;
            }
        }

        void SetDataForDefeat(GameObject hitEnemy)
        {
            LocalPlayerData.EnemiesData[hitEnemy].Health -= LocalPlayerData.PlayerData.Damage;
            LocalCharacterData.GlobalData.Score += LocalPlayerData.PlayerData.AmountOfPointsPerKill;
            LocalPlayerData.Health += LocalPlayerData.PlayerData.AmountOfHealthPerKill;
        }
    }
}