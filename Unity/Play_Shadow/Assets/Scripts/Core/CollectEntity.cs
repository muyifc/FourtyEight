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


    //被拾取
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);


    }



}