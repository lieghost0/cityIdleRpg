using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Entities
{
    public class Player : Creature
    {
        public List<BagItem> bagItems;
        public Player(int id, string name, int level, float hp, List<BagItem> bagItems) : base(id, name, level, hp)
        {
            this.bagItems = bagItems;
        }
    }
}
