using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    /// <summary>
    /// Install entitas systems 
    /// </summary>
    [CreateAssetMenu(menuName = "Installers/EntitasSystem", fileName = "EldritchHorrorInstaller")]
    public class EldritchHorrorCoreSystemSOInstaller : ScriptableObjectInstaller
    {
        public IEnumerable<Type> UpdateSystem => _updateSystems;

        private List<Type> _updateSystems = new List<Type>() { };
        
        public override void InstallBindings()
        {
            /*var shared = Contexts.sharedInstance;
            BindContexts(shared);
            BindSystems();
            Container.BindInterfacesTo<EntitaslLuncher>().AsSingle();*/
            
            
            Debug.LogError("Bind Entitas");
        }

        private void BindSystems()
        {
            foreach (var type in _updateSystems)
            {
                Container.Bind(type).AsSingle();
            }
          
        }

        /*private void BindContexts(Contexts shared)
        {
            Container.BindInstance(shared).AsSingle();
            
            Container.Bind(typeof(MainFieldContext), typeof(IContext<MainFieldEntity>)).FromInstance(shared.mainField).AsSingle();
            Container.Bind(typeof(FieldItemsContext), typeof(IContext<FieldItemsEntity>)).FromInstance(shared.fieldItems).AsSingle();
            
            Container.BindInterfacesTo<GameInputContext>().FromInstance(shared.gameInput).AsSingle();
        }*/
    }
}