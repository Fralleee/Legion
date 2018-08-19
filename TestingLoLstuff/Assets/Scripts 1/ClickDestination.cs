using UnityEngine;
using System.Collections;

public class ClickDestination : MonoBehaviour {

    [Header("Raycast")]
    public Camera cam;
    public float raycastLength;

    [Header("Character")]
    public GameObject character;
    private UnityEngine.AI.NavMeshAgent characterAgent;

    private Vector3 outPosition;

    [System.Serializable]
    public enum MouseClick
    {
        Left,
        Middle,
        Right
    };

	void Start () {
        characterAgent = character.GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(DrawLines());
	}
	
	void Update () {

        // Inspect mouse events
        if (Input.GetMouseButtonDown(0))
            DoLeftClick();
        else if (Input.GetMouseButtonDown(1))
            DoRightClick();
        else
            DoMiddleClick();
        
	}

    // Mouse clicks methods

    void DoLeftClick()
    {

    }

    void DoRightClick()
    {
        SetDestination();
    }

    void DoMiddleClick()
    {

    }

    // Core methods

    void SetDestination()
    {
        characterAgent.SetDestination(GetMouseRaycast());
    }

    Vector3 GetMouseRaycast()
    {
        outPosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastLength))
        {
            outPosition = hit.point;
        }

        return outPosition;
    }

    // Utility methods

    void DrawPath(UnityEngine.AI.NavMeshPath path, Color color)
    {
        Vector3 previousCorner = path.corners[0];
        for (int i = 1; i < path.corners.Length; i++)
        {
            Vector3 curCorner = path.corners[i];
            Debug.DrawLine(previousCorner, curCorner, color);
            previousCorner = curCorner;
        }
    }

    IEnumerator DrawLines()
    {
        while(true)
        {
            Debug.DrawLine(cam.transform.position, outPosition, Color.red);
            DrawPath(characterAgent.path, Color.blue);
            yield return null;
        }
    }
}
