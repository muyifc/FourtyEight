using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeEntity : MonoBehaviour
{
    public int second = 30;
    private float curSecond = 0;
    public Text mtext;
    public Slider mSlider;
    // Use this for initialization

    float attackTimer;
    float attackTime;

    public static TimeEntity Instance;
    void Start()
    {
        Instance = this;
        attackTimer = 0;
        attackTime = 1.0f;
        curSecond = second;
        mSlider.value = 1;
        mtext.text = "00:" + curSecond;
    }

    void Update()
    {
        if (attackTimer > 0)
            attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
            attackTimer = 0;
        if (attackTimer == 0)
        {
            Attack();
            attackTimer = attackTime;
        }
    }


    public void Attack()
    {
        //  你要执行的代码 每隔1S执行一次  
        mSlider.value = curSecond / second;
        if (curSecond < 10)
            mtext.text = "00:0" + curSecond;
        else
            mtext.text = "00:" + curSecond;

        curSecond--;
        if (curSecond < 0)
        {
            Gamer.Instance.StartLevel(SceneManager.Instance.curLevelID);
            return;
        }
    }

    public void ResetTime()
    {
        this.curSecond = second;
    }

}
