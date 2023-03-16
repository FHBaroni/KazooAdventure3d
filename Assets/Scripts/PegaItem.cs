using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;


public class PegaItem : MonoBehaviour
{
    public GameObject particula;
    public Color cor;
    GameObject objetoPrincicpal;

    void Start()
    {
        objetoPrincicpal = GameObject.Find("GameEngine");
    }


    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case "Ovo": objetoPrincicpal.SendMessage("PegaOvo"); break;
                case "Pena": objetoPrincicpal.SendMessage("PegaPena"); break;
                case "Estrela": objetoPrincicpal.SendMessage("PegaEstrela"); break;
                case "Fogo": objetoPrincicpal.SendMessage("EfeitoPancada"); break;
                case "Finish": objetoPrincicpal.SendMessage("CaiNoBuraco"); break;
                default: break;
            }
        }
        if (particula != null)
        {
            GameObject minhaParticula = Instantiate(particula);
            minhaParticula.transform.position = transform.position;
            MainModule mainModule = minhaParticula.GetComponent<ParticleSystem>().main;
            mainModule.startColor = cor;
        }
        Destroy(gameObject);
       
    }
}
