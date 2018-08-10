using System;
using System.Collections;
using UnityEngine;

// REPLACE THIS
public enum CastAnimation
{
  QuickCast1,
  LargeCast1,
  SpellCast
}

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : AbilityCaster
{
  BlockerController blockerController;
  [SerializeField] Blocker blocker;
  Animator animator;

  public bool IsBlocked { get { return blockerController.ContainsBlocker(abilities: true); } }

  protected override void Start()
  {
    base.Start();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
  }

  public bool TryCast(Ability ability)
  {
    GameObject target = ability.FindTarget(targeter);
    if (target == null) return false;

    blockerController.AddBlocker(blocker);
    StartCoroutine(Cast(ability, target));
    return true;
  }

  public IEnumerator Cast(Ability ability, GameObject target)
  {
    animator.SetBool(ability.Animation.ToString(), true);
    if (!target)
    {
      blockerController.RemoveBlocker(blocker);
      animator.SetBool(ability.Animation.ToString(), false);
      yield break;
    }

    targeter.SetCurrentTarget(target);
    yield return new WaitForSeconds(ability.WindupTime);

    if (!target)
    {
      animator.SetBool(ability.Animation.ToString(), false);
      blockerController.RemoveBlocker(blocker);
      yield break;
    }

    animator.SetTrigger("ReleaseCast");
    ability.Cast(target);

    yield return new WaitForSeconds(0.1f);
    animator.SetBool(ability.Animation.ToString(), false);
    yield return new WaitForSeconds(Math.Max(ability.RecoveryTime, 0.5f) - 0.1f);
    
    blockerController.RemoveBlocker(blocker);
  }
}