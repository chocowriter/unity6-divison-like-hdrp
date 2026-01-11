using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DivisionLike
{
    public class PlayerNewInput : MonoBehaviour
    {
        [System.Serializable]
        public class OtherSettings
        {
            public float m_LookSpeed = 5.0f;
            public float m_LookDistance = 30.0f;
            public bool m_RequireInputForTurn = true;
            public LayerMask m_AimDetectionLayers;
        }
        
        [SerializeField] public OtherSettings m_OtherSettings;

        private Camera m_TPSCamera;
        private Dictionary<Weapon, GameObject> m_CrosshairPrefabMap = new Dictionary<Weapon, GameObject>();
        
        [Space(10)]
        [Header("Transforms")]
        public Transform m_SpineTransform;
        
        [Header("Player States")]
        public bool m_IsAiming = false;
        public bool m_IsFiring = false;
        public bool m_IsSprinting = false;
        public bool m_IsGrenadeMode = false;

        [Header("Debug")]
        public bool m_EnableInput = true;
        public bool m_DebugAim = false;
        
        
        void OnLeftClick()
        {
            Debug.Log("Left click");
        }
        
        void OnRightClick()
        {
            Debug.Log("Right click");
        }
    }
}