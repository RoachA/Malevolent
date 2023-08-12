using UnityEngine;

namespace Game.Core.Mortal
{
    public class MortalMoodsView : MonoBehaviour, IHaveMoods
    {
        [SerializeField] public MortalMoodsData MoodsData { get; set; }

        public void SetMood(MoodType type, int val)
        {
            MoodsData.SetMood(type, val);
        }

        public MortalMoodsData GetAllMoods()
        {
            return MoodsData;
        }

        public int GetMoodOfType(MoodType type)
        {
          return MoodsData.GetMood(type);
        }
    }
}