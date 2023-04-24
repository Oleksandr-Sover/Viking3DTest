using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 2)]
    public class PlayerData : ScriptableObject
    {
        [Header("Player State")]

        [SerializeField] int health = 20;
        public int Health { get => health; }


        [Header("Player Attack")]

        [SerializeField] int damage = 1;
        public int Damage { get => damage; }


        [SerializeField] int amountOfPointsPerKill = 1;
        public int AmountOfPointsPerKill { get => amountOfPointsPerKill; }


        [SerializeField] int amountOfHealthPerKill = 1;
        public int AmountOfHealthPerKill { get => amountOfHealthPerKill; }


        [SerializeField] int angleOfAttack = 120;
        public int AngleOfAttack { get => angleOfAttack; }


        [SerializeField] float attackDistance = 2;
        public float AttackDistance { get => attackDistance; }


        [Header("Player Movement")]

        [SerializeField] float moveSpeed = 2.0f;
        public float MoveSpeed { get =>  moveSpeed; }


        [SerializeField] float sprintSpeed = 4.0f;
        public float SprintSpeed { get => sprintSpeed; }


        [SerializeField] float speedChangeRate = 10.0f;
        public float SpeedChangeRate { get => speedChangeRate; }


        [SerializeField, Range(0.0f, 0.3f)] float rotationSmoothTime = 0.12f;
        public float RotationSmoothTime { get => rotationSmoothTime; }


        [Header("Player Camera")]

        [SerializeField] float topClampAngle = 70.0f;
        public float TopClampAngle { get => topClampAngle; }


        [SerializeField] float bottomClampAngle = -30.0f;
        public float BottomClampAngle { get => bottomClampAngle; }


        [Header("Input Settings")]

        [SerializeField] bool analogMovement;
        public bool AnalogMovement { get => analogMovement; }


        [SerializeField] bool cursorLocked = true;
        public bool CursorLocked { get => cursorLocked; set => cursorLocked = value; }


        [SerializeField] bool cursorInputForLook = true;
        public bool CursorInputForLook { get => cursorInputForLook; set => cursorInputForLook = value; }


        [Header("Player Ground Check")]

        [SerializeField] float checkSphereRadius = 0.5f;
        public float CheckSphereRadius { get => checkSphereRadius; }
    }
}