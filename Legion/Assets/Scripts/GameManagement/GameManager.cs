using Fralle;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static event System.Action DestroyUnits = delegate { };
  public static event System.Action SpawnUnits = delegate { };
  public static event System.Action ReleaseUnits = delegate { };
  public static event System.Action EnableBuilding = delegate { };
  public static event System.Action DisableBuilding = delegate { };

  [SerializeField] TextMeshProUGUI currentStateText;
  public static GameManager instance;
  public TriggerVariable skipState;
  StateController stateController;

  void Awake()
  {
    if (instance == null) instance = this;
    else if (instance != this) Destroy(gameObject);
    DontDestroyOnLoad(gameObject);
    stateController = GetComponent<StateController>();
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.P)) TriggerNextState();
    currentStateText.text = "Current State: " + stateController.currentState.name;
  }

  public void TriggerNextState() { skipState.currentValue = true; }
  public void PerformDestroyUnits() { DestroyUnits(); }
  public void PerformSpawnUnits() { SpawnUnits(); }
  public void PerformReleaseUnits() { ReleaseUnits(); }
  public void PerformEnableBuilding() { EnableBuilding(); }
  public void PerformDisableBuilding() { DisableBuilding(); }

}
