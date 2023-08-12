using System;
using System.Collections.Generic;

namespace Game.Core.Mortal
{
    public interface IHaveMoods
    {
        public MortalMoodsData MoodsData { get; set; }

        public void SetMood(MoodType type, float val);

        public MortalMoodsData GetAllMoods();

        public void InitMoodData(MortalMoodsData data = default);

        public float GetMoodValueOfType(MoodType type);
    }
    
    [Serializable]
    public class MortalMoodsData
    {
        public Dictionary<MoodType, float> Data;

        public MortalMoodsData(Dictionary<MoodType, float> data = null)
        {
             if (data != null)
             {
                Data = data;
                return;
             }
             
             Data = new Dictionary<MoodType, float>();
        }
        
        public void SetMood(MoodType type, float val)
        {
            if (Data.ContainsKey(type))
            {
                Data[type] = val;
            }
            else
            {
                Data.Add(type, val);
            }
        }

        public float GetMood(MoodType type)
        {
            if (Data.TryGetValue(type, out float value))
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

