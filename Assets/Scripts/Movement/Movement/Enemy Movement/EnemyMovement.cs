using UnityEngine;

namespace GameLogic
{
    public class EnemyMovement : Movement, IEnemyMovement, ICharacterRotator
    {
        Vector3 targetDirection;

        float rotationVelocity;

        public void Move(Vector3 distance, float speed, float rotationSmoothTime)
        {
            if (controller.enabled)
            {
                motionIsImpossible = UseOnlyGravity();

                Rotate(distance.x, distance.z, rotationSmoothTime);

                if (!motionIsImpossible)
                    controller.Move(targetDirection * (speed * Time.deltaTime) + Gravitation.GetGravity());
            }
        }

        public void Rotate(float inputX, float inputY, float rotationSmoothTime)
        {
            targetDirection = new Vector3(inputX, 0.0f, inputY).normalized;

            float targetRotation = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, rotationSmoothTime);

            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }
}