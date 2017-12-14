using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneManager : MonoBehaviour
{
    public AudioSource mAudio;

    public GameObject CommonLight;
    public GameObject FireLight;

    public GameObject CommonBG;


    public List<iTweenPath> curLevelPathList = new List<iTweenPath>();//路径
    public GameObject curSceneLayer;//地图背景
    private GameObject roler;//角色
    private List<GameObject> curCollectionList = new List<GameObject>();//拾取物


    public int curLevelID;
    private int lastLevelID = -1;

    public int curPassLevelPart { get; private set; }//当前处于关卡第几段
    private Vector3 curRightPos;//正确摆放位置
    public float curRightEuler;//正确摆放角度
    private string curItemEntityName;//需要摆放的物品

    public static SceneManager Instance;

    void Awake()
    {
        float height = Screen.height;
        float width = Screen.width;
        Data.Instance.Ratio = ((width / height) / (16.0f / 9.0f));
        transform.localScale = Vector3.one * Data.Instance.Ratio;

        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        CommonBG.SetActive(false);
    }



    public void Destroy()
    {
        CommonBG.SetActive(false);
        this.FireLight.gameObject.SetActive(true);

        //销毁上个场景
        if (curSceneLayer != null)
            GameObject.Destroy(curSceneLayer);
        if (this.roler != null)
            GameObject.Destroy(roler);
        for (int idx = curCollectionList.Count - 1; idx >= 0; idx--)
            GameObject.Destroy(curCollectionList[idx].gameObject);

        for (int idx = curLevelPathList.Count - 1; idx >= 0; idx--)
            GameObject.Destroy(curLevelPathList[idx].gameObject);
        curLevelPathList.Clear();

    }
    //关卡生成
    public void SwitchLevel(int levelID)
    {
        CommonBG.SetActive(true);
        this.FireLight.gameObject.SetActive(true);
        Debug.Log("SwitchLevel==" + levelID);
        curLevelID = levelID;
        int levelPartCount = Data.Instance.partCountPerLevel[curLevelID - 1];//读表
        curPassLevelPart = 0;
        this.SwitchLevelPart();

        //销毁上个场景
        if (curSceneLayer != null)
            GameObject.Destroy(curSceneLayer);
        if (this.roler != null)
            GameObject.Destroy(roler);
        for (int idx = curCollectionList.Count - 1; idx >= 0; idx--)
            GameObject.Destroy(curCollectionList[idx].gameObject);


        //加载场景（图层）
        curSceneLayer = Instantiate(Resources.Load("Scene_" + curLevelID)) as GameObject;
        curSceneLayer.transform.SetParent(this.transform, false);
        // sceneLayer.transform.localPosition = Vector3.zero;
        curSceneLayer.transform.localScale = Vector3.one;
        // sceneLayer.transform.localEulerAngles = Vector3.zero;

        //加载该场景的AI路径（itweenpath）
        // if (this.lastLevelID != this.curLevelID)
        // {
        for (int idx = curLevelPathList.Count - 1; idx >= 0; idx--)
            // GameObject.Destroy(curLevelPathList[idx].gameObject);
            ResourcePool.Instance.DeSpawn(curLevelPathList[idx].gameObject.name, curLevelPathList[idx].gameObject);
        curLevelPathList.Clear();
        for (int levelPart = 1; levelPart <= levelPartCount; levelPart++)
        {
            Debug.Log(curLevelPathList.Count + "//Path_" + curLevelID + "_" + levelPart);
            GameObject pathObj = ResourcePool.Instance.Spawn("Path_" + curLevelID + "_" + levelPart);// Instantiate(Resources.Load("Path_" + curLevelID + "_" + levelPart)) as GameObject;
            pathObj.transform.SetParent(transform);
            pathObj.transform.localPosition = new Vector3(pathObj.transform.localPosition.x, pathObj.transform.localPosition.y, 0);
            curLevelPathList.Add(pathObj.GetComponent<iTweenPath>());
        }
        // }
        // this.lastLevelID = this.curLevelID;

        //加载主角
        roler = Instantiate(Resources.Load("Roler")) as GameObject;
        roler.transform.SetParent(curSceneLayer.transform, false);
        roler.transform.localPosition = Data.Instance.rolerBornPosArray[levelID - 1];//位置读表       
    }

    //下一段路
    public void SwitchLevelPart()
    {
        curPassLevelPart++;
        Debug.Log("下一段路：" + curPassLevelPart);
        //通关
        if (curPassLevelPart > Data.Instance.partCountPerLevel[this.curLevelID - 1])
        {
            Debug.Log("通关");
            Gamer.Instance.StartLevel((curLevelID + 1));
            return;
        }
        if (this.curLevelID == 1)
        {
            this.curRightPos = Data.Instance.matchPosArray_1[curPassLevelPart - 1];
            this.curRightEuler = Data.Instance.matchEulerArray_1[curPassLevelPart - 1];
            this.curItemEntityName = Data.Instance.matchItemNameArray_1[curPassLevelPart - 1];
        }
        else if (this.curLevelID == 2)
        {
            this.curRightPos = Data.Instance.matchPosArray_2[curPassLevelPart - 1];
            this.curRightEuler = Data.Instance.matchEulerArray_2[curPassLevelPart - 1];
            this.curItemEntityName = Data.Instance.matchItemNameArray_2[curPassLevelPart - 1];
        }
        else if (this.curLevelID == 3)
        {
            this.curRightPos = Data.Instance.matchPosArray_3[curPassLevelPart - 1];
            this.curRightEuler = Data.Instance.matchEulerArray_3[curPassLevelPart - 1];
            this.curItemEntityName = Data.Instance.matchItemNameArray_3[curPassLevelPart - 1];
            if (curPassLevelPart == 5)
            {
                iTween.MoveTo(SceneManager.Instance.curSceneLayer, iTween.Hash("position",
                 new Vector3(-855, 0, 0), "islocal", true, "time", 3F, "easetype", iTween.EaseType.linear));
            }
        }

    }



    //检测摆放是否正确
    public bool CheckMatching(Transform shadowTran)
    {
        bool isMatch = false;
        //匹配正确
        float dis = Vector3.Distance(shadowTran.localPosition, this.curRightPos);
        float angle = (Mathf.Abs(shadowTran.localEulerAngles.z - this.curRightEuler) + 360) % 360;
        if (dis < 60 && angle < 20 && shadowTran.name.Equals(this.curItemEntityName))
            isMatch = true;
        Debug.Log("checkMatch:" + shadowTran.name + "//" + dis + "//" + angle);
        return isMatch;
    }

    public bool MatchFun(Transform shadowTran)
    {
        bool isMatch = this.CheckMatching(shadowTran);
        if (isMatch)
        {
            //将物品强行拉扯到设定位置
            shadowTran.localPosition = this.curRightPos;
            shadowTran.localEulerAngles = new Vector3(shadowTran.localEulerAngles.x, shadowTran.localEulerAngles.y, this.curRightEuler);
            Debug.Log(this.curLevelPathList.Count + "//" + curPassLevelPart);
            //主角寻路
            if (mAudio == null)
                mAudio = transform.GetComponent<AudioSource>();
            this.mAudio.Play();
            RolerController.Instance.AutoMove(this.curLevelPathList[curPassLevelPart - 1]);
        }

        return isMatch;
    }
}
