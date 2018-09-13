using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public FloatVariable Health;
  public FloatVariable Gold;
  public FloatVariable Wood;

  public void TakeDamage(float damage)
  {
    Health.currentValue -= damage;
  }
}
