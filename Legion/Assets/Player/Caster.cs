using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
  [SerializeField] StringRangeVariable progress;
  [SerializeField] ActiveAbility activeAbility;
  
  [SerializeField] BlockerList blockerList;
  [SerializeField] Blocker blocker;

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


  void ApplyBlocker()
  {
    if (!blockerList.blockers.Contains(blocker)) blockerList.blockers.Add(blocker);
  }

  void RemoveBlocker()
  {
    if (blockerList.blockers.Contains(blocker)) blockerList.blockers.Remove(blocker);
  }

  public bool isBlocked
  {
    get { return blockerList.blockers.Exists(x => x.Abilities && x != blocker); }
  }

}
