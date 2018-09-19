using Candlelight;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Targeter : MonoBehaviour, ITargeter
{
  [Header("Targets")]
  [SerializeField]
  string CurrentTarget = "No Target";
  Target _currentTarget;
  public Target currentTarget { get { return _currentTarget; } set { _currentTarget = value; CurrentTarget = value.name; } }
  [SerializeField]
  string MainTarget = "No Target";
  Target _mainTarget;
  public Target mainTarget { get { return _mainTarget; } set { _mainTarget = value; MainTarget = value.name; } }
  [SerializeField]
  string Objective = "No Target";
  Target _objective;
  public Target objective { get { return _objective; } set { _objective = value; Objective = value.name; } }

  [Header("Layer masks")]
  [SerializeField]
  LayerMask _teamLayerMask;
  public LayerMask teamLayerMask { get { return _teamLayerMask; } set { _teamLayerMask = value; } }
  [SerializeField]
  LayerMask _spawnLayerMask;
  public LayerMask spawnLayerMask { get { return _spawnLayerMask; } set { _spawnLayerMask = value; } }
  [SerializeField]
  LayerMask _enemyLayerMask;
  public LayerMask enemyLayerMask { get { return _enemyLayerMask; } set { _enemyLayerMask = value; } }
  [SerializeField]
  LayerMask _environmentLayerMask;
  public LayerMask environmentLayerMask { get { return _environmentLayerMask; } set { _environmentLayerMask = value; } }

  [Header("Layers")]
  [SerializeField]
  int _teamLayer;
  public int teamLayer { get { return _teamLayer; } set { _teamLayer = value; } }
  [SerializeField]
  int _spawnLayer;
  public int spawnLayer { get { return _spawnLayer; } set { _spawnLayer = value; } }
  [SerializeField]
  int _enemyLayer;
  public int enemyLayer { get { return _enemyLayer; } set { _enemyLayer = value; } }
  [SerializeField]
  int _environmentLayer;
  public int environmentLayer { get { return _environmentLayer; } set { _environmentLayer = value; } }

}
