using UnityEngine;

namespace GameLogic
{
    public class PlayerMovement : Movement, IPlayerMovement, ICharacterRotator
    {
        Transform cameraTransform;

        float rotationVelocity;
        float targetRotation;

        protected override void Awake()
        {
            base.Awake();

            if (cameraTransform == null)
                cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        public void Move(Vector2 inputMove, float speed, float rotationSmoothTime)
        {
            motionIsImpossible = UseOnlyGravity();

            if (!motionIsImpossible)
            {
                Vector3 targetDirection;

                if (inputMove != Vector2.zero)
                {
                    Rotate(inputMove.x, inputMove.y, rotationSmoothTime);

                    targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
                }
                else
                    targetDirection = Vector3.forward;

                controller.Move(targetDirection.normalized * (speed * Time.deltaTime) + Gravitation.GetGravity());
            }
        }

        public void Rotate(float inputX, float inputY, float rotationSmoothTime)
        {
            Vector3 inputDirection = new Vector3(inputX, 0.0f, inputY).normalized;

            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, rotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }
}