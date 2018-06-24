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
            listener.onClick = OnBtnClick;
        }
        OnAwake();
    }

    private void Start ()
    {
        OnStart();
    }

    private void Update () {
		
	}

    private void OnDestory()
    {
        BeforeOnDestory();
    }

    protected virtual void OnStart() { }
    protected virtual void OnAwake() { }
    protected virtual void BeforeOnDestory() { }
    protected virtual void OnBtnClick(GameObject go) { }
}
