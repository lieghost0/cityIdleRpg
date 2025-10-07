using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Entities
{
    //强调顺序布局，内存字段紧密排列对齐
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BagItem
    {
        public ushort ItemId;
        public ushort Count;

        public static BagItem zero = new BagItem { ItemId = 0, Count = 0};

        public BagItem(int ItemId, int Count)
        {
            this.ItemId = (ushort)ItemId;
            this.Count = (ushort)Count;
        }

        public static bool operator ==(BagItem lhs, BagItem rhs)
        {
            return lhs.ItemId == rhs.ItemId && lhs.Count == rhs.Count;
        }

        public static bool operator !=(BagItem lhs, BagItem rhs)
        {
            return !(lhs == rhs);
        }

        public bool Equals(BagItem other)
        {
            return this == other;
        }

        public override bool Equals(object other)
        {
            if(other is BagItem)
            {
                return Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + this.ItemId.GetHashCode();
            hash = hash * 31 + this.Count.GetHashCode();
            return hash;
        }
    }
}
