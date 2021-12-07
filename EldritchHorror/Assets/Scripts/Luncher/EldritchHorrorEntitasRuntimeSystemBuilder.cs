using Entitas;
using System.Collections.Generic;

namespace EldritchHorror
{
    public interface IEldritchHorrorSceneLauncher
    {
        Feature BuildUpdate();
        void ActivateScene();
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