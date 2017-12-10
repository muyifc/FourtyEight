using System.Collections;
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

    private GameObject btnTip;
    // Use this for initialization
    void Start()
    {
        btnTip = transform.Find("btnTip").gameObject;
		EventTriggerListener.Get(btnTip).onClick = onTip;
        // this.itemMenu.SetActive(false);
        // EventTriggerListener.Get(closeItemMune).onClick = CloseEvent;
        // EventTriggerListener.Get(dragItemMune).onClick = DragClickEvent;
        // EventTriggerListener.Get(rotateItemMune).onClick = RotateClickEvent;
    }

    void OnDestroy(){
		EventTriggerListener.Get(btnTip).onClick = null;
    }

    private void onTip(GameObject gameObject){
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
