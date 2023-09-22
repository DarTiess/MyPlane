using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class EnemyColor: MonoBehaviour
    {
        private SpriteRenderer _renderer;
        public void SetEnemyColor(Color color)
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = color;
        }
    }
}