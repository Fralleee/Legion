using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField] Image foregroundImage;
  [SerializeField] Image changeIndicator;
  float oldValue = 1f;
  private const float updateSpeedSeconds = 0.2f;

  void Awake()
  {
    GetComponentInParent<DamageController>().OnHealthChange += HandleHealthChange;
  }

  void HandleHealthChange(float currentHealth, float maxHealth, bool animate)
  {
    float percentage = currentHealth / maxHealth;
    if (animate)
    {
      StopAllCoroutines();
      StartCoroutine(percentage < oldValue ? AnimateHealthLoss(percentage) : AnimateHealthGain(percentage));
    }
    else
    {
      changeIndicator.fillAmount = percentage;
      foregroundImage.fillAmount = percentage;
    }

    oldValue = percentage;
  }

  IEnumerator AnimateHealthGain(float percentage)
  {
    changeIndicator.fillAmount = percentage;
    changeIndicator.color = new Color(0.67f, 0.85f, 1f);
    float beforeChange = foregroundImage.fillAmount;
    float elapsed = -0.25f;

    while (elapsed < updateSpeedSeconds)
    {
      elapsed += Time.deltaTime;
      foregroundImage.fillAmount = Mathf.Lerp(beforeChange, percentage, elapsed / updateSpeedSeconds);
      yield return null;
    }

    foregroundImage.fillAmount = percentage;
  }

  IEnumerator AnimateHealthLoss(float percentage)
  {
    foregroundImage.fillAmount = percentage;
    changeIndicator.color = new Color(0.96f, 0.95f, 0.07f);
    float beforeChange = changeIndicator.fillAmount;
    float elapsed = -0.5f;
    while (elapsed < updateSpeedSeconds)
    {
      elapsed += Time.deltaTime;
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
