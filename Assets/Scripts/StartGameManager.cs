using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private LevelsManager levelsManager;

    private void Awake()
    {
        levelsManager.StartGame();
    }
}
