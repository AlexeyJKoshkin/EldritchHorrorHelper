using EldritchHorror.EntitasSystems;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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
                                                typeof(GameLoopInitializeSystem),
                                                
                                               
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
            Container.BindInterfacesTo<EldritchHorrorEntitasRuntimeSystemBuilder>().AsSingle();
        }

        private void BindDependencies()
        {
            Container.BindInterfacesTo<MythosCardEntityGenerator>().AsSingle();
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