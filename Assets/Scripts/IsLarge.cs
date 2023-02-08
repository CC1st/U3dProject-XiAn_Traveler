using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLarge : MonoBehaviour {

    Vector2 oldPos1;
    Vector2 oldPos2;
    float scaleField=1.025f;

	void Update () {
        if (Input.touchCount == 2)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 temPos1 = Input.GetTouch(0).position;
                Vector2 temPos2 = Input.GetTouch(1).position;
                if (isEnlager(oldPos1, oldPos2, temPos1, temPos2))
                {
                    float oldScale = transform.localScale.x;
                    float newScale= oldScale * scaleField;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                else
                {
                    float oldScale = transform.localScale.x;
                    float newScale = oldScale / scaleField;
                    transform.localScale = new Vector3(newScale, newScale, newScale);
                }
                oldPos1 = temPos1;
                oldPos2 = temPos2;
            }
        }
	}

    bool isEnlager(Vector2 oP1,Vector2 oP2,Vector2 nP1,Vector2 nP2)
    {
        float length1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float length2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));

        if (length1 < length2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
