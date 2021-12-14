using EldritchHorror.Entitas.Components;
using EldritchHorror.GameplayStateMachine;
using Entitas;
using GameKit.Editor;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EldritchHorror.EntitasSystems
{
    public class UIControllerHandlerComposite : IExecuteSystem, IEldritchUIController
    {
        private readonly AbstractRolePlayerUILayoutHandler _defaultRole;
        private readonly AbstractRolePlayerUILayoutHandler _masterRoleUI;
        private AbstractRolePlayerUILayoutHandler _leaderRoleUI;
        readonly List<AbstractRolePlayerUILayoutHandler> _roleLayouts = new List<AbstractRolePlayerUILayoutHandler>(3);

        private readonly IGroup<MainLoopEntity> _group;

        public UIControllerHandlerComposite(Contexts context, MasterRolePlayerUILayoutHandler masterRolePlayerUiLayoutHandler, DefaultRolePlayerUILayoutHandler defaultRolePlayerUiLayoutHandler, Contexts contexts)
        {
            _group                 =  context.mainLoop.GetGroup(Matcher<MainLoopEntity>.AllOf(MainLoopMatcher.PlayerRole, MainLoopMatcher.IsReady));
            _defaultRole           =  defaultRolePlayerUiLayoutHandler;
            _masterRoleUI          =  masterRolePlayerUiLayoutHandler;
            _group.OnEntityAdded   += GroupOnOnEntityAdded;
            _group.OnEntityUpdated += UpdateHandlerList;
            _roleLayouts.Add(_defaultRole);
        }

        private void UpdateHandlerList(IGroup<MainLoopEntity> @group, MainLoopEntity entity, int index, IComponent previouscomponent, IComponent newcomponent)
        {
            var role = (PlayerRoleComponent) newcomponent;
            if (_roleLayouts.Count > 1)
            {
                for (int i = 1; i < _roleLayouts.Count; i++)
                {
                    StopListening(_roleLayouts[i]);
                }

                while (_roleLayouts.Count > 1)
                {
                    _roleLayouts.RemoveAt(_roleLayouts.Count - 1);
                }
            }

            if (role.IsLeader)
                StartListening(_leaderRoleUI);
            if (role.IsMaster)
                StartListening(_masterRoleUI);
        }

        private void GroupOnOnEntityAdded(IGroup<MainLoopEntity> @group, MainLoopEntity entity, int index, IComponent component)
        {
            _group.OnEntityAdded -= GroupOnOnEntityAdded;
            StartListening(_defaultRole);
        }


        public void Execute()
        {
            _roleLayouts.ForEach(e =>
                                 {
                                     foreach (var handler in e)
                                     {
                                         handler.Execute();
                                     }
                                 });
        }

        void StopListening(AbstractRolePlayerUILayoutHandler roleLayout)
        {
            foreach (var handler in roleLayout)
            {
                handler.StopListening();
            }
        }

        void StartListening(AbstractRolePlayerUILayoutHandler roleLayout)
        {
            foreach (var handler in roleLayout)
            {
                handler.StartListening();
            }

            _roleLayouts.Add(roleLayout);
        }

        public void EnterGamePhase<T>(T phase, GameLoopEntity phaseEntity) where T : MainGamePlayState
        {
            switch (phase)
            {
                case MythosPhase mythosPhase : _roleLayouts.ForEach(e=> e.EnterMythosPhase(phaseEntity)); break;
                case EncounterGamePhase mythosPhase : _roleLayouts.ForEach(e=> e.EnterEncounterPhase(phaseEntity)); break;
              default: HLogger.LogWarning("Unknow Phase UI Handlers");
                  break;
            }
        }

        public void ExitGamePhase<T>(T phase, GameLoopEntity phaseEntity) where T : MainGamePlayState
        {
            switch (phase)
            {
                case MythosPhase mythosPhase :        _roleLayouts.ForEach(e=> e.ExitMythosPhase(phaseEntity)); break;
                case EncounterGamePhase mythosPhase : _roleLayouts.ForEach(e=> e.ExitEncounterPhase(phaseEntity)); break;
                default:                              HLogger.LogWarning("Unknow Phase UI Handlers");
                    break;
            }
        }
    }
}