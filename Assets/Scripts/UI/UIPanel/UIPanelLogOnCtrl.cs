using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelLogOnCtrl : UIBase
{
    protected override void OnBtnClick(GameObject go)
    {
        Debug.Log(go.name);
    }
}
