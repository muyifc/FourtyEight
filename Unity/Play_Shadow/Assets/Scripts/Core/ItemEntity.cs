using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//前景物件
//拖拽、选装等
[RequireComponent(typeof(RectTransform))]
public class ItemEntity : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform mShadow;
    private Vector3 targetOffset;
    private SpriteRenderer[] mChildRenderer;

    private bool isDrag = false;
    //偏移量
    private Vector3 offset = Vector3.zero;
    RectTransform rect;
    RectTransform canvasRect;


    public float max_rect = 1000;
    public float min_rect = -1000;
    Vector3 newPos;
    float shadowScale;

    Animation mAnim;

    void OnEnable()
    {
        // mAnim.Play("drop");
    }
    void Awake()
    {
        mAnim = transform.GetComponent<Animation>();
        shadowScale = 100.0f / Vector3.Distance(transform.position, Camera.main.transform.position);

        rect = this.GetComponent<RectTransform>();
        canvasRect = transform.root.GetComponent<RectTransform>();

        targetOffset = transform.position - mShadow.position;
        mChildRenderer = transform.GetComponentsInChildren<SpriteRenderer>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = false;
        SetDragObjPostion(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        SetDragObjPostion(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetDragObjPostion(eventData);
    }



    void SetDragObjPostion(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition;

        //判断是否点到UI图片上的时候
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out mouseWorldPosition))
        {
            if (isDrag)
            {
                newPos = new Vector3(mouseWorldPosition.x + offset.x, rect.position.y, rect.position.z);
                JudgeRectRange();
            }
            else
            {
                //计算偏移量                
                offset = rect.position - mouseWorldPosition;
            }

            //直接赋予position点到的时候回跳动
            //rect.position = mouseWorldPosition;
        }

        //动态监测
        SceneManager.Instance.CheckMatching(this.transform);
    }

    void JudgeRectRange()
    {
        // Debug.Log(newPos+"//"+Camera.main.WorldToScreenPoint(newPos));
        rect.position = newPos;

        if (rect.localPosition.x < min_rect)
            rect.localPosition = new Vector3(min_rect, rect.localPosition.y, rect.localPosition.z);
        else if (rect.localPosition.x > max_rect)
            rect.localPosition = new Vector3(max_rect, rect.localPosition.y, rect.localPosition.z);

        Vector3 pos = transform.position - targetOffset;
        mShadow.position = new Vector3(pos.x * shadowScale, pos.y * shadowScale, pos.z);
    }

    void Update()
    {
        if (mAnim.isPlaying)
        {
            Vector3 pos = transform.position - targetOffset;
            mShadow.position = new Vector3(pos.x * shadowScale, pos.y * shadowScale, pos.z);
        }
    }

}