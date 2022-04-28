using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContaMovimiento : MonoBehaviour
{

    private float conta = 0f;
    private Text myText;
    //private float tiempoA = 0f;

    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoR = 0f;
    private int escalaT = 0;
    private bool agarre = true;
    private int sec = 0;
    private int candado = 0;




    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();

    }


    public void SumarMovimientosControl()
    {
        conta = conta + 0.25f;
    }

    public void IniciaAgarre()
    {
            agarre = true;
            escalaT = 4;
               
    }

    public void Reinicio()
    {
        conta = 0; 
    }


    public void FinAgarre()
    {
        if (agarre)
        {
            agarre = false;
            escalaT = 0;
        
            tiempoR = 0;
            candado = 0;
        }
    }


    // Update is called once per frame

    void Update()
    {
              
        
        // La siguiente variable representa el tiempo de cada frame considerando la escala de tiempo
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaT;
        //Acumulando el tiempo transcurrido para luego mostrarlo en el reloj
        tiempoR += tiempoDelFrameConTimeScale;
        sec = (int)tiempoR % 60;

        if (sec == 1  && candado == 0)
        {
            conta = conta  + 1;
            candado = 1;
        }

        myText.text = conta.ToString("00");
    }
}