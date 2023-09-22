using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Data/PlayerSettings", fileName = "PlayerConfig", order = 51)]

    public class PlayerConfigs : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private int _lifes;
        
        public float MoveSpeed=>_moveSpeed;
        public float RotationSpeed=>_rotationSpeed;
        public int Lifes => _lifes;
        
    }
}