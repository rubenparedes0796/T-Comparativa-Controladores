using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour {


    //public float moveSpeed;
    public float fuerzaX = 40f;
    public float fuerzaY = 50f;
    public float fuerzaZ = 50f;

    public string compa = "";

    cronometro a;
    ContaMovimiento b;

    private Rigidbody A1;
    private string ultimaT = " ";
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private float lh;
    private float lv;
    private float mag = 0; 


    //Funcion de inicio
    void Start()
    {
        A1 = GetComponent<Rigidbody>();
        A1.useGravity = true;
        a = GameObject.FindGameObjectWithTag("TagA").GetComponent<cronometro>();
        b = GameObject.FindGameObjectWithTag("TagB").GetComponent<ContaMovimiento>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("z")||Input.GetKey("joystick button 2"))
        {
            ultimaT = "z";
            mag = 1;
            A1.useGravity = false;
            print("Boton 2");
            a.Continuar();

        }
        else if (Input.GetKey("x") || Input.GetKey("joystick button 0"))
        {
            ultimaT = "x";
            mag = 1.7f;
            A1.useGravity = false;
            print("Boton 0");
        }
        else if (Input.GetKey("c") || Input.GetKey("joystick button 3"))
        {
            ultimaT = "c";
            mag = 2.7f;
            A1.useGravity = false;
            print("Boton 3");
        }
        else if (Input.GetKey("v") || Input.GetKey("joystick button 1"))
        {
            ultimaT = "v";
            mag = 5f;
            A1.useGravity = false;
            print("Boton 1");
        }
        else if (Input.GetKeyUp("z") || Input.GetKeyUp("x")|| Input.GetKeyUp("c")|| Input.GetKeyUp("v")||
            Input.GetKeyUp("joystick button 0") || Input.GetKeyUp("joystick button 1") || Input.GetKeyUp("joystick button 2") || Input.GetKeyUp("joystick button 3"))
        {
            ultimaT = "";
            A1.useGravity = true;
            mag = 1f;
            
        }

        /*else if (Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c") || Input.GetKeyDown("v") ||
            Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 3"))
        {
            a.Continuar();
        }
          */   

        else if(Input.GetKey("q") || Input.GetKey("joystick button 6"))
        {
            a.Pausar();
        }

        else if (Input.GetKey("e") || Input.GetKey("joystick button 7"))
        {
            a.Continuar();
        }
        else if (Input.GetKey("r") || Input.GetKey("joystick button 5"))
        {
            a.Reiniciar();
            b.Reinicio();
            SceneManager.LoadScene(1);

        }

        if (Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c") || Input.GetKeyDown("v") ||
           Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("joystick button 2") || Input.GetKeyDown("joystick button 3"))
        {
            b.SumarMovimientosControl();
        }
        //A1.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (ultimaT == compa)
        {
            lh = Input.GetAxis("Horizontal");
            lv = Input.GetAxis("Vertical");
            A1.AddForce(lh * fuerzaX * Time.deltaTime, mag * lv * fuerzaY * Time.deltaTime, 0);
        }
    }




}
