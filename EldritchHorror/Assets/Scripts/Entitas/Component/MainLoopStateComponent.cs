#region

using System.Collections.Generic;
using EldritchHorror.Cards;
using EldritchHorror.Core;
using EldritchHorror.UI;
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