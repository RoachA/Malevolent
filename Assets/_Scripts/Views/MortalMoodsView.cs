using System;
using System.Collections.Generic;
using System.Linq;
using Game.Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Core.Mortal
{
    [ExecuteAlways]
    public class MortalMoodsView : MonoBehaviour, IHaveMoods
    {
        public MortalMoodsData MoodsData { get; set; }
        private Dictionary<MoodType, MoodEntryModifier> _moodModifiersData;
        
        [SerializeField, ReadOnly] private float _energy, _bladder, _hunger, _fun, _hygiene, _luck;
 

        private void Start()
        {
            InitMoodData();
            LoadBaseMoodModifiers();
        }
        
        private void LoadBaseMoodModifiers()
        {
            var data = DataManager.GetMoodsContainer();
            _moodModifiersData = new Dictionary<MoodType, MoodEntryModifier>();
            
            _moodModifiersData = data.MoodInfo
                .GroupBy(info => info.Mood)
                .ToDictionary(group => group.Key, group => group.First());

            foreach (var key in _moodModifiersData)
            {
                Debug.Log(key.Value.Mood + " has a decimation value of " + key.Value.DecimationPerSecond);
            }
        }

        public void HandleDefaultMoodDecay()
        {
            //default decay
            foreach (MoodType moodType in Enum.GetValues(typeof(MoodType)))
            {
                _moodModifiersData.TryGetValue(moodType, out var minus);
                var currentVal = GetMoodValueOfType(moodType);
                SetMood(moodType, currentVal - minus.DecimationPerSecond);
            }
            
            //new updates -> here I wait for news from any task completions if there is any, apply here
        }
        
        public void InitMoodData(MortalMoodsData data = default)
        {
            if (data == default || data == null)
            {
                MoodsData = new MortalMoodsData();
                foreach (MoodType moodType in Enum.GetValues(typeof(MoodType)))
                {
                    MoodsData.Data[moodType] = 100; // generic val
                }
                
                UpdateComponentValues();
                return;
            }

            MoodsData = data;
            UpdateComponentValues();
        }

        public void SetMood(MoodType type, float val)
        {
            MoodsData.SetMood(type, val);
            UpdateComponentValues();
        }

        public MortalMoodsData GetAllMoods()
        {
            return MoodsData;
        }

        public float GetMoodValueOfType(MoodType type)
        {
          return MoodsData.GetMood(type);
        }

        private void UpdateComponentValues()
        {
            _energy = MoodsData.GetMood(MoodType.Energy);
            _bladder = MoodsData.GetMood(MoodType.Bladder);
            _fun = MoodsData.GetMood(MoodType.Fun);
            _hygiene = MoodsData.GetMood(MoodType.Hygiene);
            _hunger = MoodsData.GetMood(MoodType.Hunger);
            _luck = MoodsData.GetMood(MoodType.Luck);
        }
    }
}