﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemStatu
{
    None,
    Drag,
    Rotate,
}

public class LevelLayer : LayerManager<LevelLayer>
{

    // public GameObject itemMenu;
    // public GameObject closeItemMune;
    // public GameObject dragItemMune;
    // public GameObject rotateItemMune;

    private ItemEntity targetItem;
    private ItemStatu curStatu = ItemStatu.None;

    public GameObject mDefeat;
    public GameObject mGameOver;

    private GameObject btnTip;

    public void ShowDefeat()
    {
        mDefeat.SetActive(true);
    }
    void DefeatEvent(GameObject obj)
    {
        LevelLayer.Instance.Destroy();
        Gamer.Instance.StartLevel(SceneManager.Instance.curLevelID);
    }

    public void ShowGameOver()
    {
        PlayEnd();
        Debug.Log("Game Over");
        // mGameOver.SetActive(true);
    }

    Transform qiqiuShadow;
    void PlayEnd()
    {
        //气球旋转
        Transform qiqiu = transform.parent.Find("SceneManager/Scene_3(Clone)/FrontEntity/QiQiu");
        qiqiuShadow = transform.parent.Find("SceneManager/Scene_3(Clone)/FrontEntity/QiQiuShadow");

        iTween.RotateAdd(qiqiu.gameObject, new Vector3(0, 0, 180), 2f);
        iTween.RotateAdd(qiqiuShadow.gameObject, new Vector3(0, 0, 180), 2f);

        Timer timer1 = new Timer(2, () => { }, () =>
         {
             this.PlayMove();
         }, false);
    }


    void PlayMove()
    {
        //猪脚移动到气球
        GameObject pathObj = ResourcePool.Instance.Spawn("Path_3_6");
        pathObj.transform.SetParent(SceneManager.Instance.transform);
        pathObj.transform.localPosition = new Vector3(pathObj.transform.localPosition.x, pathObj.transform.localPosition.y, 0);
        RolerController.Instance.AutoMove(pathObj.GetComponent<iTweenPath>(), false);

        //猪脚变小
        iTween.ScaleTo(RolerController.Instance.gameObject, iTween.Hash("scale", new Vector3(15, 15, 0), "time", 1f, "delay", 1F, "islocal", true, "easetype", iTween.EaseType.linear));

        Timer timer1 = new Timer(2, () => { }, () =>
         {
             this.PlayFly();
         }, false);
    }

    void PlayFly()
    {
        //iTween.MoveTo(qiqiu.gameObject, iTween.Hash("position", new Vector3(1761, 2200, 0), "time", 5F, "delay", 2F, "islocal", true));
        iTween.MoveTo(qiqiuShadow.gameObject, iTween.Hash("position", new Vector3(1710, 1000, 0), "time", 5f, "islocal", true, "easetype", iTween.EaseType.linear));
        isFollow = true;
        Timer timer1 = new Timer(7, () => { }, () =>
         {
             mGameOver.SetActive(true);
             SceneManager.Instance.Destroy();
         }, false);
    }

    private bool isFollow;
    public void Update()
    {
        if (isFollow)
        {
            Debug.Log("bye~~");
            RolerController.Instance.transform.position = qiqiuShadow.transform.position + new Vector3(0.3f, -5f, -1f);
        }
    }

    void GameOverEvent(GameObject obj)
    {
        LevelLayer.Instance.Destroy();
        LayerManager<HomeLayer>.Open("PlotPanel");
    }
    // Use this for initialization
    void Start()
    {
        mDefeat.SetActive(false);
        mGameOver.SetActive(false);

        EventTriggerListener.Get(mDefeat).onClick = DefeatEvent;
        EventTriggerListener.Get(mGameOver).onClick = GameOverEvent;

        btnTip = transform.Find("btnTip").gameObject;
        EventTriggerListener.Get(btnTip).onClick = onTip;
        // this.itemMenu.SetActive(false);
        // EventTriggerListener.Get(closeItemMune).onClick = CloseEvent;
        // EventTriggerListener.Get(dragItemMune).onClick = DragClickEvent;
        // EventTriggerListener.Get(rotateItemMune).onClick = RotateClickEvent;
    }

    void OnDestroy()
    {
        EventTriggerListener.Get(btnTip).onClick = null;
    }

    private void onTip(GameObject go)
    {
        TipManager.Instance.Show();
    }

    // private Vector3 dragOffset;
    // private bool isDrag = false;
    // private void DragClickEvent(GameObject go)
    // {
    //     isDrag = false;
    //     curStatu = ItemStatu.Drag;
    // }
    // private void RotateClickEvent(GameObject go)
    // {
    //     curStatu = ItemStatu.Rotate;
    // }
    // private void CloseEvent(GameObject go)
    // {
    //     curStatu = ItemStatu.None;
    //     this.itemMenu.SetActive(false);
    //     this.targetItem.Reset();
    // }

    // public void ShowMenu(ItemEntity menu)
    // {
    //     this.targetItem = menu;
    //     this.itemMenu.SetActive(true);
    // }

    // void 
    // Update is called once per frame
    // void Update()
    // {
    //     // if (this.itemMenu != null)
    //     //     transform.localPosition = this.itemMenu.transform.localPosition;
    //     if (curStatu == ItemStatu.None) return;

    //     if (Input.GetMouseButton(0))
    //     {
    //         if (curStatu == ItemStatu.Rotate)
    //         {
    //             float m_fDeltaX = Input.GetAxis("Mouse X") * Time.deltaTime * 120;
    //             float m_fDeltaY = Input.GetAxis("Mouse Y") * Time.deltaTime * 120;
    //             this.targetItem.transform.Rotate(new Vector3(0, 0, m_fDeltaX + m_fDeltaY), Space.Self);
    //             this.targetItem.update();
    //         }
    //         else if (curStatu == ItemStatu.Drag)
    //         {
    //             if (!isDrag)
    //             {
    //                 isDrag = true;
    //                 Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
    //                 this.dragOffset = this.targetItem.transform.position - targetPosition;
    //             }
    //             else
    //             {
    //                 Vector3 targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
    //                 this.targetItem.transform.position = targetPosition + dragOffset;
    //                 this.targetItem.update();
    //                 // this.itemMenu.transform.localPosition = this.targetItem.transform.position;
    //             }

    //         }
    //     }
    //     if (Input.GetMouseButtonUp(0))
    //     {
    //         isDrag = false;
    //         // Debug.Log("isDrag:" + isDrag);			
    //     }
    // }
}
