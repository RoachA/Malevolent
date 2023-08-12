using System;
using UnityEngine;

namespace Game.Core.Mortal
{
    [CreateAssetMenu(fileName = "Moods Container", menuName = "GameData/Mortals/Moods", order = 1)]
    public class MoodsDataContainer : ScriptableObject
    {
        public MoodEntryModifier[] MoodInfo;
    }

    [Serializable]
    public struct MoodEntryModifier
    {
        public MoodType Mood;
        [Range(0.01f, 1)]
        public float DecimationPerSecond; //Decimation Per Second
    }
}