using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace EldritchHorror.Entitas.Components
{
    [MainLoop, Unique]
    public class MainLoopStateComponent : IComponent
    {
        public IGameLoopState CurrentState;
    }


    [MainLoop, MythosCard]
    public class IsReady : IComponent
    {
    }
}