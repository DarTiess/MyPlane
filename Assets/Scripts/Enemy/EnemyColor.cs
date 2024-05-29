using UnityEngine;

namespace Enemy
{
    public class EnemyColor
    {
        private SpriteRenderer _renderer;

        public EnemyColor(SpriteRenderer renderer, Color color)
        {
            _renderer = renderer;
            _renderer.color = color;
        }
    }
}