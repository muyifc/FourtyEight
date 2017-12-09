using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneManager : MonoBehaviour
{
    public GameObject CommonLight;
    public GameObject FireLight;


    private List<iTweenPath> curLevelPathList = new List<iTweenPath>();//路径
    private GameObject curSceneLayer;//地图背景
    private GameObject roler;//角色
    private List<GameObject> curCollectionList = new List<GameObject>();//拾取物


    private int curPassLevelPart;//当前处于关卡第几段
    private Vector3 curRightPos;//正确摆放位置
    private Vector3 curRightEuler;//正确摆放角度
    private GameObject curItemEntityName;//需要摆放的物品

    public static SceneManager Instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    //关卡生成
    public void SwitchLevel(int levelID)
    {
        int levelPartCount = 1;//读表
        curPassLevelPart = 1;
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
        curSceneLayer = Instantiate(Resources.Load("Scene_" + levelID)) as GameObject;
        curSceneLayer.transform.SetParent(this.transform, false);
        // sceneLayer.transform.localPosition = Vector3.zero;
        curSceneLayer.transform.localScale = Vector3.one * 10;
        // sceneLayer.transform.localEulerAngles = Vector3.zero;

        //加载该场景的AI路径（itweenpath）
        curLevelPathList.Clear();
        for (int levelPart = 1; levelPart <= levelPartCount; levelPart++)
        {
            GameObject pathObj = Instantiate(Resources.Load("Path_" + levelID + "_" + levelPart)) as GameObject;
            curLevelPathList.Add(pathObj.GetComponent<iTweenPath>());
        }

        //加载主角
        roler = Instantiate(Resources.Load("Roler")) as GameObject;
        roler.transform.SetParent(this.transform, false);
        // roler.transform.localPosition = Vector3.zero;//位置读表

        //加载拾取物
        int collectionNum = 2;//读表




    }



    //检测摆放是否正确
    public void CheckMatching(Transform tran)
    {
        bool match = false;
        //匹配正确
        if (match)
        {
            curPassLevelPart++;

            //将物品强行拉扯到设定位置
            // tran.position

            //主角寻路
            RolerController.Instance.AutoMove(this.curLevelPathList[curPassLevelPart - 1]);
        }
    }
}
