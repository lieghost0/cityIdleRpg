using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    class UIElement
    {
        public string Resources;
        public bool Cache;
        public GameObject instance;
    }

    Dictionary<Type, UIElement> UIResources = new Dictionary<Type, UIElement>();

    public UIManager()
    {
        this.UIResources.Add(typeof(UIPersonInfo), new UIElement() { Resources = "UI/Person/UIPersonInfo", Cache = false });

    }

    ~UIManager() { }

    /// <summary>
    /// 显示窗口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Show<T>(Transform parent = null)
    {
        Type type = typeof(T);
        if(this.UIResources.ContainsKey(type))
        {
            UIElement info = this.UIResources[type];
            if(info.instance != null)
            {
                info.instance.SetActive(true);
            }
            else
            {
                UnityEngine.Object prefab = Resources.Load(info.Resources);
                if (prefab == null)
                {
                    Debug.LogError("路径：" + info.Resources);
                    return default(T);
                }
                info.instance = (GameObject)GameObject.Instantiate(prefab, parent);
            }
            return info.instance.GetComponent<T>();
        }
        return default(T);
    }

    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="type"></param>
    private void Close(Type type)
    {
        if (this.UIResources.ContainsKey(type))
        {
            UIElement info = this.UIResources[type];
            if (info.Cache)
            {
                info.instance.SetActive(false);
            }
            else
            {
                GameObject.Destroy(info.instance);
                info.instance = null;
            }
        }
    }

    public void Close<T>()
    {
        this.Close(typeof(T));
    }
}
