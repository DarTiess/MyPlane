using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "EnemySettings", fileName = "EnemyData", order = 51)]
    public class EnemySetting: ScriptableObject
    {
        public Color color;
        public float delay;
    }
}