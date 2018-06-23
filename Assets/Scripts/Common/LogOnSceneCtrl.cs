using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登陆场景主控（一般每个场景都需要一个主控制器）
/// </summary>
public class LogOnSceneCtrl : MonoBehaviour
{
    void Start()
    {
        UISceneMgr.Instance.Load(UISceneMgr.SceneType.UILogOnScene);
    }
}
