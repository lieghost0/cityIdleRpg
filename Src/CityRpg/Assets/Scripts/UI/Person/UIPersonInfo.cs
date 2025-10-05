using System.Collections;
using System.Collections.Generic;
using Defines;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIPersonInfo : UIWindow
{
    public Transform[] slots;//装备格子

    public Text[] textBaseAttrs;
    public Text textFreePoint;//自由属性点

    public Text[] textAttackAttrs;

    Image[] bagItems;

    public Transform content;
    public GameObject item;

    private void Start()
    {
        this.bagItems = content.GetComponentsInChildren<Image>();

        RefreshUI();
    }

    public void OnClickAddPoint()
    {

    }
    public void OnClickAddPointReset()
    {

    }

    public void RefreshUI()
    {
        ClearAll();
        InitAll();
    }

    public void ClearAll()
    {
        foreach (var item in bagItems)
        {
            if(item.transform.childCount > 0)
            {
                Destroy(item.transform.GetChild(0).gameObject);
            }
        }
    }

    public void InitAll()
    {
        int i = 0;
        foreach(var kv in DataManager.Instance.items)
        {
            ItemDefine item = kv.Value;
            if(item.ID > 0)
            {
                GameObject go = Instantiate(this.item, bagItems[i].transform);
                UIBagItem ui = go.GetComponent<UIBagItem>();
                ui.SetItem(item.Icon, 9);
                i++;
            }
        }
    }
}
