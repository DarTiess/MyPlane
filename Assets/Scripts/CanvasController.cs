using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
public class CanvasController : MonoBehaviour
{
    
    public CanvasGroup startGroupe;
    public CanvasGroup playGroupe;
    public CanvasGroup failGroupe;
    public CanvasGroup headerGroupe;

    public TextMeshProUGUI countLifes;

    [SerializeField] private int lifesOnStart = 12;
    List<CanvasGroup> canvasGroupes = new List<CanvasGroup>();
    public int _Lifes
    {
        get { return PlayerPrefs.GetInt("Lifes"); }
        set { PlayerPrefs.SetInt("Lifes", value); }
    }
    // Start is called before the first frame update
    void Start()
    {  countLifes.text = lifesOnStart.ToString();
        if (_Lifes <= 0)
        {
            _Lifes = lifesOnStart;
        }
        else
        {
            lifesOnStart = _Lifes;
        }
        countLifes.text = lifesOnStart.ToString();
       GameManager.Instance.IsStarting += OnStart;
     
       GameManager.Instance.IsFail += OnFail;

        canvasGroupes.Add(startGroupe);
        canvasGroupes.Add(playGroupe);
        canvasGroupes.Add(failGroupe);

      
    }

   void OnStart()
    {
        headerGroupe.alpha = 1;
        headerGroupe.interactable = true;
        headerGroupe.blocksRaycasts = true;
      
        ActivateUIScreen(startGroupe);
    }
   public void OnGame()
    {
        GameManager.Instance.PlayGame();
        ActivateUIScreen(playGroupe);
    }
    void OnFail()
    {
        ActivateUIScreen(failGroupe);
    }
    public void DisplayDamage()
    {
        if (lifesOnStart <= 0)
        {
            return;
        }
       lifesOnStart-=1;
        _Lifes = lifesOnStart;
        countLifes.text = lifesOnStart.ToString();
        countLifes.transform.DOScale(1.5f, 0.5f)
            .OnComplete(() => {
                countLifes.transform.DOScale(1f, 0.5f);
            });
        if (lifesOnStart <= 0)
        {
            GameManager.Instance.FailGame();
        }
    }

    void ActivateUIScreen(CanvasGroup uiScreen)
    {
        foreach (CanvasGroup cGr in canvasGroupes)
        {
            if (cGr != uiScreen)
            {
                cGr.alpha = 0;
                cGr.interactable = false;
                cGr.blocksRaycasts = false;
            }
            else
            {
                cGr.alpha =1;
                cGr.interactable = true;
                cGr.blocksRaycasts =true;
            }
        }
    }
}
