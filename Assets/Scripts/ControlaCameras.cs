using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCameras : MonoBehaviour
{
    GameObject cameraJogo;
    void Start()
    {
        cameraJogo = GameObject.Find("CameraJogo");
        //cameraJogo.SetActive(false);
    }

    // Update is called once per frame
    public void MudaCamera()
    {
        cameraJogo.SetActive(true);
        gameObject.SetActive(false);
    }
}
