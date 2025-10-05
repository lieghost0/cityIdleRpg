using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWindow : MonoBehaviour
{
    //
    public delegate void CloseHandle(UIWindow sender, WindowResult result);
    public event CloseHandle OnClose;

    public virtual Type Type { get { return this.GetType(); } }

    public enum WindowResult
    {
        None = 0,
        Yes,
        No
    }

    /// <summary>
    /// 窗口关闭
    /// </summary>
    /// <param name="result"></param>
    public void Close(WindowResult result = WindowResult.None)
    {
        UIManager.Instance.Close<Type>();
        if(this.OnClose != null)
            this.OnClose(this, result);
        this.OnClose = null;
    }

    public virtual void OnCloseClick()
    {
        this.Close();
    }

    /// <summary>
    /// 确认
    /// </summary>
    public virtual void OnYesClick()
    {
        this.Close(WindowResult.Yes);
    }

    /// <summary>
    /// 否定
    /// </summary>
    public virtual void OnNoClick()
    {
        this.Close(WindowResult.No);
    }
}
