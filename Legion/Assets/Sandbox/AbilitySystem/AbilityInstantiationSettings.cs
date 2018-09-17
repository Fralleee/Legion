using System;

public enum TargetInstantiationPosition { TargetFeet, TargetCenter, TargetHead }
public enum CasterInstantiationPosition { CasterFeet, CasterRightHand, CasterLeftHand, CasterCenter, CasterHead }
public enum PointInstantiationPosition { Ground }

[Serializable]
public class TargetInstantiationSettings
{
  public TargetInstantiationPosition InstantiationPosition;
  public bool useLocalScale;
}

[Serializable]
public class DirectionInstantiationSettings
{
  public CasterInstantiationPosition InstantiationPosition;
}

[Serializable]
public class PointInstantiationSettings
{
  public PointInstantiationPosition InstantiationPosition;
}
