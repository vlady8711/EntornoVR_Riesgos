using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    public GameObject Canvas;
    public Text Letrero;
    public AudioClip sonFuego;
    public AudioClip sonTos;
    public AudioClip sonElectrico;
    public AudioClip sonElectrico2;
    public AudioClip sonCaida;
    public AudioClip sonHumo;
    public AudioClip sonGas;
    public AudioClip sonCaeCable;
    public AudioClip sonCaerse;
    public AudioClip sonResbala;

    private AudioSource sonido;
    private AudioSource sonido_aux;


    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.StateUI = 0;
        Canvas.SetActive(false);
        sonido= GetComponent<AudioSource>();
        sonido_aux = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")|| GlobalVariables.StateUI == 0)
        {
            Canvas.SetActive(false);
        }
        if (GlobalVariables.StateUI == 1)
        {
            sonido.clip = sonCaida;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Fragmentación de Objetos";
        }
        if (GlobalVariables.StateUI == 2)
        {
            sonido.clip = sonTos;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Material Particualdo";
        }
        if (GlobalVariables.StateUI == 3)
        {
            sonido.clip = sonFuego;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Posible Incendio";           
        }
        if (GlobalVariables.StateUI == 4)
        {
            sonido.clip = sonHumo;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Humo en exceso";          
        }
        if (GlobalVariables.StateUI == 5)
        {
            sonido.clip = sonGas;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Posible fuga de gas";
        }
        if (GlobalVariables.StateUI == 6)
        {
            sonido.clip = sonElectrico;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Posible riesgo eléctrico";
        }
        if (GlobalVariables.StateUI == 7)
        {
            sonido.PlayOneShot(sonElectrico2, 0.7F);
            sonido.PlayOneShot(sonCaeCable, 0.7F);
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has estado expuesto a: \n Posible caída de cable";
        }
        if (GlobalVariables.StateUI == 8)
        {
            sonido.clip = sonResbala;
            sonido.Play();
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n te has resbalado!";
        }
        if (GlobalVariables.StateUI == 9)
        {
            Canvas.SetActive(true);
            Letrero.text = "Cuidado!! \n has tenido una \n caída a mismo nivel";
            sonido.clip = sonCaerse;
            sonido.Play();
        }
    }
}
