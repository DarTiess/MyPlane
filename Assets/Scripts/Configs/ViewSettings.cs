using UnityEngine;


[System.Serializable]
public class ViewSettings
{
    [SerializeField] private Color color;
    [SerializeField] private float delay;
    public Color Color => color;
    public float Delay => delay;
}