using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolerController : MonoBehaviour
{
    public static RolerController Instance;
    private iTweenEvent tweenEvent;
    void Awake()
    {
        Instance = this;
    }

    public void AutoMove(iTweenPath path)
    {       
        Hashtable args = new Hashtable();

        args.Add("path", iTweenPath.GetPath(path.pathName));
        args.Add("easeType", iTween.EaseType.linear); 
        args.Add("movetopath", false);
        args.Add("speed", 50f);

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
        Debug.Log("start :" + f);
    }
    //移动结束
    void AnimationEnd(string f)
    {
        Debug.Log("end : " + f);
    }

}
