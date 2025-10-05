using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Defines
{
    public class ItemDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Category { get; set; }
        public int ItemLevel { get; set; }
        public int CD { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int StackLimit { get; set; }
        public string Icon { get; set; }
        public ItemFunction Function { get; set; }
        public ItemParamType ParamType { get; set; }
        public int Param { get; set; }
    }

    public enum ItemType
    {
        None = 0,
        Potion,         //药水
        Equip,          //装备
        Skill,          //技能
        ExchangeItem,   //兑换物
        Consumables,    //非药水消耗品
        Material        //材料
    }

    public enum ItemFunction
    {
        RecoverHP,
        RecoverMP,
        AddBuff,
        AddExp,
        AddMoney,
        AddItem,
        AddSkillPoint
    }

    public enum ItemParamType
    {
        Number,
        Percent
    }
}