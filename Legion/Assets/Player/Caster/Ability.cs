using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ability : ScriptableObject
{
  public float castTime = 1f;
  public float cooldown = 5f;

  Caster caster;
  GameObject instance;
  public GameObject GetInstance() { return instance; }
  public bool allowMovement;
  public bool allowCast
  {
    get
    {
      // Actually we probably want to use a FloatVariable here to check cooldown and also check for blockers
      return true;
    }
  }

  [SerializeField] TargetType targetType;
  [SerializeField] GameObject targetPrefab;

  [Tooltip("When spell is active")] [SerializeField] GameObject[] activeParticles = new GameObject[2];
  [Tooltip("When spell is casting")] [SerializeField] ParticleSystem castingParticles;
  [Tooltip("When casting is complete")] [SerializeField] ParticleSystem onCastParticles;

  List<GameObject> particles = new List<GameObject>();


  public void Initiate(GameObject casterGo)
  {
    caster = casterGo.GetComponent<Caster>();
  }

  public void Cancel()
  {
    // Stop animation
    // Res
  }

  public void ActivateCasterParticles()
  {
    for (int i = 0; i < 2; i++)
    {
      var psInstance = Instantiate(activeParticles[i], caster.hands[i]);
      psInstance.GetComponent<ParticleSystem>().Play();
      particles.Add(psInstance);
    }
  }

  public void DeActivateParticles() { foreach (GameObject g in particles) Destroy(g); }


  void ActivateTargetingPrefab()
  {
    if (targetType != TargetType.Self)
    {
      Vector3 position = caster.transform.position;
      instance = Instantiate(targetPrefab, new Vector3(position.x, 0, position.z) + caster.transform.forward * 2, Quaternion.Euler(0, 0, 0));
      //instance.GetComponent<Targeting>().parent = parent;
    }
  }

  public void Cast()
  {

  }


}
