using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//收集物：柴火
public class CollectEntity : MonoBehaviour
{
    //tween动画出现在场景中
    public void Born(Vector3 worldPos)
    {

    }

    void Update()
    {
        //被拾取
        //Debug.Log(Vector3.Distance(transform.position, RolerController.Instance.transform.position));
        if (Vector3.Distance(transform.position, RolerController.Instance.transform.position) < 10)
        {
            TimeEntity.Instance.ResetTime();
            GameObject.Destroy(this.gameObject);
        }
    }




}