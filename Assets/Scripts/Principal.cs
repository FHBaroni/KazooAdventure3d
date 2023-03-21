using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Principal : MonoBehaviour
{
    public GameObject oculosX;
    public GameObject jogador;
    public Image imagemIcone;
    public Image imagemEnergia;
    public TextMeshProUGUI textoOvos;
    public TextMeshProUGUI textoVidas;

    public Sprite[] iconesEnergia;

    GameObject cubo;

    int _ovos;
    int _vidas;
    int _penas = 4;
    int pisca;


    void Start()
    {
        cubo = GameObject.Find("CuboVidro");

        imagemIcone.transform.position = new Vector2(imagemIcone.GetComponent<RectTransform>().sizeDelta.x / 2 + 20,
            Screen.height - imagemIcone.GetComponent<RectTransform>().sizeDelta.y / 2 - 10);

        imagemEnergia.transform.position = new Vector2(Screen.width / 2,
            Screen.height - imagemEnergia.GetComponent<RectTransform>().sizeDelta.y / 2 - 10);

        textoOvos.transform.position = new Vector2(Screen.width - textoOvos.GetComponent<RectTransform>().sizeDelta.x / 2 - 15,
            Screen.height - textoOvos.GetComponent<RectTransform>().sizeDelta.y / 2 - 40);


        imagemEnergia.GetComponent<Image>().sprite = iconesEnergia[_penas];

        GameObject[] listaDeOvos = GameObject.FindGameObjectsWithTag("Ovo");
        _ovos = listaDeOvos.Length;
        textoOvos.text = _ovos.ToString();

        //oculosX = GameObject.Find("felpudoPlayer")
    }

    void Update()
    {

    }

    public void PegaOvo()
    {
        Debug.Log("Pegou");
        _ovos--;
        if (_ovos <= 0)
        {
            _ovos = 0;
            PegouTodosOsOvos();
        }
        textoOvos.text = _ovos.ToString();
    }

    public void PegaPena()
    {
        _penas++;
        if (_penas > 8)
        {
            _penas = 8;
        }
        imagemEnergia.GetComponent<Image>().sprite = iconesEnergia[_penas];
    }

    public void PegouTodosOsOvos()
    {
        cubo.SetActive(false);
    }

    public void PegaEstrela()
    {
        print("estrela");
        Invoke("RecarregarCena", 1.5f);
    }

    public void PerdePena()
    {
        _penas--;
        if (_penas <= 0)
        {
            _penas = 0;
            PerdeJogo();
        }
        imagemEnergia.GetComponent<Image>().sprite = iconesEnergia[_penas];
    }

    void RecarregarCena()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CaiNoBuraco()
    {
        Invoke("RecarregarCena", 1.5f);
    }

    public void PerdeJogo()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EventoPancdada()
    {
        PerdePena();
            InvokeRepeating("PiscaFelpudo", 0, 0.15f);
        jogador.GetComponent<CharacterController>().Move(jogador.transform.TransformDirection(Vector3.back));
    }

    public void PiscaFelpudo()
    {
        pisca++;
        jogador.SetActive(!jogador.activeInHierarchy);
        if (pisca > 7 )
        {
            pisca = 0;
            jogador.SetActive(true);
            CancelInvoke("PiscaFelpudo");
        }

    }

    public void ativaOculos()
    {
        oculosX.SetActive(true);
    }

}
