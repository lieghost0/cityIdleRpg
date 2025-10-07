using System.Collections;
using System.Collections.Generic;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : MonoBehaviour
{
    public Text textLevel;
    public Text textName;
    public Slider hp;
    public Text textHp;

    public void GameEnter()
    {
        this.textLevel.text = User.Instance.currentPlayer.level.ToString();
        this.textName.text = User.Instance.currentPlayer.name;
    }

    public void OnClickPerson()
    {
        UIManager.Instance.Show<UIPersonInfo>(LayerManager.Instance.GetLayerParent(LayerType.level2));
    }
    public void OnClickTalent()
    {

    }
    public void OnClickSkill()
    {

    }
}
