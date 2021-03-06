using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public bool inTrigger;
    void OnTriggerEnter(Collider other){
        inTrigger = true;
    }
        void OnTriggerExit(Collider other){
        inTrigger = false;
    }

    void OnGUI()
    {
        if(inTrigger)
        {
            GUI.Box(new Rect(0,60,200,25), "you picked up key");
        }
    }

    void Update()
    {
        if(inTrigger)
        {
            DoorScript.doorKey = true;
        }
    }
}
