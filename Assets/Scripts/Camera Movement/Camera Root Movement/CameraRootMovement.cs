using UnityEngine;

namespace GameLogic
{
    public class CameraRootMovement : CameraMovement, ICameraRootMovement
    {
        ILocalPlayerData LocalPlayerData;

        const float threshold = 0.01f;

        float topClampAngle;
        float bottomClampAngle;
        float cinemachineTargetPitch;

        protected override void Awake()
        {
            LocalPlayerData = GetComponentInParent<ILocalPlayerData>();
        }

        void Start()
        {
            topClampAngle = LocalPlayerData.PlayerData.TopClampAngle;
            bottomClampAngle = LocalPlayerData.PlayerData.BottomClampAngle;

        }

        public void RotateCamera(IInputController input)
        {
            if (input.Look.sqrMagnitude >= threshold)
            {
                cinemachineTargetYaw += input.Look.x * input.DeltaTimeMultiplier;
                cinemachineTargetPitch += input.Look.y * input.DeltaTimeMultiplier;
            }

            cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
            cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClampAngle, topClampAngle);

            transform.rotation = Quaternion.Euler(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
        }
    }
}