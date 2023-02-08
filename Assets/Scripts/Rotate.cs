using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    const float xSpeed = 150.0f;
    int rotateValue;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if(Input.touchCount==1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    rotateValue = GameObject.Find("RotateSelect").GetComponent<Dropdown>().value;
                    if (rotateValue == 0)
                    {
                        //旋转X轴
                        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * -xSpeed * Time.deltaTime, Space.Self);
                    }
                    else if (rotateValue == 1)
                    {
                        //旋转Y轴
                        transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * -xSpeed * Time.deltaTime, Space.Self);
                    }
                }
            }
        }
	}
}
