using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelMgr : Singleton<UIPanelMgr>
{

    public enum PanelType
    {
        None,
        Panel_LogIn,
        Panel_LogOn,
    }

    public GameObject Load(PanelType panelType)
    {
        string path = "";
        switch (panelType)
        {
            case PanelType.Panel_LogIn:
                path += "UIPanels/Panel_LogIn";
                break;
            case PanelType.Panel_LogOn:
                path += "UIPanels/Panel_LogOn";
                break;
            default:
            case PanelType.None:
                break;
        }
        return ResMgr.Instance.LoadAndInstantiate(path, ResMgr.ResType.UI) as GameObject;
    }
}
