using UnityEngine;

public enum BlockType
{
  Action,   // Blocks everything
  Movement, // Blocks movement and camera
  Ability,  // Blocks abilities
  Attack    // Blocks attack abilities
}

[CreateAssetMenu]
public class Blocker : ScriptableObject
{
  public BlockType type;
}
