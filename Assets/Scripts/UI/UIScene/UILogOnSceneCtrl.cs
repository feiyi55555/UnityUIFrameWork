using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UILogOnSceneCtrl : MonoBehaviour
{

    [SerializeField]
    private GameObject m_Canvas;

    void Awake()
    {
        if (m_Canvas == null)
        {
            Debug.LogError("对象没有赋值！");
        }
    }

    // Use this for initialization
    void Start ()
    {
        UIPanelMgr.Instance.EnterPanel(UIPanelMgr.PanelType.Panel_LogIn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
