using System.Collections.Generic;
using Enemy;
using UnityEngine;


[System.Serializable]
public class EnemySettings
{
    [SerializeField] private EnemyView prefab;
    [SerializeField] private List<ViewSettings> viewSettings;
       
    public List<ViewSettings> View => viewSettings;
    public EnemyView Prefab => prefab;
}