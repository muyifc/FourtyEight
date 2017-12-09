using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Singleton<Data>
{
    public string storty_1 = "很久很久以前，\n有一个部落";

    //每关几根木柴
    public int[] collectCountPerLevel = { 1, 2, 3 };
    public int[] partCountPerLevel = { 1, 2, 3 };

    public Vector3 rolerBornPos_1 = new Vector3(-497, -347, 0);
    public Vector3[] collectPosDirtyArray_1 = new Vector3[] { new Vector3(115.8275f, 26.62638f, 0f) };


    public Vector3[] collectPosDirtyArray_2 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };
    public Vector3[] collectPosDirtyArray_3 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };






	//剧情
	public string PlotDesc1 = "我看不到自己，却只有在篝火的映照下才能感受到自己微弱的存在。";
	public string PlotDesc2 = "我还活着吗？或许吧。";
	public string PlotDesc3 = "而我唯一可以确认的是，一旦篝火熄灭，那点微弱的存在也将消失。";
	

	public string PlotIcon1 = "Image/plot1";
	public string PlotIcon2 = "Image/2";
	public string PlotIcon3 = "Image/3";
	

}
