using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ControlaInimigo : MonoBehaviour {

        public GameObject Jogador;
            public float Velocidade = 5;

        // Use this for inicialization
        void Start () {

        }

        //Update is called once per frame
        void Update () {

        }

        void FixedUpdate()
        {


            float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

            Vector3 direcao = Jogador.transform.position - transform.position;

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);

            

            if (distancia > 2)
            {
                
                GetComponent<Rigidbody>().MovePosition
                    (GetComponent<Rigidbody>().position + 
                        direcao.normalized * Velocidade * Time.deltaTime);

                GetComponent<Animator>().SetBool("Atacando", false);
                
            }
            else
            {
                GetComponent<Animator>().SetBool("Atacando", true);
            }
        }

        void AtacaJogador()
        {
            Time.timeScale = 0;
            Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
            Jogador.GetComponent<ControlaJogador>().Vivo = false;
        }
    }