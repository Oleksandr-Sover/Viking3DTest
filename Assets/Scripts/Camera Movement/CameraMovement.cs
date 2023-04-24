using UnityEngine;

namespace GameLogic
{
    public abstract class CameraMovement : MonoBehaviour
    {
        protected float cinemachineTargetYaw;

        protected virtual void Awake()
        {
            cinemachineTargetYaw = transform.rotation.eulerAngles.y;
        }

        protected static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}