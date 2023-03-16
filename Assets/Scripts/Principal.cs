using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour
{
    public Image imagemIcone;

    public Image imagemEnergia;
    public TextMeshProUGUI textoOvos;
    public TextMeshProUGUI textoVidas;
    
    public Sprite[] iconesEnergia;


    int _ovos;
    int _vidas;
    int _penas;


    void Start()
    {
        imagemIcone.transform.position = new Vector2( imagemIcone.GetComponent<RectTransform>().sizeDelta.x/2 + 20, 
            Screen.height - imagemIcone.GetComponent<RectTransform>().sizeDelta.y/2 - 10);

        imagemEnergia.transform.position = new Vector2(Screen.width / 2 , 
            Screen.height - imagemEnergia.GetComponent<RectTransform>().sizeDelta.y / 2 - 10);

        textoOvos.transform.position = new Vector2(Screen.width - textoOvos.GetComponent<RectTransform>().sizeDelta.x / 2 - 15, 
            Screen.height - textoOvos.GetComponent<RectTransform>().sizeDelta.y / 2 - 40);


        imagemEnergia.GetComponent<Image>().sprite = iconesEnergia[4];

        GameObject[] listaDeOvos = GameObject.FindGameObjectsWithTag("Ovo");
        _ovos = listaDeOvos.Length;
        textoOvos.text = _ovos.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PegaOvo()
    {
        Debug.Log("Pegou");
        _ovos --;
        if (_ovos <= 0 )
        {
            _ovos = 0;
            PegouTodosOsOvos();
        }
        textoOvos.text = _ovos.ToString();
    }

    public void PegaPena()
    {

    }
    public void PegouTodosOsOvos()
    {

    }
    public void PegaEstrela()
    {

    }

    public void EfeitoPancada()
    {

    }

    public void CaiNoBuraco()
    {

    }

}
