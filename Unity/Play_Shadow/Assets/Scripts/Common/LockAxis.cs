using UnityEngine;
using System.Collections;

public class LockAxis : MonoBehaviour {
    public bool isCheckX;
    public bool isCheckY;
    public bool isCheckZ;

    public Vector2 axisX;
    public Vector2 axisY;
    public Vector2 axisZ;

    /// 验证移动轴
    public Vector3 AdjustLockAxis(Vector3 pos){
        if(isCheckX) pos.x = Mathf.Clamp(pos.x,axisX.x,axisX.y);
        if(isCheckY) pos.y = Mathf.Clamp(pos.y,axisY.x,axisY.y);
        if(isCheckZ) pos.z = Mathf.Clamp(pos.z,axisZ.x,axisZ.y);
        return pos;
    }
}