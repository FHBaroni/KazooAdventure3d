using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleBasico : MonoBehaviour
{
    CharacterController ccPlayer;

    float velocidade = 3;
    float giro = 180.0f;
    float gravidade = 3.5f;
    float pulo = 5.0f;

    Vector3 direcaoG = new Vector3(0,0,0);

    public GameObject jogador;
    public Animation animacaoJogador;

    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        animacaoJogador = jogador.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = Input.GetAxis("Vertical") * velocidade * transform.TransformDirection(Vector3.forward);

        transform.Rotate(giro * Time.deltaTime * new Vector3(0, Input.GetAxis("Horizontal")));

        ccPlayer.Move(movimento * Time.deltaTime);
        ccPlayer.SimpleMove(Physics.gravity);

        if (Input.GetButton("Jump"))
        {
            if (ccPlayer.isGrounded)
            {
                direcaoG.y = pulo;
                jogador.GetComponent<Animation>().Play("jump");
            }
        }
        else
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (!animacaoJogador.IsPlaying("jump"))
                {
                    animacaoJogador.GetComponent<Animation>().Blend("walk", 0.001f);
                }
            }
            else
            {
                if (ccPlayer.isGrounded)
                {
                    animacaoJogador.GetComponent<Animation>().Blend("Idle", 0.001f);
                }
            }
        }

        direcaoG.y -= gravidade * Time.deltaTime;
        ccPlayer.Move(direcaoG * Time.deltaTime);
    }
}
