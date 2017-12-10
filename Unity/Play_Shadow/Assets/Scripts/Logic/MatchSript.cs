using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EMatchType
{
    None,
    FlashChild,
    MoveScene,
    Click,
}
public class MatchSript : MonoBehaviour
{
    public EMatchType mEMatchType = EMatchType.None;
    float tempTime = 0;
    float tickTime = 0.5f;
    private float curSecond = 5;
    private bool isUpdate = false;
    void Start()
    {

    }
    public void DO()
    {
        switch (mEMatchType)
        {
            case EMatchType.None:
                break;
            case EMatchType.FlashChild:
                isUpdate = true;
                break;
            case EMatchType.MoveScene:
                // iTween.MoveTo(SceneManager.Instance.curSceneLayer, iTween.Hash("position",
                //  new Vector3(-855, 0, 0), "islocal", true, "time", 3F, "easetype", iTween.EaseType.linear));

                // iTween.MoveTo(SceneManager.Instance.curSceneLayer, iTween.Hash("position",
                // new Vector3(-855, 0, 0), "islocal", true, "time", 3F, "easetype", iTween.EaseType.linear));
                // iTween.MoveTo(SceneManager.Instance.curSceneLayer, new Vector3(-855, 0, 0), 4f);
                // iTween.MoveTo(RolerController.Instance.gameObject, new Vector3(-489.2135f, 208.7463f, -18.70615f), 4f);

                break;
            case EMatchType.Click:
                //EventTriggerListener.Get(this.gameObject).onClick = ClickEvent;
                break;
        }

    }

    void Update()
    {
        if (!isUpdate) return;
        if (tempTime > 0)
            tempTime -= Time.deltaTime;
        if (tempTime < 0)
            tempTime = 0;
        if (tempTime == 0)
        {
            Tick();
            tempTime = tickTime;
        }
    }


    public void Tick()
    {
        Debug.Log("Tick...........");
        if (curSecond > 0)
        {
            curSecond--;
            transform.GetChild(0).gameObject.SetActive(curSecond % 2 == 0);
        }
        else
        {
            isUpdate = false;
            this.enabled = false;
        }
    }

    private bool isOver = false;
    public void ClickEvent(GameObject obj)
    {
        bool over = true;
        Transform par = transform.parent.Find("jundao");
        foreach (Transform tran in par)
        {
            if (!tran.gameObject.activeSelf)
            {
                over = false;
                tran.gameObject.SetActive(true);
                break;
            }
        }

        Transform spar = transform.parent.parent.Find("Shadows/jundao");
        foreach (Transform tran in spar)
        {
            if (!tran.gameObject.activeSelf)
            {
                over = false;
                tran.gameObject.SetActive(true);
            }
        }
        if (over && !isOver)
        {
            isOver = true;
            Debug.Log("ClickJundao");
            SceneManager.Instance.MatchFun(this.transform.GetComponent<ItemEntity>().mShadow);
        }
    }
}
