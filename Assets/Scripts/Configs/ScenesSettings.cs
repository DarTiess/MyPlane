using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScenesSettings 
{
    [SerializeField] private List<string> scene;
    public List<string> Scenes => scene;
}