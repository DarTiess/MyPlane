using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Data/EnemySettings", fileName = "EnemyData", order = 51)]
    public class EnemySetting: ScriptableObject
    {
        [SerializeField] private Color _color;
        [SerializeField] private float _delay;
         public Color Color => _color;
         public float Delay => _delay;
    }
}