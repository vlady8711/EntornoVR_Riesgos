using Bhaptics.Tact.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticPlay : MonoBehaviour
{
    public PositionTag PositionTag = PositionTag.Body;

    public void Play()
    {
        GetComponent<HapticSource>().Play();
    }

    void Update()
    {
     

    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Crash");
        GetComponent<HapticSource>().Play();
 
    }

    


}