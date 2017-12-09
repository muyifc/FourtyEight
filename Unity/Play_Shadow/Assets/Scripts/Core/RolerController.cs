using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class RolerController : MonoBehaviour
{
    public static RolerController Instance;
    private iTweenEvent tweenEvent;
    public UnityArmatureComponent anim;
    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        this.anim.animation.Play("stand");
    }

    public void AutoMove(iTweenPath path)
    {
        Debug.Log("GO");
        Hashtable args = new Hashtable();
        // args.Add("axis", "x");
        // args.Add("axis", "y");

        args.Add("path", iTweenPath.GetPath(path.pathName));
        args.Add("easeType", iTween.EaseType.linear);
        args.Add("movetopath", false);
        args.Add("speed", 50f);
        // args.Add("time", 5f);

        args.Add("onstart", "AnimationStart");
        args.Add("onstartparams", 5.0f);
        args.Add("onstarttarget", gameObject);


        //移动结束时调用，参数和上面类似  
        args.Add("oncomplete", "AnimationEnd");
        args.Add("oncompleteparams", "end");
        args.Add("oncompletetarget", gameObject);

        iTween.MoveTo(this.gameObject, args);
    }

    //开始移动
    void AnimationStart(float f)
    {
        this.anim.animation.Play("walk");
        Debug.Log("start :" + f);
    }
    //移动结束
    void AnimationEnd(string f)
    {
        this.anim.animation.Play("stand");
        Debug.Log("end : " + f);
        SceneManager.Instance.SwitchLevelPart();
    }

}
