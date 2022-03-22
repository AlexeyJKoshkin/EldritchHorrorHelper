#region

using System.Collections.Generic;
using EldritchHorror.Cards;
using Entitas;
using Entitas.CodeGeneration.Attributes;

#endregion

namespace EldritchHorror.Entitas.Components
{
    [MainLoop, Unique]
    public class MainLoopStateComponent : StateHolderComponent<IGameLoopState, MainLoopEntity>, IComponent { }

    [MainLoop, EldritchCard, GameLoop]
    public class IsReady : IComponent { }

    [MainLoop]
    public class PlayerRoleComponent : IComponent
    {
        public bool IsMaster;
        public bool IsLeader;

        public override string ToString()
        {
            return IsMaster ? $"Master Leader {IsLeader}" : $"Leader {IsLeader}";
        }
    }

    [MainLoop]
    public class GameBoxesComponent : IComponent
    {
        public List<GameBoxDef> GameBoxes;
    }

    [MainLoop]
    public class AncientCardDefinitionComponent : IComponent
    {
        public AncientCardDataDefinition AncientCard;
    }
}