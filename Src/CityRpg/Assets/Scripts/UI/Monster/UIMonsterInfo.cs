using System.Collections;
using System.Collections.Generic;
using Defines;
using Entities;
using UnityEngine;
using UnityEngine.UI;

public class UIMonsterInfo : MonoBehaviour
{
    public Text monsterName;
    public Slider hp;
    public Text hpValue;

    public Monster monster;
    public MonsterDefine monsterDefine;

    public void SetMonsterInfo(string monsterName, int hpValue)
    {
        this.monsterName.text = monsterName;
        this.hpValue.text = hpValue.ToString();
    }
}
