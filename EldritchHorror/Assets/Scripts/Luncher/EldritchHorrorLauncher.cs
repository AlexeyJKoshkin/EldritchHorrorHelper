using Entitas;
using System.Collections.Generic;

namespace EldritchHorror
{
    public interface IEldritchHorrorlLuncher
    {
        Feature BuildUpdate();
    }


    public class EldritchHorrorLauncher : IEldritchHorrorlLuncher
    {
        private readonly ISystem[] _systems;

        public EldritchHorrorLauncher(ISystem[] systems)
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