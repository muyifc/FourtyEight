using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneManager : MonoBehaviour
{
    public GameObject CommonLight;
    public GameObject FireLight;

    public GameObject CommonBG;


    private List<iTweenPath> curLevelPathList = new List<iTweenPath>();//路径
    private GameObject curSceneLayer;//地图背景
    private GameObject roler;//角色
    private List<GameObject> curCollectionList = new List<GameObject>();//拾取物


    private int curLevelID;
    private int curPassLevelPart;//当前处于关卡第几段
    private Vector3 curRightPos;//正确摆放位置
    private float curRightEuler;//正确摆放角度
    private string curItemEntityName;//需要摆放的物品

    public static SceneManager Instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        CommonBG.SetActive(true);
    }

    //关卡生成
    public void SwitchLevel(int levelID)
    {
        curLevelID = levelID;
        int levelPartCount = Data.Instance.partCountPerLevel[curLevelID - 1];//读表
        curPassLevelPart = 0;
        this.SwitchLevelPart();

        //销毁上个场景
        if (curSceneLayer != null)
            GameObject.Destroy(curSceneLayer);
        for (int idx = 0; idx < curLevelPathList.Count; idx++)
            GameObject.Destroy(curLevelPathList[idx].gameObject);
        if (this.roler != null)
            GameObject.Destroy(roler);
        for (int idx = 0; idx < curCollectionList.Count; idx++)
            GameObject.Destroy(curCollectionList[idx].gameObject);


        //加载场景（图层）
        curSceneLayer = Instantiate(Resources.Load("Scene_" + curLevelID)) as GameObject;
        curSceneLayer.transform.SetParent(this.transform, false);
        // sceneLayer.transform.localPosition = Vector3.zero;
        curSceneLayer.transform.localScale = Vector3.one;
        // sceneLayer.transform.localEulerAngles = Vector3.zero;

        //加载该场景的AI路径（itweenpath）
        curLevelPathList.Clear();
        for (int levelPart = 1; levelPart <= levelPartCount; levelPart++)
        {
            GameObject pathObj = Instantiate(Resources.Load("Path_" + curLevelID + "_" + levelPart)) as GameObject;
            curLevelPathList.Add(pathObj.GetComponent<iTweenPath>());
        }

        //加载主角
        roler = Instantiate(Resources.Load("Roler")) as GameObject;
        roler.transform.SetParent(this.transform, false);
        roler.transform.localPosition = Data.Instance.rolerBornPos_1;//位置读表

        //加载拾取物
        int collectionNum = 2;//读表




    }

    //下一段路
    public void SwitchLevelPart()
    {
        curPassLevelPart++;
        //通关
        if (curPassLevelPart > Data.Instance.partCountPerLevel[this.curLevelID - 1])
        {
            Debug.Log("通关");
            return;
        }
        if (this.curLevelID == 1)
        {
            this.curRightPos = Data.Instance.matchPosArray_1[curPassLevelPart - 1];
            this.curRightEuler = Data.Instance.matchEulerArray_1[curPassLevelPart - 1];
            this.curItemEntityName = Data.Instance.matchItemNameArray_1[curPassLevelPart - 1];
        }

    }



    //检测摆放是否正确
    public bool CheckMatching(Transform shadowTran)
    {
        bool isMatch = false;
        //匹配正确
        float dis = Vector3.Distance(shadowTran.localPosition, this.curRightPos);
        float angle = Mathf.Abs(shadowTran.localEulerAngles.z - this.curRightEuler);
        if (dis < 30 && angle < 20 && shadowTran.name.Equals(this.curItemEntityName))
            isMatch = true;
        Debug.Log(dis + "//" + angle);
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
            RolerController.Instance.AutoMove(this.curLevelPathList[curPassLevelPart - 1]);
        }

        return isMatch;
    }
}
