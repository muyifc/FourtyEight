using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Singleton<Data>
{
    public string storty_1 = "很久很久以前，\n有一个部落";

    public Vector3 shadowOffset = new Vector3(100, -400, 0);
    //每关几根木柴
    public int[] collectCountPerLevel = { 1, 2, 3 };
    //每关几段路
    public int[] partCountPerLevel = { 2, 2, 3 };
    //精灵出生位置
    public Vector3 rolerBornPos_1 = new Vector3(-719, 314, 0);
    //位置检索（保存影子位置）
    public Vector3[] matchPosArray_1 = new Vector3[] { new Vector3(-367.5f, 175.9f, 0f), new Vector3(201.7f, 39.47f, 0f) };
    public float[] matchEulerArray_1 = new float[] { 270f, 63.695f };
    public string[] matchItemNameArray_1 = new string[] { "HuaBi", "ShaoZi" };



    public Vector3[] collectPosDirtyArray_2 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };
    public Vector3[] collectPosDirtyArray_3 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };






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
