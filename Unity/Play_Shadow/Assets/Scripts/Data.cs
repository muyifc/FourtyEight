using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : Singleton<Data>
{
    public string storty_1 = "很久很久以前，\n有一个部落";

    //每关几根木柴
    public int[] collectCountPerLevel = { 2, 2, 3 };
    public Vector3[] collectPosDirtyArray_1 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };


    public Vector3[] collectPosDirtyArray_2 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };
    public Vector3[] collectPosDirtyArray_3 = new Vector3[] { new Vector3(1f, 2f, 3f), new Vector3(12f, 2f, 1f) };



}
