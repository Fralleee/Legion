using Fralle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTargeter : Targeter
{
  [SerializeField] Portrait portrait;
  [SerializeField] GameObject targetIndicatorPrefab;
  GameObject targetIndicator;
  new Collider collider;

  public float maxRange = 30f;

  void Awake()
  {
    collider = GetComponent<Collider>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab)) FindTarget();
  }

  void FindTarget()
  {
    if (targetIndicator)
    {
      Destroy(targetIndicator);
      targetIndicator = null;
    }

    if (!currentTarget)
    {
      RaycastHit hit;
      if (Physics.SphereCast(transform.position.With(y: 1), 2f, transform.forward, out hit, maxRange, enemyLayerMask))
      {
        SetCurrentTarget(hit.collider.gameObject);
        return;
      }
    }
    else
    {
      Collider[] colliders = Physics.OverlapSphere(transform.position, maxRange, enemyLayerMask);
      if (colliders.Length == 0) return;
      colliders = colliders.OrderBy(x => x.ClosestDistanceSqrt(collider)).ToArray();
      int currentIndex = Array.IndexOf(colliders, currentTarget.collider);

      if (currentIndex == -1)
      {
        currentIndex = 0;
      }
      else
      {
        if (currentIndex == colliders.Length - 1) currentIndex = 0;
        else currentIndex++;
      }
      SetCurrentTarget(colliders[currentIndex].gameObject);
    }

  }

  void SetCurrentTarget(GameObject target)
  {
    currentTarget = new Target(target);

    if(portrait)
    {
      portrait.SetupPortrait(currentTarget);
    }

    SetupTargetIndicator();
  }

  void SetupTargetIndicator()
  {
    targetIndicator = Instantiate(targetIndicatorPrefab, currentTarget.transform.position, Quaternion.Euler(90, 0, 0), currentTarget.transform);
  }
}
