using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class UIPanelMgr : Singleton<UIPanelMgr>
{

    public enum PanelType
    {
        None,
        Panel_LogIn,
        Panel_LogOn,
    }

    public GameObject LoadAndInstantiate(PanelType panelType)
    {
        string path = GetPathByType(panelType);
        GameObject panel = ResMgr.Instance.LoadAndInstantiate(path, ResMgr.ResType.UI) as GameObject;
        panel.SetActive(false);

        if (UISceneCanvas == null)
        {
            throw new Exception("挂件没找到！");
        }
        panel.transform.SetParent(UISceneCanvas.transform);
        panel.transform.localPosition = Vector3.zero; // 如果不是localPosition，那么Z值会错乱
        panel.transform.rotation = Quaternion.identity;
        panel.transform.localScale = Vector3.one;
        return panel;
    }

    public GameObject Load(PanelType panelType)
    {
        string path = GetPathByType(panelType);
        return ResMgr.Instance.Load(path, ResMgr.ResType.UI) as GameObject;
    }

    public string GetPathByType(PanelType panelType)
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
        return path;
    }



    #region 页面跳转

    //private UIBase currPanel;

    private GameObject m_UISceneCanvas;

    public GameObject UISceneCanvas
    {
        get
        {
            if (m_UISceneCanvas == null)
            {
                m_UISceneCanvas = GameObject.FindGameObjectWithTag("Canvas Container");
            }
            return m_UISceneCanvas;
        }
        set { m_UISceneCanvas = value; }
    }

    private Stack<GameObject> stackUiBases = new Stack<GameObject>();

    public delegate void OnEnterPanel(params Object[] obj);
    public delegate void OnExitPanel(params Object[] obj);

    public void EnterPanel(PanelType panelType, OnEnterPanel onEnterPanel = null)
    {
        if (stackUiBases.Count > 0)
        {
            GameObject goOld = stackUiBases.Peek();
            goOld.SetActive(false);
        }
        GameObject go = this.LoadAndInstantiate(panelType);
        go.SetActive(true);
        stackUiBases.Push(go);
        if (onEnterPanel != null)
        {
            onEnterPanel(go);
        }
        else
        {
            DOTweenAnimation doTween = go.GetComponent<DOTweenAnimation>();
            if (doTween != null)
            {
                doTween.DOPlayForward();
            }
        }
    }

    public void ExitPanel(OnExitPanel onExitPanel = null)
    {
        if (stackUiBases.Count > 1)
        {
            GameObject go = stackUiBases.Pop();
            //go.SetActive(false);
            if (onExitPanel != null)
            {
                onExitPanel(go);
            }
            else
            {
                DOTweenAnimation doTween = go.GetComponent<DOTweenAnimation>();
                if (doTween != null)
                {
                    UnityEvent unityEvent = new UnityEvent();
                    unityEvent.AddListener(() =>
                    {
                        go.SetActive(false);
                        Object.Destroy(go);
                    });
                    doTween.onComplete = unityEvent;
                    doTween.DOPlayBackwards();
                }
            }
            //GameObject.Destroy(go);
            if (stackUiBases.Peek() != null)
            {
                GameObject goNew = stackUiBases.Peek();
                goNew.SetActive(true);
            }
        }
        else
        {
            throw new Exception("UIPanel IS NULL, WRONG EXIT!");
        }
    }

    public void Test()
    {
        Debug.Log("666啊！");
    }

    public void ChangePanel(PanelType panelType, OnExitPanel onExitPanel = null, OnEnterPanel onEnterPanel = null)
    {
        ExitPanel(onExitPanel);
        EnterPanel(panelType, onEnterPanel);
    }
#endregion
}
