using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRUIController : MonoBehaviour
{
    public Slider yProspect;
    public GameObject Mycamera;
    private Transform mycamera;
    public GameObject visitor;
    private Rigidbody rig;
    private const float height = 250f;
    // Start is called before the first frame update
    void Start()
    {
        visitor.transform.position = new Vector3(246.7f, 1.12f, 59.0f);
        mycamera = Mycamera.GetComponent<Transform>();
        rig = visitor.GetComponent<Rigidbody>();
        yProspect.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("MessageBox"))
        {
            //当前界面中有消息框，则绑定按钮响应函数
            if (GameObject.Find("MessageBox_Wall(Clone)"))
            {
                //城墙消息框
                GameObject.Find("Yes").GetComponent<Button>().onClick.AddListener(GoWall);
                GameObject.Find("No").GetComponent<Button>().onClick.AddListener(DontGo);
            }
            else if (GameObject.Find("MessageBox_Toll(Clone)"))
            {
                //钟楼消息框
                GameObject.Find("First").GetComponent<Button>().onClick.AddListener(GoTollFirst);
                GameObject.Find("Sec").GetComponent<Button>().onClick.AddListener(GoTollSec);
                GameObject.Find("No").GetComponent<Button>().onClick.AddListener(DontGo);
            }
            else if (GameObject.Find("MessageBox_Drum(Clone)"))
            {
                //鼓楼消息框
                GameObject.Find("First").GetComponent<Button>().onClick.AddListener(GoDrumFirst);
                GameObject.Find("Sec").GetComponent<Button>().onClick.AddListener(GoDrumSec);
                GameObject.Find("No").GetComponent<Button>().onClick.AddListener(DontGo);
            }
            else if (GameObject.Find("MessageBox_Grave(Clone)"))
            {
                //城墙消息框
                GameObject.Find("Yes").GetComponent<Button>().onClick.AddListener(GoGrave);
                GameObject.Find("No").GetComponent<Button>().onClick.AddListener(DontGo);
            }
        }

        if (visitor.transform.position.y < 10.0f)
        {
            //重置摄像机高度
            Mycamera.transform.localPosition = new Vector3(0, 2.41f, 0);
        }
    }
    /// <summary>
    /// 纵向旋转摄像机角度
    /// </summary>
    public void YProspect()
    {
        mycamera.localEulerAngles = new Vector3(-60 * yProspect.value, 0, 0);
    }

    public void Jump()
    {
        Debug.Log("jump");
        rig.AddForce(Vector3.up * height);
    }

    public void EndVisit()
    {
        //跳转场景
        SceneManager.LoadScene("Mainscene");
    }

    public void DontGo()
    {
        Destroy(GameObject.FindGameObjectWithTag("MessageBox"));
    }

    public void GoWall()
    {
        MountStruction(0);
        DontGo();
    }
    public void GoTollFirst()
    {
        MountStruction(1);
        DontGo();
    }
    public void GoTollSec()
    {
        MountStruction(2);
        DontGo();
    }
    public void GoDrumFirst()
    {
        MountStruction(3);
        DontGo();
    }
    public void GoDrumSec()
    {
        MountStruction(4);
        DontGo();
    }
    public void GoGrave()
    {
        MountStruction(5);
        DontGo();
    }
    private void MountStruction(int message)
    {     
        switch (message)
        {
            case 0:
                //上城墙
                visitor.transform.position = new Vector3(189.3f, 13.82f, 188.4f);
                Mycamera.transform.localPosition = new Vector3(0, 1.0f, 0);
                break;
            case 1:
                //钟楼一楼
                visitor.transform.position = new Vector3(192.53f, 6.29f, 246.18f);
                break;
            case 2:
                //钟楼二楼
                visitor.transform.position = new Vector3(196.71f, 12.32f, 250.03f);
                Mycamera.transform.localPosition = new Vector3(0, 0.4f, 0);
                break;
            case 3:
                //鼓楼一楼
                visitor.transform.position = new Vector3(135.32f, 8.86f, 267.28f);
                break;
            case 4:
                //鼓楼二楼
                visitor.transform.position = new Vector3(138.51f, 13.77f, 273.25f);
                Mycamera.transform.localPosition = new Vector3(0, 0.5f, 0);
                break;
            case 5:
                //茂陵
                visitor.transform.position = new Vector3(249.84f, 40.58f, 874.41f);
                break;
            default:
                break;
        }
    }
}
