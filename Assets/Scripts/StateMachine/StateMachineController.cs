using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public class StateMachineController: MonoBehaviour
    {
        [Header("Available States")]
        [SerializeField] private List<BaseState> _addedStates;
        
        [Header("Initial state")]
        [SerializeField] private BaseState _startState;

        private List<BaseState> _states;
        private BaseState _currentState;
        
        private void Start()
        {
            _states = _addedStates;
            if (_startState == null)
                throw new ArgumentNullException("Base state not set");
            
            TryRunState(_startState);
        }

        private void Update()
        {
            if(_currentState != null)
                _currentState.OnUpdateState();
        }

        public bool TryRunState(BaseState baseState)
        {
            if (!TryGetState(baseState.GetType(), out var receivedState))
                return false;
            
            RunStart(receivedState);
            return true;
        }
        
        public bool TryRunState<T>() where T : BaseState
        {
            if (!TryGetState<T>(out var receivedState))
                return false;

            RunStart(receivedState);
            return true;
        }

        private bool TryGetState<T>(out BaseState receivedState) where T: BaseState 
            => TryGetState(typeof(T), out receivedState);
        
        private bool TryGetState(Type requiredItemType, out BaseState receivedState)
        {
            receivedState = _states.First(state => state.GetType() == requiredItemType);
            return receivedState != null;
        }

        private void RunStart(BaseState state)
        {
            if(_currentState != null)
                _currentState.OnExitState();

            _currentState = state;
            _currentState.OnEnterState();
        }
    }
}