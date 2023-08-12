using Game.Core.Mortal;
using Game.Managers;
using UnityEngine;

namespace Game.Data
{
   public static class DataManager
   {
      public static MoodsDataContainer GetMoodsContainer()
      {
         var moodsContainer = Resources.Load<MoodsDataContainer>(ResourceHelper.MortalPath + ResourceHelper.MoodsContainer);

         if (moodsContainer != null)
            return moodsContainer;

         Debug.LogError("No moods container was found in resources!");
         return null;
      }
   }
}
