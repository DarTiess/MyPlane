using UnityEngine;

namespace Enemy
{
    public class EnemyTrail
    {
        private TrailRenderer _trailRenderer;

        public EnemyTrail(TrailRenderer trailRenderer, Color color)
        {
            _trailRenderer = trailRenderer;
            SetTrailsSettings(color);
        }

        private void SetTrailsSettings(Color color)
        {
            float alpha = 1.0f;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) },
                new[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            _trailRenderer.colorGradient = gradient;
        }
    }
}