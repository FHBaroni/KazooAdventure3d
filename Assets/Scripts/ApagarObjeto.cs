using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagarObjeto : MonoBehaviour
{

    public float tempo = 1.5f;
    void Start()
    {
        Invoke("DestroiObjeto", tempo);
    }

    void DestroiObjeto()
    {
        Destroy (gameObject);   
    }
}
