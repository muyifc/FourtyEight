using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Singleton<Data>
{
    public string storty_1 = "很久很久以前，\n有一个部落";

    public Vector3 shadowOffset = new Vector3(100, -400, 0);
    public int levelCount = 3;
    //每关几根木柴
    // public int[] collectCountPerLevel = { 1, 2 };
    //每关几段路
    public int[] partCountPerLevel = { 2, 3, 5 };
    //精灵出生位置
    public Vector3[] rolerBornPosArray = new Vector3[] { new Vector3(-719, 260, 0), new Vector3(-674, 252, 0), new Vector3(-775, 213, 0) };



    //位置检索（保存影子位置）
    public Vector3[] matchPosArray_1 = new Vector3[] { new Vector3(-367.5f, 175.9f, 0f), new Vector3(201.7f, 39.47f, 0f) };
    public float[] matchEulerArray_1 = new float[] { 270f, 63.695f };
    public string[] matchItemNameArray_1 = new string[] { "HuaBi", "ShaoZi" };


    //第二关
    public Vector3[] matchPosArray_2 = new Vector3[] { new Vector3(-259f, -92f, 0f), new Vector3(-104f, -67f, 0f), new Vector3(385f, 33f, 0f) };
    public float[] matchEulerArray_2 = new float[] { 35f, 90f, 90f };
    public string[] matchItemNameArray_2 = new string[] { "Cao", "YaoBao", "Dao" };

    //第三关
    public Vector3[] matchPosArray_3 = new Vector3[] { new Vector3(-655, 83f, 0f), new Vector3(-188f, -21f, 0f), new Vector3(-4.29f, 218.2f, 0f), new Vector3(48f, -45f, 0f), new Vector3(1073, 91, 0f) };
    public float[] matchEulerArray_3 = new float[] { -90f, 0f, 61.423f, -55.2f, 0f };
    public string[] matchItemNameArray_3 = new string[] { "shoudiantongyingzi", "02_xinglixiangshoubing", "lunzi", "04_daozi", "JunDao" };


    //剧情
    public string PlotDesc1 = "我看不到自己，却只有在篝火的映照下才能感受到自己微弱的存在。";
    public string PlotDesc2 = "我还活着吗？或许吧。";
    public string PlotDesc3 = "而我唯一可以确认的是，一旦篝火熄灭，那点微弱的存在也将消失。";

    public string PlotIcon1 = "Image/plot1";
    public string PlotIcon2 = "Image/plot2";
    public string PlotIcon3 = "Image/plot3";

    public string PlotAudio1 = "Audio/plot1";
    public string PlotAudio2 = "Audio/plot2";
    public string PlotAudio3 = "Audio/plot3";
}
