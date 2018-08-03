[System.Serializable]
public enum TargetType
{
  SELF = 1,
  FRIENDLY = 2,
  HOSTILE = 3
}

[System.Serializable]
public enum TargetPriority
{
  NEAREST = 1,
  LOWHEALTH = 2
}

[System.Serializable]
public enum TargetReceiver
{
  TARGET = 1,
  LOCATION = 2
}

[System.Serializable]
public enum AbilityType
{
  INSTANT = 1,
  PROJECTILE = 2
}

[System.Serializable]
public enum EffectSequence
{
  PRE = 1,
  CAST = 2,
  HIT = 3
}

