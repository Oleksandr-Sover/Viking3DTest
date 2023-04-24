using UnityEngine;

namespace GameLogic
{
    public class FlyingCameraMovement : CameraMovement, IFlyingCameraMovement
    {
        [SerializeField] float speed = 2;

        void LateUpdate() 
        {
            CameraFly();
        }

        public void CameraFly()
        {
            cinemachineTargetYaw += speed * Time.deltaTime;

            cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);

            transform.rotation = Quaternion.Euler(0.0f, cinemachineTargetYaw, 0.0f);
        }
    }
}