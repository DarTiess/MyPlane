using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Data/SceneSettings", fileName = "SceneData")]
    public class SceneSettings : ScriptableObject
    {
        [SerializeField] private List<string> _scene;
        public List<string> Scenes => _scene;
    }
}