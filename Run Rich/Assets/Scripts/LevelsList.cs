using System.Collections.Generic;
using UnityEngine;

namespace ButchersGames
{
    [CreateAssetMenu(menuName = "List/Lvls List")]
    public class LevelsList : ScriptableObject
    {
        public bool randomizedLvls;
        public List<Level> lvls;
    }
}