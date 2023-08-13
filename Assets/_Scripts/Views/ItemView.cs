using UnityEngine;

namespace Game.Core.Room
{
    public class ItemView : MonoBehaviour, IAdvertise
    {
        [SerializeField] private string itemName; // Backing field
        [SerializeField] public AdvertisedAction[] AvailableActions;
        
        private bool _isOutOccupied = false;
        private bool _isBroken = false;

        public string ItemName
        {
            get { return itemName; }
            private set { itemName = value; }
        }

        private void OnValidate()
        {
            // Set the initial value based on the gameObject's name
            ItemName = gameObject.name;
        }
    }
}
