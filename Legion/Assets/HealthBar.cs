using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] Image foregroundImage;
  [SerializeField] Image changeIndicator;
  float updateSpeedSeconds = 0.2f;

  void Awake()
  {
    GetComponentInParent<DamageController>().OnHealthChange += HandleHealthChange;
  }

  void HandleHealthChange(float currentHealth, float maxHealth)
  {
    StartCoroutine(AnimateChange(currentHealth / maxHealth));
    foregroundImage.fillAmount = currentHealth / maxHealth;
  }

  IEnumerator AnimateChange(float percentage)
  {
    float beforeChange = changeIndicator.fillAmount;
    float elapsed = -0.5f; // delay

    while (elapsed < updateSpeedSeconds)
    {
      elapsed += Time.deltaTime;
      //if(elapsed > 0)
      changeIndicator.fillAmount = Mathf.Lerp(beforeChange, percentage, elapsed / updateSpeedSeconds);
      yield return null;
    }

    changeIndicator.fillAmount = percentage;
  }

  void LateUpdate()
  {
    transform.LookAt(Camera.main.transform);
    transform.Rotate(0, 180, 0);
  }

}
