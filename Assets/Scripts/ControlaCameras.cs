using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCameras : MonoBehaviour
{
    public GameObject cameraJogo;
    void Start()
    {
      //  cameraJogo = GameObject.Find("CameraJogo ");
        //cameraJogo.SetActive(false);
    }

    // Update is called once per frame
    public void MudaCamera()
    {
        print("show");
       cameraJogo.SetActive(true);
    this.gameObject.SetActive(false);
    }
}
