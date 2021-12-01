using EldritchHorror;
using EldritchHorror.Core;
using System;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystem : IEldritchHorrorEditorEcosystem
    {
        private readonly IGameLoopStateMachine _gameLoopStateMachine;
        private readonly EldritchHorrorEditorEcosystemGuiDrawer _gui;
        private readonly IPrepareGameStateMachine _prepareGameMachineState;

        public EldritchHorrorEditorEcosystem(IEldritchHorrorEditorEcosystemGUI[] gui, IGameLoopStateMachine gameLoopStateMachine, IPrepareGameStateMachine prepareGameMachineState)
        {
            _gameLoopStateMachine = gameLoopStateMachine;
            _prepareGameMachineState = prepareGameMachineState;
            _gui = new EldritchHorrorEditorEcosystemGuiDrawer(gui, this);
        }

        public event Action OnFinishWorkingEvent;


        public void StartWork()
        {
            Debug.LogError("Start Editor Eco System");
        }

        public void StopWork()
        {
            Debug.LogError("StopWork World");
            OnFinishWorkingEvent?.Invoke();
        }

        public void DrawGUI()
        {
            _gui.DrawGUI();
        }
    }
}