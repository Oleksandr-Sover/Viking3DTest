using UnityEngine;

namespace GameLogic
{
    public class Gravitation : MonoBehaviour, IGravitation
    {
        ILocalCharacterData LocalCharacterData;

        Vector3 gravitation = Vector3.zero;

        float gravity;

        void Awake()
        {
            LocalCharacterData = GetComponent<ILocalCharacterData>();
        }

        void Start()
        {
            gravity = LocalCharacterData.GlobalData.Gravity;
        }

        public Vector3 GetGravity()
        {
            gravitation.y = gravity * Time.deltaTime;
            return gravitation;
        }
    }
}