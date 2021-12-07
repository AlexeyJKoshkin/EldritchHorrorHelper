using EdlritchDefs.GamePlayDefs;
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

    [GameLoop, Unique]
    public class TurnCounterComponent : IComponent
    {
        public int Turn;
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

    [GameLoop, Unique]
    public class MasterEntityComponent : IComponent
    {
    }
}