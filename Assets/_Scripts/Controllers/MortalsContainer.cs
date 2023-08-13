using System.Collections.Generic;
using Game.Core.Mortal;
using UnityEngine;
using Zenject;

namespace Game
{
    public class MortalsContainer : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<MortalController> _activeMortals;
        
        public static MortalsContainer Instance { get; private set; }
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); // Ensures only one instance exists
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void RegisterMortal(MortalController thisMortal)
        {
            _activeMortals.Add(thisMortal);
        }

        public List<MortalController> GetActiveMortals()
        {
            return _activeMortals;
        }

        public void Initialize()
        {
            _activeMortals = new List<MortalController>();
        }
    }
}