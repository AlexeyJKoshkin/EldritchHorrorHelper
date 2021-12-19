#region

using EldritchHorror.Core;
using EldritchHorror.EntitasSystems;
using System;
using System.Collections.Generic;
using EldritchHorror.UI;
using UnityEngine;
using Zenject;

#endregion

namespace EldritchHorror
{
    /// <summary>
    ///     Install entitas systems
    /// </summary>
    [CreateAssetMenu(menuName = "Installers/EntitasSystem", fileName = "EldritchHorrorInstaller")]
    public class EldritchHorrorCoreSystemSOInstaller : ScriptableObjectInstaller
    {
        private List<Type> _updateSystems = new List<Type>
                                            {
                                                typeof(MainLoopInitializeSystem),
        
 
                                                typeof(SetClickedMythosCardToPreview),
                                                typeof(SetClickedEncounterCardToPreview),
                                                typeof(GameLoopUIUpdateSystem),
                                                typeof(TurnPhaseStateSystem),
                                                typeof(TurnPhaseSwitcherSystem),
                                                typeof(MainLoopSwitcherSystem)
                                            };
        public IEnumerable<Type> UpdateSystem => _updateSystems;

        public override void InstallBindings()
        {
            var shared = Contexts.sharedInstance;
            BindContexts(shared);
            BindSystems();
            BindDependencies();
            Container.BindInstance(this).AsSingle();
            Container.BindInterfacesTo<EldritchHorrorEntitasRuntimeSystemBuilder>().AsSingle();
        }

        private void BindDependencies()
        {
            BindUI();

            Container.Bind<MasterRolePlayerUILayoutHandler>().AsSingle();
            Container.BindInterfacesTo<MythosCardEntityGenerator>().AsSingle();
        }

        private void BindUI()
        {
            
            Container.BindInterfacesTo<EldritchWindowUIProvider>().AsSingle(); // биндим провайдер окон на уровне систем,  чтобы иметь доступ к обертке UI  
            Container.BindInterfacesTo<UiHandleDispatcher>().AsSingle();
            
            Container.BindInterfacesTo<MainMenuUIHandler>().AsSingle();
            Container.BindInterfacesTo<PrepareGamePhaseStateUiHandler>().AsSingle();
            Container.BindInterfacesTo<GameLoopGameStateUIHandler>().AsSingle();
        }

        private void BindSystems()
        {
            foreach (var type in _updateSystems) Container.BindInterfacesAndSelfTo(type).AsSingle();
        }

        private void BindContexts(Contexts shared)
        {
            Container.BindInstance(shared).AsSingle();
            foreach (var context in shared.allContexts) Container.BindInterfacesAndSelfTo(context.GetType()).FromInstance(context).AsSingle();
        }
    }
}