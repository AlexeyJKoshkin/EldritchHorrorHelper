using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;
using Entitas;
using System.Collections.Generic;

namespace EldritchHorror
{
    public interface IEldritchHorrorSceneLauncher : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        void ActivateScene();
    }

    public class EldritchHorrorSceneLauncher : IEldritchHorrorSceneLauncher
    {
        private readonly IEldritchHorrorEntitasRuntimeSystemBuilder _builder;
        private readonly IEldritchWindowUIProvider _provider;
        private readonly GameLoopContext _gameLoopContext;

        public EldritchHorrorSceneLauncher(IEldritchHorrorEntitasRuntimeSystemBuilder builder, IEldritchWindowUIProvider provider, GameLoopContext gameLoopContext)
        {
            _builder = builder;
            _provider = provider;
            _gameLoopContext = gameLoopContext;
        }

        public Feature BuildUpdate()
        {
            return _builder.BuildUpdate();
        }

        public void ActivateScene()
        {
            _gameLoopContext.isMasterEntity = true;
            _gameLoopContext.masterEntityEntity.ReplaceMainWindowUI(_provider.GetWindow<MainGameUIWindow>());
        }
    }

    public interface IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        Feature BuildUpdate();
    }

    public class EldritchHorrorEntitasRuntimeSystemBuilder : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        private readonly ISystem[] _systems;

        public EldritchHorrorEntitasRuntimeSystemBuilder(ISystem[] systems)
        {
            _systems = systems;
        }

        public Feature BuildUpdate()
        {
            var result = new Feature("CoreSystems");
            foreach (var system in _systems) result.Add(system);
            result.Initialize();
            return result;
        }
    }
}