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

        this.PlayStory();
        //this.StartGame();
    }
    void Update()
    {
        Timer.Update();
    }

    //	开始游戏的处理
    public void StartGame()
    {
        // Timer timer1 = new Timer(3, () => { Debug.Log("alwaysDo"); }, () => { Debug.Log("stopTimer1"); }, true);//每帧执行，到点停止
        // Timer timer2 = new Timer(5, () => { Debug.Log("noAlways"); }, () => { Debug.Log("stopTimer2"); }, false);//到点执行

        Debug.Log(Data.Instance.storty_1);
        // LayerManager<HomeLayer>.Open("HomeLayer");
        // HomeLayer.Open("HomeLayer");
        Gamer.Instance.StartLevel(1);

    }

    //片头
    public void PlayStory()
    {
        LayerManager<HomeLayer>.Open("PlotPanel");
    }
    //控制关卡流程
    public void StartLevel(int levelID)
    {
        if (Data.Instance.levelCount < levelID)
        {
            return;
        }
        //生成场景
        SceneManager.Instance.SwitchLevel(levelID);
        LevelLayer.Open("LevelLayer");
        //

    }




}
