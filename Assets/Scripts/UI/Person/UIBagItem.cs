using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class UIBagItem : MonoBehaviour
{
    public Image icon;
    public Text textNum;

    public void SetItem(string image, int num)
    {
        if (icon != null) icon.overrideSprite = Resloader.Load<Sprite>(image);
        if (textNum != null) textNum.text = num.ToString();
    }
}
