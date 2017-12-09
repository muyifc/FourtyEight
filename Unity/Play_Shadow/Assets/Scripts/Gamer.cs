using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏整体流程分发
public class Gamer : MonoBehaviour
{

    // Use this for initialization
    public static Gamer Instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

        this.StartGame();
    }


    //	开始游戏的处理
    public void StartGame()
    {
        Debug.Log(Data.Instance.storty_1);
        LayerManager<HomeLayer>.Open("HomeLayer");
        Gamer.Instance.StartLevel(1);

    }

    //片头
    public void PlayStory()
    {

    }
    //控制关卡流程
    public void StartLevel(int levelID)
    {
        //生成场景
        SceneManager.Instance.SwitchLevel(levelID);
        //

    }




}
