using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resources目录管理器
/// </summary>
public class ResMgr : Singleton<ResMgr>
{
    // TODO:做缓存

    public enum ResType
    {
        None,
        Role,
        UI,
        UIPanel
    }

    /// <summary>
    /// 利用Resources.Load加载
    /// </summary>
    /// <param name="name"></param>
    /// <param name="resType"></param>
    /// <returns>预设</returns>
    public Object Load(string name, ResType resType)
    {
        string path = "";
        switch (resType)
        {
            case ResType.UI:
                path = "UIs/";
                break;
            case ResType.Role:
                path = "Roles/";
                break;
            case ResType.None:
            default:
                break;
        }
        path += name;
        if (!string.IsNullOrEmpty(path))
        {
            return Resources.Load(path);
        }
        return null;
    }

    /// <summary>
    /// 加载并且实例化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="resType"></param>
    /// <returns>clone物体</returns>
    public Object LoadAndInstantiate(string name, ResType resType)
    {
        Object obj = Load(name, resType);
        if (obj != null)
        {
            return Object.Instantiate(obj);
        }
        return null;
    }
}
