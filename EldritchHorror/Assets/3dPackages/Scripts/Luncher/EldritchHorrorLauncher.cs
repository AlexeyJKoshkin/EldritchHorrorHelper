using Entitas;
using System.Collections.Generic;

namespace EldritchHorror
{
    public interface IEldritchHorrorlLuncher
    {
        Feature BuildUpdate(List<ISystem> updateSystem);
    }


    public class EldritchHorrorLauncher : IEldritchHorrorlLuncher
    {
        public Feature BuildUpdate(List<ISystem> systems)
        {
            var result = new Feature("CoreSystems");
            foreach (var system in systems)
            {
                result.Add(system);
            }
            result.Initialize();
            return result;
        }
    }
}