using UnityEngine;

[CreateAssetMenu(menuName = "Match/Team Settings")]
public class TeamSettings : ScriptableObject
{
  public enum Team { Blue, Orange }
  public Team team;
  [HideInInspector] public int teamLayer;
  [HideInInspector] public int enemyLayer;
  public GameObject MainObjective;
  public void Setup()
  {
    teamLayer = LayerMask.NameToLayer(team == Team.Blue ? "Blue" : "Orange");
    enemyLayer = LayerMask.NameToLayer(team == Team.Blue ? "Orange" : "Blue");
    MainObjective = GameObject.Find(team == Team.Blue ? "Orange Golem" : "Blue Golem");
  }
  void OnEnable() { Setup(); }
}
