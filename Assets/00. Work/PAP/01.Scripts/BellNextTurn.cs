using System;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public class BellNextTurn : MonoBehaviour
    {
        
        private void OnMouseDown()
        {
            BattleManager.instance.PassTurn();
        }
    }
}