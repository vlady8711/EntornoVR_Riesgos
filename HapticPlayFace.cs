using Bhaptics.Tact.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticPlayFace : MonoBehaviour
{
    public PositionTag PositionTag = PositionTag.Head;
    public HapticClip clip1;
    public HapticClip clip2;
    public HapticClip clip3;
    public HapticClip clip4;
    public HapticClip clip5;
    public HapticClip clip6;
    public HapticClip clip7;
    public HapticClip clip8;
    public HapticClip clip9;


    void Start()
    {
        GetComponent<HapticSource>().clip = clip1;
    }

    public void Play()
    {
        //GetComponent<HapticSource>().Play();
    }

    void Update()
    {
        switch (GlobalVariables.StateUI)
        {
            case 1:
                GetComponent<HapticSource>().clip = clip1; //fragmentación objetos
                GetComponent<HapticSource>().Play();
                break;
            case 2:
                GetComponent<HapticSource>().clip = clip2; //material particulado
                GetComponent<HapticSource>().Play();
                break;
            case 3:
                GetComponent<HapticSource>().clip = clip3; //fuego
                GetComponent<HapticSource>().Play();

                break;
            case 4:
                GetComponent<HapticSource>().clip = clip4; //humo
                GetComponent<HapticSource>().Play();

                break;
            case 5:
                GetComponent<HapticSource>().clip = clip5; //gas
                GetComponent<HapticSource>().Play();

                break;
            case 6:
                GetComponent<HapticSource>().clip = clip6; //electricidad
                GetComponent<HapticSource>().Play();

                break;
            case 7:
                GetComponent<HapticSource>().clip = clip7; //caída de Cable
                GetComponent<HapticSource>().Play();

                break;
            case 8:
                GetComponent<HapticSource>().clip = clip8; //resbalarse
                GetComponent<HapticSource>().Play();

                break;
            case 9:
                GetComponent<HapticSource>().clip = clip9; //caerse
                GetComponent<HapticSource>().Play();

                break;

        }

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Crash");

        //GetComponent<HapticSource>().Play();
    }

}