using UnityEngine;

public class ImpactReceiver : BlockerBehaviour
{
  [Header("Impact Settings")]
  [SerializeField] float mass = 3f;
  [Range(0, 1)] [SerializeField] float smoothing = 0.25f;
  Vector3 impact = Vector3.zero;
  Vector3 accelerationTarget = Vector3.zero;
  Vector3 acceleration = Vector3.zero;
  CharacterController controller;
  public bool hasActiveImpact { get { return impact.magnitude < 0.2; } }

  void Start()
  {
    controller = GetComponent<CharacterController>();
  }

  void Update()
  {
    if (impact.magnitude > 0.2f) controller.Move(impact * Time.deltaTime);
    impact = Vector3.Lerp(impact, Vector3.zero, Time.deltaTime / smoothing);
    if (accelerationTarget.magnitude > 1f) ApplyAccelerationForce();
  }

  public void AddImpact(Vector3 dir, float force)
  {
    dir.y = dir.y < 0 ? -dir.y : dir.y;
    impact += dir.normalized * force / mass;
  }

  public void AccelerateTo(Vector3 target)
  {
    accelerationTarget = target;
  }

  void ApplyAccelerationForce()
  {
    float distance = Vector3.Distance(transform.position, accelerationTarget);
    if (distance > 1f)
    {
      acceleration = (accelerationTarget - transform.position).normalized * (100f - Vector3.Distance(transform.position, accelerationTarget));
      Vector3.Lerp(acceleration, Vector3.zero, Time.deltaTime / smoothing);
      controller.Move(acceleration * Time.deltaTime);
    }
    else
    {
      accelerationTarget = Vector3.zero;
      acceleration = Vector3.zero;
    }
  }

}
