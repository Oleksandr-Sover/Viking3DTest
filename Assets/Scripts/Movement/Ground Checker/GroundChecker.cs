using UnityEngine;

namespace GameLogic
{
    public abstract class GroundChecker : MonoBehaviour, IGroundChecker
    {
        ILocalCharacterData LocalCharacterData;

        LayerMask groundLayer;

        protected abstract float CheckSphereRadius { get; set; }

        protected virtual void Awake()
        {
            LocalCharacterData = GetComponentInParent<ILocalCharacterData>();
        }

        protected virtual void Start()
        {
            groundLayer = LocalCharacterData.GlobalData.TerrainLayer;
        }

        public bool IsGrounded()
        {
            if (Physics.CheckSphere(transform.position, CheckSphereRadius, groundLayer, QueryTriggerInteraction.Ignore))
                return true;
            else
                return false;
        }

        void OnDrawGizmos()
        {
            if (LocalCharacterData != null)
            {
                if (Physics.CheckSphere(transform.position, CheckSphereRadius, groundLayer, QueryTriggerInteraction.Ignore))
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(transform.position, CheckSphereRadius);
                }
                else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(transform.position, CheckSphereRadius);
                }
            }
        }
    }
}