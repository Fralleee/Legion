using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Requirements/Line of sight")]
public class RequireLineOfSight : AbilityRequirement
{
  public override bool Test(AbilityCaster caster, Ability ability, GameObject target, bool useSelfCast = false)
  {
    //Debug.Log("Testing Require Line Of Sight");
    if (!target) return false;
    LayerMask layerMask = 1 << ability.environmentLayer | 1 << ability.targetLayer;
    Vector3 direction = target.transform.position - caster.transform.position;

    Ray ray = new Ray(caster.transform.position, direction);
    Debug.DrawRay(caster.transform.position, direction, Color.red, 0.5f);

    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, ability.range, layerMask))
    {
      bool isTarget = hit.collider.gameObject == target;
      return isTarget;
    }
    return false;
  }
}
