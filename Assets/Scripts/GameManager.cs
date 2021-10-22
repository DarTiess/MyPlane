using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public enum GameStatus
    {
        isStarting,
        isGaming,
        onPause,
        isStop,
    }
    public static GameManager Instance { get; private set; }

    public CanvasGroup startGroupe;
    public CanvasGroup playGroupe;
    public CanvasGroup failGroupe;
    public CanvasGroup headerGroupe;

    public TextMeshProUGUI countLifes;
   
    int countlife=12;

    // [HideInInspector] public bool isGaming;
    [HideInInspector] public GameStatus statusOfGame;
  

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DisplayUIScreen("Start");
    }

    // Update is called once per frame
    void Update()
    {
        countLifes.text = countlife.ToString();
    }
    public void StartGame()
    {
        DisplayUIScreen("Play");

    }

    public void DisplayUIScreen(string nameOfScreen)
    {
        switch (nameOfScreen)
        {
            case "Start":
                ActivateUIScreen(startGroupe);
                statusOfGame = GameStatus.isStarting;
                break;
            case "Play":
                statusOfGame = GameStatus.isGaming;
                ActivateUIScreen(playGroupe);
                break;
            case "Fail":
                statusOfGame = GameStatus.isStop;
                 ActivateUIScreen(failGroupe);
                break;

        }
    }
    void ActivateUIScreen(CanvasGroup uiScreen)
    {
        DeactivateOtherUIScreens(uiScreen);

        uiScreen.alpha = 1;
        uiScreen.interactable = true;
        uiScreen.blocksRaycasts = true;

        headerGroupe.alpha = 1;
        headerGroupe.interactable = true;
        headerGroupe.blocksRaycasts = true;

    }

    void DeactivateOtherUIScreens(CanvasGroup uiScreen)
    {
        CanvasGroup[] canvasGroupes = GameObject.FindObjectsOfType<CanvasGroup>();
        foreach (CanvasGroup cGr in canvasGroupes)
        {
            if (cGr != uiScreen)
            {
                cGr.alpha = 0;
                cGr.interactable = false;
                cGr.blocksRaycasts = false;
            }
        }
    }
    public void FailGame()
    {

        DisplayUIScreen("Fail");

    }
    public void RestartGame()
    {
        countlife=12;
        PlaneMove.Instance.RestartPlane();
        SetEnemyPositionRestart();
        DisplayUIScreen("Play");

    }
   

    public void QuiteGame()
    {
        Application.Quit();
    }
    public void DisplayDamage()
    {
        countlife--;
        if (countlife <= 0)
        {
            FailGame();
        }
    }
    void SetEnemyPositionRestart()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().RestartEnemy();
        }
    }


}
