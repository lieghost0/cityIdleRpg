using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Entities
{
    public class Creature : Entity
    {
        public int Id;
        public string Name;
        public int Level;
        public float Hp;

        public Creature(int id, string name, int level, float hp)
        {
            Id = id;
            Name = name;
            Level = level;
            Hp = hp;
        }

        public virtual void Dead()
        {

        }
    }
}
