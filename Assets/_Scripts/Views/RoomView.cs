using System.Collections.Generic;
using System.Linq;
using Game.Core.Mortal;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Core.Room
{
    public class RoomView : MonoBehaviour
    {
        [SerializeField] private List<ItemView> _registeredItems = new List<ItemView>();
        [SerializeField] private List<AdvertisedAction> _ActionsOfTheRoom;
        [Inject] private MortalsContainer _mortalsContainer;

        public List<ItemView> GetItemsInTheRoom()
        {
            return _registeredItems;
        }

        public List<AdvertisedAction> GetAllActionsOfTheRoom()
        {
            return _ActionsOfTheRoom;
        }

        public List<AdvertisedAction> GetActionsForType(MoodType targetMood)
        {
            var targetActions = new List<AdvertisedAction>();

            foreach (var action in _ActionsOfTheRoom)
            {
                foreach (var yield in action.ActionYields)
                {
                    if (yield.TargetMood == targetMood) targetActions.Add(action);
                }
            }

            return targetActions;
        }

        public AdvertisedAction GetActionWithHighestYieldOfType(MoodType targetMood)
        {
            var actionsOfType = GetActionsForType(targetMood);
            float highestYield = 0;
            AdvertisedAction resultingAction = new AdvertisedAction();

            foreach (var action in actionsOfType)
            {
                foreach (var yield in action.ActionYields)
                {
                    if (highestYield < yield.Value)
                    {
                        highestYield = yield.Value;
                        resultingAction = action;
                    }
                }
            }

            return resultingAction;
        }

        public void UpdateRoomRegistries()
        {
            GetAllChildItems();
        }
        
        [Button]
        private void GetAllChildItems()
        {
            _registeredItems.Clear();
            _ActionsOfTheRoom.Clear();
            
            _registeredItems = GetComponentsInChildren<ItemView>(true).ToList();

            foreach (var item in _registeredItems)
            {
                foreach (var action in item.AvailableActions)
                {
                    _ActionsOfTheRoom.Add(action);
                }
                
                Debug.Log("registered a " + item.name);
            }
        }
    }
}
