using UnityEngine;
using System.Collections;

public class MouseOnEdge : MonoBehaviour {

    float speed = 20.0f;
    float zoomSpeed = 0.15f;
    float zoomMax = 0.2f;
    float zoomMin = 1.0f;
    int boundary = 2;
    int width;
    int height;

    void Start()
    {
        width = Screen.width;
        height = Screen.height;

    }

    void Update()
    {
        // Edge Detection and Camera Movement
        if (Input.mousePosition.x > width - boundary)
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0.0f, 0.0f);
        }

        if (Input.mousePosition.x < 0 + boundary)
        {
            transform.position += new Vector3(-Time.deltaTime * speed, 0.0f, 0.0f);
        }

        if (Input.mousePosition.y > height - boundary)
        {
            transform.position += new Vector3(0.0f, 0.0f, Time.deltaTime * speed);
        }

        if (Input.mousePosition.y < 0 + boundary)
        {
            transform.position += new Vector3(0.0f, 0.0f, -Time.deltaTime * speed);
        }

        // Camera Zoom
        /*float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (transform.position.y > zoomMax && transform.position.y < zoomMin)
        {
            if (transform.position.y != zoomMax - 0.01f || transform.position.y != zoomMin + 0.01f)
                transform.Translate(0, 0, scroll * zoomSpeed);
        }

        if (transform.position.y <= zoomMax)
            transform.position = new Vector3(transform.position.x, zoomMax - 0.01f, transform.position.z);

        if (transform.position.y >= zoomMin)
            transform.position = new Vector3(transform.position.x, zoomMin + 0.01f, transform.position.z);*/


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Mathf.Clamp
        //transform.Translate(0, 0, scroll * zoomSpeed);
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x - scroll * zoomSpeed, zoomMax, zoomMin), Mathf.Clamp(transform.localScale.y - scroll * zoomSpeed, zoomMax, zoomMin), Mathf.Clamp(transform.localScale.z - scroll * zoomSpeed, zoomMax, zoomMin));

    }
}
