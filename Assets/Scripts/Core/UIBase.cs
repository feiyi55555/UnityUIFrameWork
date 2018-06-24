using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour {

    private void Awake()
    {
        Button[] btns = GetComponentsInChildren<Button>();
        for (int i = 0; i < btns.Length; i++)
        {
            Button btn = btns[i];
            EventTriggerListener listener = EventTriggerListener.Get(btn.gameObject);
            listener.onClick = BtnClick;
        }
        OnAwake();
    }

    private void BtnClick(GameObject go)
    {
        OnBtnClick(go);
    }

    private void Start ()
    {
        OnStart();
    }

    private void OnDestory()
    {
        BeforeOnDestory();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        GameObject.Destroy(gameObject);
    }

    protected virtual void OnStart() { }
    protected virtual void OnAwake() { }
    protected virtual void BeforeOnDestory() { }
    protected virtual void OnBtnClick(GameObject go) { }
}
