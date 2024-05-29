using Player;
using UnityEngine;


[System.Serializable]
public class PlayerSettings
{
    [SerializeField] private PlayerView prefab;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int lifes;

    public float MoveSpeed=>moveSpeed;
    public float RotationSpeed=>rotationSpeed;
    public int Lifes => lifes;
    public PlayerView Prefab => prefab;
}