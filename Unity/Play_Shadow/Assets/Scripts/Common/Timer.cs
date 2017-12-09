using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public delegate void TimerStart();
public delegate void TimerEnd();

public class Timer
{
    float duringTime;
    float oldTime = -1;
    bool flag;
    TimerStart OnStart;
    TimerEnd OnEnd;
    static List<Timer> timerList = new List<Timer>();

    public Timer(float time, TimerStart startFunc, TimerEnd endFunc, bool alwaysDO)
    {
        duringTime = time;
        OnStart = startFunc;
        OnEnd = endFunc;
        oldTime = Time.time;
        flag = alwaysDO;
        OnStart();
        for (int idx = 0; idx < timerList.Count; idx++)
        {
            if (timerList[idx] == null)
            {
                timerList[idx] = this;
                return;
            }
        }
        timerList.Add(this);
    }

    public static void Update()
    {
        for (int idx = 0; idx < timerList.Count; idx++)
        {
            if (timerList[idx] != null)
            {
                timerList[idx].update();
            }
        }

    }

    public float getOldTime() { return oldTime; }

    public void stopTimer() { oldTime = -1; }

    public static void stopAllTimer()
    {
        foreach (var time in timerList)
            time.stopTimer();
    }

    void update()
    {
        if (oldTime != -1)
        {
            if (!flag)
                Function();
            else
            {
                OnStart();
                Function();
            }
        }
    }

    void Function()
    {
        if (Time.time > oldTime + duringTime)
        {
            oldTime = -1;
            OnEnd();
            int idx = timerList.IndexOf(this);
            timerList[idx] = null;
        }
    }

}