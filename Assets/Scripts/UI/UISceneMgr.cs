using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISceneMgr : Singleton<UISceneMgr>
{
    public enum SceneType
    {
        None,
        UILogOnScene,
    }

    public Object Load(SceneType sceneType)
    {
        string path = "";
        switch (sceneType)
        {
            case SceneType.UILogOnScene:
                path += "UIScenes/UILogOnScene";
                break;
            default:
            case SceneType.None:
                break;
        }
        return ResMgr.Instance.LoadAndInstantiate(path, ResMgr.ResType.UI);
    }
}
