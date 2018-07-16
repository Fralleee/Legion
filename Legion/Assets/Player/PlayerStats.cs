using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
  public FloatVariable Health;

  public void TakeDamage(float damage)
  {
    Health.currentValue -= damage;
  }
}
