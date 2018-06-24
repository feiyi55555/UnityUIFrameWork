using System.Collections;
using System.Collections.Generic;
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
                UIPanelMgr.Instance.ExitPanel();
                break;
            case "Button_Close":
                UIPanelMgr.Instance.ExitPanel();
                break;
        }
    }
}
