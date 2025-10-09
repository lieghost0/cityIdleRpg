using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Entities
{
    public class Monster : Creature
    {
        private bool isDead = false;

        public bool IsDead { get { return isDead; } }
        public Monster(int id, string name, int level, float hp) : base(id, name, level, hp)
        {

        }

        public void UpdateInfo(int id, string name, int level, float hp)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.Hp = hp;
            this.isDead = true;
        }
    }
}
