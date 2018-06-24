using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelLogInCtrl : UIBase
{
    protected override void OnBtnClick(GameObject go)
    {
        Debug.Log(go.name);
        switch (go.name)
        {
            case "Button_LogIn":

                break;
            case "Button_Close":
                
                break;
            case "Button_Reg":
                UIPanelMgr.Instance.EnterPanel(UIPanelMgr.PanelType.Panel_LogOn);
                break;
        }
    }
}
