using UnityEngine;
using System.Collections;

public class TipManager : Singleton<TipManager> {
    private GameObject currentTip;

    public void Show(){
        if(currentTip != null){
            GameObject.Destroy(currentTip);
        }
        string tip = string.Empty;
        if(SceneManager.Instance.curLevelID == 1){
            tip = "Tip_01";
        }else{
            if(SceneManager.Instance.curPassLevelPart <=3){
                tip = "Tip_02";
            }else{
                tip = "Tip_03";
            }
        }
        currentTip = Resources.Load<GameObject>(string.Format("Tips/{0}",tip));
        EventTriggerListener.Get(currentTip).onClick = onHide;
    }

    public void Hide(){
        if(currentTip != null){
            EventTriggerListener.Get(currentTip).onClick = null;
            GameObject.Destroy(currentTip);
        }
    }

    private void onHide(GameObject go){
        Hide();
    }
}
