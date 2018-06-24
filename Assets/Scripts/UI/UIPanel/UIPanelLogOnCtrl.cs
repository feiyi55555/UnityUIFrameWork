using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIPanelLogOnCtrl : UIBase
{
    protected override void OnBtnClick(GameObject go)
    {
        Debug.Log(go.name);
        switch (go.name)
        {
            case "Button_RegAndLogIn":

                break;
            case "Button_Cancel":
                UIPanelMgr.Instance.ExitPanel((objs) =>
                {
                    if (objs.Length > 0)
                    {
                        GameObject panel = objs[0] as GameObject;

                        DOTweenAnimation tween = panel.GetComponent<DOTweenAnimation>();
                        tween.DOPlayBackwards();
                    }
                });
                break;
            case "Button_Close":
                UIPanelMgr.Instance.ExitPanel();
                break;
        }
    }
}
