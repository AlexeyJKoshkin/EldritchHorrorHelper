using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    [CreateAssetMenu(menuName = "Installers/GameLoopInstaller", fileName = "GameLoopInstaller")]
    public class GameLoopScriptableInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            HashSet<Type> types = new HashSet<Type>();
            StateMachineTypesProvider.AllStateMachineType().ForEach(e => types.Add(e));
            StateMachineTypesProvider.AllStatesMachineType().ForEach(e => types.Add(e));

            types.ForEach(e => Container.BindInterfacesTo(e).AsSingle());
        }
    }
}