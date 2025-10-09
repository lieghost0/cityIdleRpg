using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Defines
{
    public class MonsterDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MonsterRarity Rarity { get; set; }
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

    public enum MonsterRarity
    {
        /// <summary>
        /// 普通
        /// </summary>
        Common,
        /// <summary>
        /// 稀有
        /// </summary>
        Rare,
        /// <summary>
        /// 史诗
        /// </summary>
        Epic,
        /// <summary>
        /// 传说
        /// </summary>
        Legendary,
        /// <summary>
        /// 神话
        /// </summary>
        Mythic
    }
}