using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cronometro : MonoBehaviour {

    [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;
    [Tooltip("Escala de tiempo del reloj")]
    [Range(-10.0f,10.0f)]
    public float escalaDeTiempo = 0;

    private Text myText;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    private float escalaDeTiempoAlPausar, escalaDeTiempoInicial;
    private bool estaPausado = true;

    // Use this for initialization
	void Start () {
        escalaDeTiempoInicial = escalaDeTiempo;
        //
        myText = GetComponent<Text>();
        // Acumular tiempo
        tiempoAMostrarEnSegundos = tiempoInicial;
        //
        ActualizarReloj(tiempoInicial);

	}

    public void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        //Asegurar que el tiempo no sea negativo
        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        //Calcular minutos y segundos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        // Crear la cadena de caractéres con 2 dígitos
        //para los minutos y segundos, separados por ":"
        textoDelReloj = minutos.ToString("00") + " : " + segundos.ToString("00");

        //throw new NotImplementedException();
        myText.text = textoDelReloj; 
    }
    //[Tooltip("Pausa el juegoz")]
    public void Pausar()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            //escalaDeTiempoAlPausar = escalaDeTiempo;
            escalaDeTiempo = 0;
        }
    }

    public void Continuar()
    {
        if (estaPausado)
        {
            escalaDeTiempo = 1;
            estaPausado = false;
            //escalaDeTiempo = escalaDeTiempoAlPausar;
            //escalaDeTiempo = 1;
        }
    }

    public void Reiniciar()
    {
        estaPausado = true;
        escalaDeTiempo = 0;
        tiempoAMostrarEnSegundos = 0;
        ActualizarReloj(tiempoAMostrarEnSegundos);

    }

    
    // Update is called once per frame
    void Update () {
        if (!estaPausado)
        {
            // La siguiente variable representa el tiempo de cada frame considerando la escala de tiempo
            tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
            //Acumulando el tiempo transcurrido para luego mostrarlo en el reloj
            tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
            ActualizarReloj(tiempoAMostrarEnSegundos);
        }
    }
}
