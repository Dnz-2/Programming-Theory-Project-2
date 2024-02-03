using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceCamera();
    }

    void PlaceCamera()
    {
        transform.position = cameraPosition.transform.position;
        transform.eulerAngles = cameraPosition.transform.eulerAngles;
    }
}
