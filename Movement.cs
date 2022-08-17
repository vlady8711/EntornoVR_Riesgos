using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class GlobalVariables
{
    public static int moveR;
    public static int moveL;
    public static int active;
    public static int Hand_State;
    public static int StateUI;
    public static float posx;
    public static float posy;
    public static float posz;

}


public class Movement : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;
    public int speedWP = 75;
    public int forceConst = 20;
    private bool canJump;
    private Rigidbody rb;
    private GUIStyle style;

    // Start is called before the first frame update  
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Messages in display
        style = new GUIStyle();
        style.normal.textColor = Color.black;
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            canJump = false;
            rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
        GlobalVariables.posx = this.GetComponent<Transform>().position.x;
        GlobalVariables.posy = this.GetComponent<Transform>().position.y;
        GlobalVariables.posz = this.GetComponent<Transform>().position.z;
    }

    // Update is called once per frame  
    void Update()
    {
        


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.3f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.3f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.0f, 0f, -0.3f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0.0f, 0f, 0.3f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(0, 0.5f, 0, Space.Self);
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(0, -0.5f, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.H))
        {
            transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.L))
        {
            canJump = true;
        }

        ///MOVIMIENTOS CON LOS GUANTES
        // 1. Acción movimiento a la derecha
        if (GlobalVariables.moveL == 1 && GlobalVariables.active == 1)
        {
            transform.Translate(0.1f, 0f, 0f);
            GlobalVariables.Hand_State = 1;
        }

        // 2. Acción movimiento a la izquierda
        else if (GlobalVariables.moveL == 4 && GlobalVariables.active == 1)
        {
            transform.Translate(-0.1f, 0f, 0f);
            GlobalVariables.Hand_State = 2;
        }

        // 3. Acción movimiento adelante
        else if (GlobalVariables.moveR == 1 && GlobalVariables.active == 1)
        {
            transform.Translate(0f, 0f, 0.1f);
            GlobalVariables.Hand_State = 3;
        }

        // 4. Acción movimiento atrás
        else if (GlobalVariables.moveR == 4 && GlobalVariables.active == 1)
        {
            transform.Translate(0f, 0f, -0.1f);
            GlobalVariables.Hand_State = 4;
        }

        // 5. Acción movimiento siguiente way point
        else if (GlobalVariables.moveL == 2 && GlobalVariables.active == 1)
        {
            this.transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
            this.transform.Translate(Vector3.forward * speedWP * Time.deltaTime);
            StartCoroutine(Delay_Function());
            GlobalVariables.Hand_State = 5;
        }

        // 6. Acción movimiento rotación
        else if(GlobalVariables.moveR == 2 && GlobalVariables.active == 1 && GlobalVariables.active == 1)
        {
                this.transform.Rotate(0, 0.2f, 0, Space.Self);
        }

        //7. Saltar
        else if (GlobalVariables.moveR == 1 && GlobalVariables.moveL == 1)
        {
            speed = 0;
            canJump = true;
            GlobalVariables.Hand_State = 7;
        }

        //Desactivar movimientos con las manos
       if (GlobalVariables.moveR == 3)
        {
            GlobalVariables.active = 0;
            GlobalVariables.Hand_State = 8;
        }
        
        //Activar Movimientos con las manos
        if (GlobalVariables.moveL == 3)
        {
            GlobalVariables.active = 1;
            GlobalVariables.Hand_State = 9;
        }

        //Reiniciar movimientos
        else if (GlobalVariables.moveR == 0 && GlobalVariables.moveL == 0)
        {
            speed = 0;
            canJump = false;
        }
    }


    


    IEnumerator Delay_Function()
    {
        yield return new WaitForSeconds(3);
    }

    void OnGUI()
    {
        switch (GlobalVariables.Hand_State)
        {
            case 1:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Moving right", style);
                break;
            case 2:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Moving left", style);
                break;
            case 3:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Moving ahead", style);
                break;
            case 4:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Moving back", style);
                break;
            case 5:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Next Checkpoint", style);
                break;
            case 6:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Rotating", style);
                break;
            case 7:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Jumping", style);
                break;
            case 8:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Movement off", style);
                break;
            case 9:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Movement on", style);
                break;
            default:
                GUI.Label(new Rect(0, 70, 200f, 200f), "Waiting ...", style);
                break;
        }
    }

}