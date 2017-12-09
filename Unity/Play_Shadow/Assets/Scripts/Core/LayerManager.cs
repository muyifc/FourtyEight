using UnityEngine;
using System.Collections;
using System.Reflection;

public class LayerManager<T> : MonoBehaviour where T : LayerManager<T>
{
    static T msInstance;
    public static T Instance { get { return msInstance; } private set { msInstance = value; } }

    public static bool Exist { get { return mWndObject != null; } }
    public static bool Active { get { if (!Exist) { return false; } return mWndObject.activeSelf; } }
    public static GameObject WndObject { get { return mWndObject; } }

    GameObject mCamera = null;

    static GameObject mWndObject = null;
    protected virtual bool OnOpen() { return true; }
    protected virtual bool OnClose() { return true; }
    protected virtual bool OnShow() { return true; }
    protected virtual bool OnHide() { return true; }

    public LayerManager()
    {
        msInstance = this as T;
    }


    public static void Open(string PrefabName)
    {
        if (mWndObject != null)
        {
            Debug.LogWarning("Window:" + PrefabName + "The window already opened!!!!");
            GameObject.Destroy(mWndObject);
        }
        Debug.Log("Wnd Open: " + PrefabName);
        mWndObject = GameObject.Instantiate(Resources.Load(PrefabName)) as GameObject;

        GameObject RootUI = GameObject.Find("Canvas");
        if (RootUI == null)
            return;
        mWndObject.transform.parent = RootUI.transform;
        mWndObject.transform.localPosition = Vector3.zero;
        mWndObject.transform.localScale = Vector3.one;
    }


    public void Close()
    {
        GameObject.Destroy(mWndObject);
        msInstance = null;
        mWndObject = null;
    }
    public void Destroy()
    {
        GameObject.Destroy(mWndObject);
        msInstance = null;
        mWndObject = null;
    }


    public virtual void Show()
    {
        if (Exist)
        {
            mWndObject.SetActive(true);
        }

        OnShow();
    }

    public virtual void Hide()
    {

        if (Exist)
        {
            mWndObject.SetActive(false);
        }

        OnHide();
    }

    public GameObject Control(string name)
    {
        if (msInstance == null)
            return null;

        return Control(name, mWndObject);
    }

    public GameObject Control(string name, GameObject parent)
    {
        if (msInstance == null)
            return null;

        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.name == name)
                return child.gameObject;
        }
        return null;
    }
}
