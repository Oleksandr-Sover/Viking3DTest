using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "MutantData", menuName = "Data/MutantData", order = 3)]
    public class MutantData : ScriptableObject
    {
        [Header("Mutant State")]

        [SerializeField] int health = 1;
        public int Health { get => health; set => health = value; }

        public bool ActiveState { get; set; }


        [Header("Mutant Attack")]

        [SerializeField] int damage = 1;
        public int Damage { get => damage; }


        [SerializeField] int angleOfAttack = 90;
        public int AngleOfAttack { get => angleOfAttack; }


        [SerializeField] float attackDistance = 2;
        public float AttackDistance { get => attackDistance; }


        [Header("Mutant Movement")]

        [SerializeField] float moveSpeed = 2.0f;
        public float MoveSpeed { get => moveSpeed; }


        [SerializeField] float sprintSpeed = 4.0f;
        public float SprintSpeed { get => sprintSpeed; }


        [SerializeField] float speedChangeRate = 10.0f;
        public float SpeedChangeRate { get => speedChangeRate; }


        [SerializeField, Range(0.0f, 0.3f)] float rotationSmoothTime = 0.12f;
        public float RotationSmoothTime { get => rotationSmoothTime; }


        [SerializeField] float maxSprintTime = 5;
        public float MaxSprintTime { get => maxSprintTime; }


        [SerializeField] float minSprintTime = 2;
        public float MinSprintTime { get => minSprintTime; }


        [SerializeField] float maxWalkTime = 10;
        public float MaxWalkTime { get => maxWalkTime; }


        [SerializeField] float minWalkTime = 3;
        public float MinWalkTime { get => minWalkTime; }


        [SerializeField, Range(0, 1)] float maxChanceOfSprinting = 0.4f;
        public float MaxChanceOfSprinting { get => maxChanceOfSprinting; }


        [Header("Mutant Died")]

        [SerializeField] float destructionTime = 6;
        public float DestructionTime { get => destructionTime; }


        [Header("Mutant Ground Check")]

        [SerializeField] float checkSphereRadius = 0.6f;
        public float CheckSphereRadius { get => checkSphereRadius; }
    }
}