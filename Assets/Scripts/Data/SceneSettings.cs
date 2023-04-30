using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/SceneSettings", fileName = "SceneData")]
    public class SceneSettings : ScriptableObject
    {
        public List<string> scenes;
    }
}