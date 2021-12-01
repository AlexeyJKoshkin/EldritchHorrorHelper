using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

namespace EldritchHorror.Entitas.Components
{
    [GameLoop, Unique]
    public class InGameMythosCardsComponent : IComponent
    {
        public List<MythosCardEntity> Draft;
        public Queue<MythosCardEntity> List;
    }

    [GameLoop, Unique]
    public class TurnCounterComponent : IComponent
    {
        public int Turn;
    }

    [GameLoop, Unique]
    public class MasterEntityComponent : IComponent
    {
    }
}