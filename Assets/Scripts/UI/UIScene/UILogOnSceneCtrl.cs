using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /*
        GameObject panel = UIPanelMgr.Instance.LoadAndInstantiate(UIPanelMgr.PanelType.Panel_LogOn);
        panel.transform.SetParent(m_Canvas.transform);
        
        //panel.transform.position = Vector3.zero; 
        panel.transform.localPosition = Vector3.zero; // 如果不是localPosition，那么Z值会错乱
        
        panel.transform.rotation = Quaternion.identity;
        panel.transform.localScale = Vector3.one;
        */

        UIPanelMgr.Instance.EnterPanel(UIPanelMgr.PanelType.Panel_LogIn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
