using UnityEngine;

namespace GameLogic
{
    public class SpeedController : MonoBehaviour, ISpeedController
    {
        CharacterController controller;

        readonly float speedOffset = 0.1f;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        public float GetSpeed(Vector2 inputMove, float inputMagnitude, float sprintSpeed, float moveSpeed, float speedChangeRate, bool isSprint)
        {
            float currentHorizontalSpeed = new Vector3(controller.velocity.x, 0.0f, controller.velocity.z).magnitude;
            float targetSpeed = GetTargetSpeed(inputMove, sprintSpeed, moveSpeed, isSprint);

            if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                float speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * speedChangeRate);
                return Mathf.Round(speed * 1000f) / 1000f;
            }
            else
                return targetSpeed;
        }

        float GetTargetSpeed(Vector2 inputMove, float sprintSpeed, float moveSpeed, bool isSprint)
        {
            if (inputMove == Vector2.zero)
                return 0.0f;
            else if (isSprint)
                return sprintSpeed;
            else
                return moveSpeed;
        }
    }
}