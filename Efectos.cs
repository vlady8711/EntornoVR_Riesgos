using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Efectos : MonoBehaviour
{
    public GameObject caja;
    public GameObject restos;
    public GameObject pos_restos;
    public GameObject explota;
    public GameObject escombros;
    public GameObject pos_explota;
    public GameObject particula;
    public GameObject pos_particula;
    public GameObject fuego;
    public GameObject pos_fuego;
    public GameObject humo;
    public GameObject pos_humo;
    public GameObject gas;
    public GameObject pos_gas;
    public GameObject electricidad;
    public GameObject pos_electricidad;
    public GameObject wire;
    public GameObject pos_wire;
    public GameObject pos_fall;
    public GameObject pos_slip;
    public GameObject player;
    public Transform target;

    public static int StateUI;

    private Boolean State_Fire = true;
    private Boolean State_Electric  = true;
    private Boolean State_Smoke = true;
    private Boolean State_Wire = true;
    private Boolean State_Gas = true; 
    private Boolean State_Particle = true;
    private Boolean State_Broke = true;
    private Boolean State_Exploit = true;
    private Boolean State_Fall = true;
    private Boolean State_Slip = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (State_Broke && (Input.GetKeyDown(KeyCode.Z) || (Mathf.Abs(GlobalVariables.posx - caja.GetComponent<Transform>().position.x) < 2f && Mathf.Abs(GlobalVariables.posz - caja.GetComponent<Transform>().position.z) < 2f)))
        {
            Instantiate(restos, pos_restos.transform.position, Quaternion.identity);
            Destroy(caja);
            GlobalVariables.StateUI = 1;
            //StartCoroutine(WaitTime());
            State_Broke = false;
        }
        if (State_Exploit && (Input.GetKeyDown(KeyCode.J) || (Mathf.Abs(GlobalVariables.posx - explota.GetComponent<Transform>().position.x) < 1f && Mathf.Abs(GlobalVariables.posz - explota.GetComponent<Transform>().position.z) < 1f)))
        {
            Instantiate(escombros, pos_explota.transform.position, Quaternion.identity);
            Destroy(explota);
            GlobalVariables.StateUI = 1;
            StartCoroutine(WaitTime_2());
            State_Exploit = false;
        }
        if (State_Particle && (Input.GetKeyDown(KeyCode.X) || (Mathf.Abs(GlobalVariables.posx - pos_particula.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_particula.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(particula, pos_particula.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 2;
            StartCoroutine(WaitTime());
            State_Particle = false;

        }
        if (State_Fire && (Input.GetKeyDown(KeyCode.C) || (Mathf.Abs(GlobalVariables.posx - pos_fuego.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_fuego.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(fuego, pos_fuego.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 3;
            StartCoroutine(WaitTime_2());
            State_Fire = false;
        }
        if (State_Smoke && (Input.GetKeyDown(KeyCode.V) || (Mathf.Abs(GlobalVariables.posx - pos_humo.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_humo.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(humo, pos_humo.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 4;
            StartCoroutine(WaitTime());
            State_Smoke = false;
        }
        if (State_Gas && (Input.GetKeyDown(KeyCode.B) || (Mathf.Abs(GlobalVariables.posx - pos_gas.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_gas.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(gas, pos_gas.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 5;
            StartCoroutine(WaitTime());
            State_Gas = false;
        }
        if (State_Electric && (Input.GetKeyDown(KeyCode.N) || (Mathf.Abs(GlobalVariables.posx - pos_electricidad.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_electricidad.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(electricidad, pos_electricidad.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 6;
            StartCoroutine(WaitTime());
            State_Electric = false;
        }
        if (State_Wire && (Input.GetKeyDown(KeyCode.M) || (Mathf.Abs(GlobalVariables.posx - pos_wire.GetComponent<Transform>().position.x) < 3f && Mathf.Abs(GlobalVariables.posz - pos_wire.GetComponent<Transform>().position.z) < 3f)))
        {
            Instantiate(wire, pos_wire.transform.position, Quaternion.identity);
            GlobalVariables.StateUI = 7;
            StartCoroutine(WaitTime());
            State_Wire = false;
        }
        if (State_Slip && (Input.GetKey(KeyCode.P) || (Mathf.Abs(GlobalVariables.posx - pos_slip.GetComponent<Transform>().position.x) < 1f && Mathf.Abs(GlobalVariables.posz - pos_slip.GetComponent<Transform>().position.z) < 1f)))//Resbalarse
        {

            player.transform.LookAt(new Vector3(target.position.x, target.position.y, target.position.z));
            player.transform.Translate(Vector3.forward * 15f * Time.deltaTime);
            player.transform.Rotate(0, 60f, 0, Space.Self);
            GlobalVariables.StateUI = 8;
            StartCoroutine(WaitTime());
            State_Slip = false;

        }
        if (State_Fall && (Input.GetKey(KeyCode.O) || (Mathf.Abs(GlobalVariables.posx - pos_fall.GetComponent<Transform>().position.x) < 1f && Mathf.Abs(GlobalVariables.posz - pos_fall.GetComponent<Transform>().position.z) < 1f)))//Caerse
        {
            player.transform.Rotate(75f, 0, 0, Space.Self);
            GlobalVariables.StateUI = 9;
            StartCoroutine(WaitTime());
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator WaitTime()
    {
         //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        GlobalVariables.StateUI = 0;
    }

    IEnumerator WaitTime_2()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);
        
    }

}
       