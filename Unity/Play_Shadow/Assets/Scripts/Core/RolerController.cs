using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class RolerController : MonoBehaviour
{
    public static RolerController Instance;
    private iTweenEvent tweenEvent;
    public UnityArmatureComponent anim;
    public AudioSource mAudio;
    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        this.anim.animation.Play();
    }

    public void AutoMove(iTweenPath path)
    {
        Debug.Log("GO");
        Hashtable args = new Hashtable();
        // args.Add("axis", "x");
        // args.Add("axis", "y");

        // Vector3[] pathArray = iTweenPath.GetPath(path.pathName);//世界坐标
        // for (int idx = 0; idx < pathArray.Length; idx++)
        // {
        //     pathArray[idx] = new Vector3(pathArray[idx].x * Data.Instance.Ratio, pathArray[idx].y * Data.Instance.Ratio, pathArray[idx].z);
        //     pathArray[idx].z = path.transform.position.z;
        // }

        Vector3[] pathArray = iTweenPath.GetPath(path.pathName);//世界坐标
        // List<Vector3> newPath = new List<Vector3>();
        for (int idx = 0; idx < pathArray.Length; idx++)
        {
            pathArray[idx] = new Vector3(pathArray[idx].x * Data.Instance.Ratio, pathArray[idx].y * Data.Instance.Ratio, path.transform.position.z);
            // newPath.Add(new Vector3(pathArray[idx].x * Data.Instance.Ratio, pathArray[idx].y * Data.Instance.Ratio, path.transform.position.z));
        }


        args.Add("path", pathArray);
        args.Add("islocal", false);
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
        this.anim.animation.Play();
        this.mAudio.Play();
        Debug.Log("start :" + f);
    }
    //移动结束
    void AnimationEnd(string f)
    {
        this.anim.animation.Play();
        this.mAudio.Stop();

        Debug.Log("end : " + f);
        SceneManager.Instance.SwitchLevelPart();
    }

}
