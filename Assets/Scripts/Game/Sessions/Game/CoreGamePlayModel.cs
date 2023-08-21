using UnityEngine;

namespace Game.SessionScenarios
{
    public class CoreGamePlayModel: MonoBehaviour
    {
        [Header("Player spawn Transform")]
        public Transform PlayerSpawnTransform;

        [Header("Default player speed")] 
        public float DefaultPlayerSpeed = 5;
    }
}