using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : MonoBehaviour
{
    public Text textLevel;
    public Text textName;
    public Slider hp;
    public Text textHp;

    public void OnClickPerson()
    {
        UIManager.Instance.Show<UIPersonInfo>(LayerManager.Instance.GetLayerParent(LayerManager.LayerType.level2));
    }
    public void OnClickTalent()
    {

    }
    public void OnClickSkill()
    {

    }
}
