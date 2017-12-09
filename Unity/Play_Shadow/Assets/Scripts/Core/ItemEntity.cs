using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//前景物件
//拖拽、选装等
[RequireComponent(typeof(RectTransform))]
public class ItemEntity : MonoBehaviour, IDragHandler,IEndDragHandler
{
    public bool isCanMove = false;
    public bool isCanRotate = false;

    public Transform mShadow;



    //update
    public void OnDrag(PointerEventData eventData)
    {
        if (isCanRotate)
            SetDraggedRotation(eventData);
        if (isCanMove)
            SetDraggedPosition(eventData);

        this.Refresh();
    }
    //旋转图片
    private void SetDraggedRotation(PointerEventData eventData)
    {
        Vector2 curScreenPosition = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, transform.position);
        Vector2 directionTo = curScreenPosition - eventData.position;
        Vector2 directionFrom = directionTo - eventData.delta;
        this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
    }
    //拖动图片
    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position,
        eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (SceneManager.Instance.MatchFun(this.mShadow))
        {
            // this.gameObject.SetActive(false);
            isCanRotate = false;
            isCanMove = false;
        }
    }


    void Start()
    {
        if (this.mShadow != null)
        {
            this.transform.localPosition = mShadow.localPosition + Data.Instance.shadowOffset;
            transform.localEulerAngles = mShadow.localEulerAngles;
        }
        if (!isCanMove && !isCanRotate)
            this.enabled = false;

        // EventTriggerListener.Get(this.gameObject).onClick = SelectEvent;
        // mShadow.localPosition = this.transform.localPosition - Data.Instance.shadowOffset;
    }
    // private void SelectEvent(GameObject go)
    // {
    //     LevelLayer.Instance.ShowMenu(this);
    // }

    void Refresh()
    {
        mShadow.localEulerAngles = transform.localEulerAngles;
        mShadow.localPosition = this.transform.localPosition - Data.Instance.shadowOffset;
        //动态监测
        if (SceneManager.Instance.CheckMatching(this.mShadow))
        {
            this.transform.localScale = Vector3.one * 1.2f;
        }
        else
        {
            this.transform.localScale = Vector3.one;
        }
    }

    public void Reset()
    {
        if (SceneManager.Instance.MatchFun(this.mShadow))
            this.gameObject.SetActive(false);
    }
    /* 
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        if (curStatu == ItemStatu.None)
        {
            LevelLayer.Instance.ShowMenu(this);
            return;
        }

        isDrag = false;
        SetDragObjPostion(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (curStatu == ItemStatu.None)
            return;
        isDrag = true;
        SetDragObjPostion(eventData);

        //动态监测
        if (SceneManager.Instance.CheckMatching(this.mShadow))
        {
            this.transform.localScale = Vector3.one * 1.5f;
        }
        else
        {
            this.transform.localScale = Vector3.one;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (curStatu == ItemStatu.None)
            return;
        SetDragObjPostion(eventData);
    }



    void SetDragObjPostion(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition;

        //判断是否点到UI图片上的时候
        if (this.curStatu == ItemStatu.Drag)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
            {
                if (isDrag)
                {
                    newPos = new Vector3(mouseWorldPosition.x + offset.x, mouseWorldPosition.y + offset.y, rect.position.z);
                    ResetPos();
                }
                else
                {
                    //计算偏移量                
                    offset = rect.position - mouseWorldPosition;
                }
            }
        }
        else if (this.curStatu == ItemStatu.Rotate)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
            {
                if (isDrag)
                {
                    Vector3 dir = mouseWorldPosition - offset;
                    Debug.Log(dir);
                    newAngle = dir.x;
                    ResetAngle();
                }
                else
                {
                    offset = mouseWorldPosition;
                }
            }
        }


    }

    void ResetPos()
    {
        // Debug.Log(newPos+"//"+Camera.main.WorldToScreenPoint(newPos));
        rect.position = newPos;

        // if (rect.localPosition.x < min_rect)
        //     rect.localPosition = new Vector3(min_rect, rect.localPosition.y, rect.localPosition.z);
        // else if (rect.localPosition.x > max_rect)
        //     rect.localPosition = new Vector3(max_rect, rect.localPosition.y, rect.localPosition.z);

        Vector3 pos = transform.position - targetOffset;
        mShadow.position = new Vector3(pos.x * shadowScale, pos.y * shadowScale, pos.z);
    }

    void ResetAngle()
    {
        rect.localEulerAngles = new Vector3(0, 0, newAngle);
        mShadow.localEulerAngles = rect.localEulerAngles;
    }

    */


}