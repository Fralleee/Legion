using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fralle;

public class Caster : BlockerBehaviour
{
  [SerializeField] StringRangeVariable progress;
  [SerializeField] ActiveAbility activeAbility;

  public Transform[] hands = new Transform[2];

  bool isCasting;
  void Update()
  {
    if (activeAbility.ability != null)
    {
      if (Input.GetMouseButtonDown(0) && !isBlocked && activeAbility.ability.allowCast)
      {
        progress.text = "BUILDING!";
        progress.minValue = 0f;
        progress.maxValue = activeAbility.ability.castTime;
        progress.value = 0f;
        isCasting = true;
        if(!activeAbility.ability.allowMovement) ApplyBlocker();
      }
      else if (isCasting && !isBlocked)
      {
        progress.value += Time.deltaTime;
        if (progress.value >= progress.maxValue)
        {          
          progress.value = 0f;
          isCasting = false;
          activeAbility.ability.Cast();
          if (!activeAbility.ability.allowMovement) RemoveBlocker();
        }
      }
      else if (isCasting && (Input.GetMouseButtonDown(1) || isBlocked))
      {
        progress.value = 0f;
        activeAbility.ability.Cancel();
        isCasting = false;
      }
    }

  }

  public bool isBlocked
  {
    get { return blockerList.blockers.Exists(x => x.Abilities && x != blocker); }
  }

}
