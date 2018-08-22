using Fralle;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StartRound : MonoBehaviour
{
  [SerializeField] GameEvent onRoundStart;
  [SerializeField] GameObject golem;

  void Start()
  {
    onRoundStart.Raise();
  }

  public void SetTargetOnAllTeamBlue()
  {
    List<GameObject> blueGuys = FindGameObjectsWithLayer(LayerMask.NameToLayer("Team Blue"));
    foreach(GameObject blueGuy in blueGuys)
    {
      AITargeter targeter = blueGuy.GetComponent<AITargeter>();
      if(targeter) targeter.SetObjective(golem);
    }
  }

  List<GameObject> FindGameObjectsWithLayer(int layer){
    List<GameObject> list = new List<GameObject>();
    foreach(GameObject go in FindObjectsOfType<GameObject>())
      if (go.layer == layer) list.Add(go);
    return list;
 }

}
