using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Health: MonoBehaviour
      {
          [SerializeField] private TextMeshProUGUI _countLifes;
         
          public void Init(int lifes)
          {
              SetLifesCountText(lifes);
          }

          private void SetLifesCountText(int value)
          {
              _countLifes.text = value.ToString();
          }
          public void DisplayDamage(int value)
          {
              _countLifes.text = value.ToString();
              _countLifes.transform.DOScale(1.5f, 0.5f)
                        .OnComplete(() => {
                            _countLifes.transform.DOScale(1f, 0.5f);
                        });
          }
      }
}