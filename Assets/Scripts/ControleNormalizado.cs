using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNormalizado : MonoBehaviour
{
    CharacterController ccPlayer;

    float velocidade = 5;
    float giro = 180.0f;
    float pulo = 3.0f;
    float frente;
    float gravidade = 3.5f;

    public bool grounded;

    public GameObject jogador;
    public Animation animacaoJogador;

    Transform TransformCamera;
    Vector3 moveCameraFrente;
    Vector3 objetoMove;
    Vector3 NormalZeroPiso = new Vector3(0, 0, 0);
    Vector3 vetorDirecao = new Vector3(0, 0, 0);

    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        animacaoJogador = jogador.GetComponent<Animation>();
        TransformCamera = Camera.main.transform;
    }

    void Update()
    {
        if (ccPlayer.isGrounded)
        {
            grounded = true;
        }
        else
        {
            grounded = false;

        }
        moveCameraFrente = Vector3.Scale(TransformCamera.forward, new Vector3(1, 0, 1)).normalized;
        objetoMove = Input.GetAxis("Vertical") * moveCameraFrente + Input.GetAxis("Horizontal") * TransformCamera.right;

        vetorDirecao.y -= gravidade * Time.deltaTime;

        ccPlayer.Move(vetorDirecao * Time.deltaTime);
        ccPlayer.Move(objetoMove * velocidade * Time.deltaTime);

        if (objetoMove.magnitude > 1f)
        {
            objetoMove.Normalize();
        }

        objetoMove = transform.InverseTransformDirection(objetoMove);

        objetoMove = Vector3.ProjectOnPlane(objetoMove, NormalZeroPiso);
        giro = Mathf.Atan2(objetoMove.x, objetoMove.z);
        frente = objetoMove.z;

        ccPlayer.SimpleMove(Physics.gravity);

        AplicaRotacao();

        if (Input.GetButton("Jump"))
        {
            vetorDirecao.y = pulo;
            //  transform.position += direcaoG;
            animacaoJogador.GetComponent<Animation>().Play("jump");
        }
        else
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (!animacaoJogador.IsPlaying("jump"))
                {
                    animacaoJogador.GetComponent<Animation>().Blend("walk", 0.1f);
                }
            }
            else
            {
                animacaoJogador.GetComponent<Animation>().Blend("Idle", 0.1f);
            }
        }
    }
    void AplicaRotacao()
    {
        float turnSpeed = Mathf.Lerp(180, 360, frente);
        transform.Rotate(0, giro * turnSpeed * Time.deltaTime, 0);
    }
}
