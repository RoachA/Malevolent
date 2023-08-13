using System;
using UnityEngine;
using Zenject;

namespace Game.Core.Mortal
{
    public class MortalController : MonoBehaviour
    {
        [Inject] private SignalBus _bus;
        [Inject] private MortalsContainer _mortalsContainer;
        [SerializeField] private MortalMoodsView _moods;
        private bool isActive { get; set; }

        private float _timer = 0.0f;
        private float _interval = 1f;

        private void Awake()
        {
            _bus.Subscribe<UserJoinedSignal>(OnUserJoined);
        }

        private void Start()
        {
            //setup
            SetupMortal();
        }

        private void OnUserJoined(UserJoinedSignal obj)
        {
            Debug.Log(obj.Username);
        }

        private void SetupMortal()
        {
            if (_moods == null)
            {
                _moods = GetComponent<MortalMoodsView>() ?? _moods;
            }

            if (_moods == null)
            {
                _moods = gameObject.AddComponent<MortalMoodsView>();
            }
            
            _mortalsContainer.RegisterMortal(this);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= _interval)
            {
                if (_moods != null)
                    _moods.HandleDefaultMoodDecay();

                // Reset the timer
                _timer = 0.0f;
            }
        }
    }
}