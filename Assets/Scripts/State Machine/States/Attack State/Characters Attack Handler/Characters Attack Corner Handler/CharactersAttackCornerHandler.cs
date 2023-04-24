using UnityEngine;

namespace GameLogic
{
    public abstract class CharactersAttackCornerHandler : MonoBehaviour
    {
        protected abstract int AngleOfAttack { get; set; }

        float minDot;

        protected virtual void Start()
        {
            minDot = GetMinDot(AngleOfAttack);
        }

        public bool InAffectedArea(Vector3 targetPosition)
        {
            targetPosition.y = transform.position.y;
            Vector3 targetDirection = (targetPosition - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, targetDirection);

            if (dot > minDot)
                return true;
            else
                return false;
        }

        float GetMinDot(float angleOfAttack)
        {
            float halfAngle = angleOfAttack / 2;
            Vector3 dotTarget = Quaternion.Euler(0, halfAngle, 0) * transform.forward;
            return Vector3.Dot(transform.forward, dotTarget);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;

            Gizmos.DrawRay(new Ray(transform.position, Quaternion.Euler(0, -AngleOfAttack / 2, 0) * transform.forward));
            Gizmos.DrawRay(new Ray(transform.position, Quaternion.Euler(0, AngleOfAttack / 2, 0) * transform.forward));
        }
    }
}