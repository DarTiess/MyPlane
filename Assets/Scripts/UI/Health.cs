using DG.Tweening;
using GameEvents;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Health: MonoBehaviour
      {
          [SerializeField] private TextMeshProUGUI countLifes;
          [SerializeField] private int lifesOnStart = 12;
          private IGameState _gameState;
        
          public int _Lifes
          {
              get { return PlayerPrefs.GetInt("Lifes"); }
              set { PlayerPrefs.SetInt("Lifes", value); }
          }
   
          public void SetLifesCount(IGameEvents gameEvents, IGameState gameState)
          {
              _gameState = gameState;
              gameEvents.TakeDamage += DisplayDamage;
              if (_Lifes <= 0)
              {
                  _Lifes = lifesOnStart;
              }
              else
              {
                  lifesOnStart = _Lifes;
              }
   
              countLifes.text = lifesOnStart.ToString();
          }
   
          private void DisplayDamage()
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
                  _gameState.FailGame();
              }
          }
      }
}