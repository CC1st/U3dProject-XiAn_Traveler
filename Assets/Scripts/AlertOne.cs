using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertOne : MonoBehaviour
{
    private int flag = 0;
    private GameObject messageBox;
    public GameObject messageBoxPerfab;
    void OnTriggerStay(Collider other)
    {
        if (flag==0 && other.tag == "Player")
        {
            flag = 1;
            GameObject canve = GameObject.Find("EasyTouchControlsCanvas");
            messageBox = Instantiate(messageBoxPerfab,canve.transform.position,Quaternion.identity);
            messageBox.transform.SetParent(canve.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (flag==1)
        {
            flag = 0;
            if (GameObject.FindGameObjectWithTag("MessageBox")) 
            {
                Destroy(messageBox);
            }          
        }
    }
}
