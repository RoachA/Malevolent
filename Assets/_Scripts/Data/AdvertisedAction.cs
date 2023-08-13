using System;
using Game.Core.Mortal;
using UnityEngine;

namespace Game.Core.Room
{
    [Serializable]
    public class AdvertisedAction
    {
        public string ActionName = "Generic Action";
        public ActionYieldData[] ActionYields;
        public float ActionDuration;
        public Vector3 ActionPos;

        public AdvertisedAction()
        {
        }

        public AdvertisedAction(string actionName, ActionYieldData[] actionYields, float actionDuration, Vector3 actionPos)
        {
            ActionName = actionName;
            ActionYields = actionYields;
            ActionDuration = actionDuration;
            ActionPos = actionPos;
        }

        [Serializable]
        public struct ActionYieldData
        {
            public MoodType TargetMood;
            public float Value;
        }
    }
}

