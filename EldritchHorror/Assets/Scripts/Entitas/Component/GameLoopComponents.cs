using EdlritchDefs.GamePlayDefs;
using EldritchHorror.GameplayStateMachine;
using EldritchHorror.UI;
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

    [GameLoop]
    public class OmenUIComponent : IComponent
    {
        public OmenViewUI View;

        public void SetPlace(int place)
        {
            if(View == null) return;
            View.CurrentPlace = place;
        }
    }

    [GameLoop]
    public class OmenStateComponent : IComponent
    {
        public int CurrentState;

        public OmenType Omen {
            get
            {
                if (CurrentState < 0) return OmenType.Green;
                if (CurrentState >= _loopStates.Length) return OmenType.Green;
                return _loopStates[CurrentState];
            }
        }
        private static OmenType[] _loopStates = new OmenType[4]{OmenType.Green, OmenType.Blue, OmenType.Blue, OmenType.Red};

        public int GetNext()
        {
            if (CurrentState == _loopStates.Length - 1) return 0;
            return CurrentState + 1;
        }

        public int GetPreviousNext()
        {
            if (CurrentState == 0) return _loopStates.Length - 1;
            return CurrentState - 1;
        }
    }

    /// <summary>
    /// Содержит все данные для главного цикла
    /// </summary>
    [GameLoop, Unique]
    public class MasterEntityComponent : IComponent
    {
    }

    [GameLoop, Unique]
    public class MainWindowUIComponent : WindowBindingComponent<MainGameUIWindow>
    {
        
    }

    /// <summary>
    /// Текущая фаза хода
    /// </summary>
    [GameLoop]
    public class CurrentGamePhaseComponent : StateHolderComponent<IGameRoundPhase, GameLoopEntity>,IGameRoundPhase, IComponent
    {
        public int CompareTo(object obj)
        {
            return Current?.CompareTo(obj) ?? 0;
        }
    }
    
    [GameLoop, Unique]
    public class TurnCounterComponent : IComponent
    {
        public int Turn;
    }

    [GameLoop]
    public class PhaseReadyComponent : IComponent
    {
    }
}