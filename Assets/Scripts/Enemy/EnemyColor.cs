using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyColor: MonoBehaviour
    {
        private SpriteRenderer renderer;
        public void SetEnemyColor(Color color)
        {
            renderer = GetComponent<SpriteRenderer>();
            renderer.color = color;
        }
    }
}