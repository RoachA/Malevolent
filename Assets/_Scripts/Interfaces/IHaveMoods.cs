using System.Collections.Generic;

namespace Game.Core.Mortal
{
    public interface IHaveMoods
    {
        public MortalMoodsData MoodsData { get; set; }
    }
    
    public abstract class MortalMoodsData
    {
        public Dictionary<MoodType, int> MoodsData;

        public void SetMood(MoodType type, int val)
        {
            if (MoodsData.ContainsKey(type))
            {
                MoodsData[type] = val;
            }
            else
            {
                MoodsData.Add(type, val);
            }
        }

        public int GetMood(MoodType type)
        {
            if (MoodsData.TryGetValue(type, out int value))
            {
                return value;
            }
            else
            {
                return 0; // Default value
            }
        }
    }

    public enum MoodType
    {
        Hygiene = 0,
        Bladder = 1,
        Energy = 2,
        Fun = 3,
        Hunger = 4,
        Luck = 5,
    }
}

