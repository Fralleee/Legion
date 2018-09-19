using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTargeter : Targeter
{
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab)) FindTarget();
  }

  void FindTarget()
  {
    RaycastHit hit;
    if (Physics.SphereCast(transform.position.With(y: 1), 2f, transform.forward, out hit, 25f, enemyLayerMask | teamLayerMask))
    {
      currentTarget = new Target(hit.collider.gameObject);
    }
  }
}
