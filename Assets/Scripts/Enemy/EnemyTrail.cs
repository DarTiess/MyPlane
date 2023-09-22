using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(TrailRenderer))]
    public class EnemyTrail : MonoBehaviour
    {
        private TrailRenderer _trailRenderer;
        public void SetTrailsSettings(Color color)
        {
            _trailRenderer = GetComponent<TrailRenderer>();
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