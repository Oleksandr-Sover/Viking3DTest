using UnityEngine;

namespace GameLogic
{
    public abstract class Movement : MonoBehaviour
    {
        protected IGravitation Gravitation;
        protected CharacterController controller;

        IGroundChecker GroundChecker;

        bool isGrounded;
        protected bool motionIsImpossible;

        protected virtual void Awake()
        {
            Gravitation = GetComponent<IGravitation>();
            controller = GetComponent<CharacterController>();
            GroundChecker = GetComponentInChildren<IGroundChecker>();
        }

        protected virtual bool UseOnlyGravity()
        {
            isGrounded = GroundChecker.IsGrounded();

            if (!isGrounded)
            {
                controller.Move(Gravitation.GetGravity());
                return true;
            }
            else
                return false;
        }
    }
}