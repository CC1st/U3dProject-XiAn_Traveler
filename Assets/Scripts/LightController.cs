using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public Light currentLight;
    public Slider lightSlider;
    public Toggle enShowTerrain;
    public Dropdown rotateSelect;
    public GameObject recommandPanel;
    public Text panelShowBtn;
    private float panelMoveSpeed = 0.8f;
    private bool panelshow = false;
    private GameObject combine;
    private bool openWeb = false;
    private static LightController _instance;

    public static LightController instacne
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {     
        lightSlider.value = 0.5f;
        recommandPanel.transform.localPosition = new Vector3(-300f, 221.3f, 0);
    }

    void Update()
    {
        //绑定按钮侦听函数
        if (GameObject.FindGameObjectWithTag("Link"))
        {
            if (GameObject.Find("TollFloorLink(Clone)"))
            {
                GameObject.Find("TollFloorLink(Clone)").GetComponent<Button>().onClick.AddListener(TollFloorLink);
            }
            if (GameObject.Find("DrumFloorLink(Clone)"))
            {
                GameObject.Find("DrumFloorLink(Clone)").GetComponent<Button>().onClick.AddListener(DrumFloorLink);
            }
            if (GameObject.Find("HuiPeopleStreeLink(Clone)"))
            {
                GameObject.Find("HuiPeopleStreeLink(Clone)").GetComponent<Button>().onClick.AddListener(HuiPeopleStreeLink);
            }
            if (GameObject.Find("ShanXiMusementLink(Clone)"))
            {
                GameObject.Find("ShanXiMusementLink(Clone)").GetComponent<Button>().onClick.AddListener(ShanXiMusementLink);
            }
            if (GameObject.Find("FiveGraveLink(Clone)"))
            {
                GameObject.Find("FiveGraveLink(Clone)").GetComponent<Button>().onClick.AddListener(FiveGraveLink);
            }
            if (GameObject.Find("GraveMaoMusement(Clone)"))
            {
                GameObject.Find("GraveMaoMusement(Clone)").GetComponent<Button>().onClick.AddListener(GraveMaoMusement);
            }
            if (GameObject.Find("TangPalaceLink(Clone)"))
            {
                GameObject.Find("TangPalaceLink(Clone)").GetComponent<Button>().onClick.AddListener(TangPalaceLink);
            }
        }
    }

    #region 改变当前模型的光照强度
    /// <summary>
    /// 改变当前模型的光照强度
    /// </summary>
    public void LightChange()
    { 
            currentLight.intensity = lightSlider.value;
    }
    #endregion

    #region 是否显示地形
    /// <summary>
    /// 是否显示地形
    /// </summary>
    public void EnShowTerrain()
    {
            combine = GameObject.FindGameObjectWithTag("Combine");
            GameObject terrain = combine.transform.Find("Terrain").gameObject;

            if (terrain)
            {
                if (!enShowTerrain.isOn)
                {
                    //取消显示地形
                    Debug.Log(terrain.name);
                    terrain.SetActive(false);
                }
                else
                {
                    //勾选显示地形               
                    Debug.Log(terrain.name + "true");
                    terrain.SetActive(true);
                }
            }
    }
    #endregion

    /// <summary>
    /// 选择手势交互的模型旋转轴
    /// </summary>
    /// <param name="value">下拉框对应的选项参数</param>
    public void RotateSelect()
    {
        switch (rotateSelect.value)
        {
            case 0:
                Debug.Log(rotateSelect.value);
                print("旋转X轴");
                break;
            case 1:
                Debug.Log(rotateSelect.value);
                print("旋转Y轴");
                break;
        }
    }
    public void IntoVisit()
    {
        SceneManager.LoadScene("VRscene");
    }

    #region 推荐面板响应函数
    public void RecommandShow()
    {
        //手指点击则下移，再次点击则回缩
        if (panelshow)
        {//收起推荐面板
            while (recommandPanel.transform.localPosition.y <221.3f)
            {
                recommandPanel.transform.Translate(Vector3.up * panelMoveSpeed * Time.deltaTime);
            }
            panelshow = !panelshow;
            panelShowBtn.text = "景点推荐";
        }
        else
        {//展开推荐面板
            while (recommandPanel.transform.localPosition.y > 114.4f)
            {
                recommandPanel.transform.Translate(Vector3.up * -panelMoveSpeed * Time.deltaTime);
            }
            panelshow = !panelshow;
            panelShowBtn.text = "收起";
        }
    }

    private void TollFloorLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("http://piao.ctrip.com/ticket/dest/t52702.html?allianceid=866656&sid=1435004");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void DrumFloorLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("https://piao.ctrip.com/ticket/dest/t1410344.html?allianceid=866656&sid=1435004");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void HuiPeopleStreeLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("https://baike.baidu.com/item/回民街/9853770?fromtitle=%E8%A5%BF%E5%AE%89%E5%9B%9E%E6%B0%91%E8%A1%97&fromid=2125969&fr=aladdin");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void TangPalaceLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("http://www.tangparadise.cn/");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void ShanXiMusementLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("http://www.sxhm.com/");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void FiveGraveLink()
    {
        if (!openWeb)
        {
            Application.OpenURL("http://www.mafengwo.cn/i/1254810.html");
            openWeb = !openWeb;
        }
        QuitGame();
    }
    private void GraveMaoMusement()
    {
        if (!openWeb)
        {
            Application.OpenURL("http://www.maoling.com/");
            openWeb = !openWeb;
        }
        QuitGame();
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
    #endregion
}
