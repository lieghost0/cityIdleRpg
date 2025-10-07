using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIInputBox : MonoBehaviour
{
    public Text textTitle;//提示框标题
    public Text textMessage;//提示输入内容
    public InputField inputField;//输入内容
    public Text textTips;//错误提示
    public Button buttonYes;
    public Button buttonNo;

    public Text buttonYesTitle;
    public Text buttonNoTitle;

    public string emptyTips;

    public UnityAction OnYes;
    public UnityAction OnNo;

    public delegate bool SubmitHandler(string inputField, out string tips);
    public event SubmitHandler OnSubmit;
    public UnityAction OnCancel;

    public void Init(string title, string message, string btnOK = "", string btnCancel = "", string emptyTips = "")
    {
        if(!string.IsNullOrEmpty(title)) this.textTitle.text = title;
        this.textMessage.text = message;
        this.textTips.text = "";
        this.OnSubmit = null;
        this.emptyTips = emptyTips;

        if (!string.IsNullOrEmpty(btnOK)) this.buttonYesTitle.text = btnOK;
        if (!string.IsNullOrEmpty(btnCancel)) this.buttonNoTitle.text = btnCancel;

        this.buttonYes.onClick.AddListener(OnClickYes);
        this.buttonNo.onClick.AddListener(OnClickNo);
    }

    public void OnClickYes()
    {
        this.textTips.text = "";
        if (!string.IsNullOrEmpty(this.emptyTips))
        {
            this.textTips.text = this.emptyTips;
            return;
        }
        if (this.OnSubmit != null)
        {
            string tips;
            if(!this.OnSubmit(this.inputField.text, out tips))
            {
                this.textTips.text = tips;
                return;
            }
        }
        Destroy(this.gameObject);
    }

    public void OnClickNo()
    {
        Destroy(this.gameObject);
        if (this.OnCancel != null)
            this.OnCancel();
    }
}
