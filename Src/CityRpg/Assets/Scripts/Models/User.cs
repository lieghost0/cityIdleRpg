using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Entities
{
    public class User : Singleton<User>
    {
        public Player currentPlayer;
    }
}
