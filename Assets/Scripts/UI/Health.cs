using Data;
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
          private IGameState gameState;
          private IDataSaver dataSaver;
          private int lifes;
   
          public void Init(IGameEvents gameEvents, IGameState gameStates, IDataSaver dataSavers)
          {
              gameState = gameStates;
              gameEvents.TakeDamage += DisplayDamage;
              dataSaver = dataSavers;
             
              SetLifesCountText();
          }
          private void SetLifesCountText()
          {
              lifes = dataSaver.Lifes;
              if (lifes <= 0)
              {
                  lifes = lifesOnStart;
                  dataSaver.Lifes = lifes;
              }
              else
              {
                  lifesOnStart = lifes;
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
              lifes = lifesOnStart;
              dataSaver.Lifes = lifes;
              countLifes.text = lifesOnStart.ToString();
              countLifes.transform.DOScale(1.5f, 0.5f)
                        .OnComplete(() => {
                            countLifes.transform.DOScale(1f, 0.5f);
                        });
              if (lifesOnStart <= 0)
              {
                  gameState.FailGame();
              }
          }
      }
}