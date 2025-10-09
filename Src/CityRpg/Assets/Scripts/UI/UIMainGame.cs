using System.Collections;
using System.Collections.Generic;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : MonoBehaviour, IPoolable
{
    public Text textLevel;
    public Text textName;
    public Slider hp;
    public Text textHp;

    public Transform monsterBar;

    List<GameObject> monsters = new List<GameObject>();

    public void GameEnter()
    {
        this.textLevel.text = User.Instance.currentPlayer.Level.ToString();
        this.textName.text = User.Instance.currentPlayer.Name;

        RefreshMonster();
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

    //刷新怪物
    public void RefreshMonster()
    {
        int monsterNum = Random.Range(1, 6);

        for (int i = 0; i < monsterNum; i++)
        {
            GameObject monster = PoolManager.Instance.SpawnOnPool(PoolConfig.MonsterPool);
            UIMonsterInfo info = monster.GetComponent<UIMonsterInfo>();
            info.SetMonsterInfo("蚂蚁", 10);
            monster.transform.SetParent(monsterBar);
            monsters.Add(monster);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(monsterBar as RectTransform);
    }

    public void OnObjectSpawn()
    {
        foreach (GameObject monster in monsters)
        {
            PoolManager.Instance.ReturnToPool(PoolConfig.MonsterPool, monster);
        }
        this.monsters.Clear();
    }
}
