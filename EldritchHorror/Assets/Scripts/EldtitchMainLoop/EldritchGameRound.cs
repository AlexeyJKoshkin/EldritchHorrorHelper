using EldritchHorror.Core;
using EldritchHorror.GameplayStateMachine;
using System.Collections.Generic;

namespace EldritchHorror
{
    public class EldritchGameRound : IStateMachine // StatesHolder<IGameRoundPhase>
    {
        private GameLoopContext GameLoopContext { get; }


        private List<IGameRoundPhase> Phases;

        private IGameRoundPhase CurrentPhase => _currentPhaseIndex < Phases.Count ? Phases[_currentPhaseIndex] : null;
        private int _currentPhaseIndex;

        public EldritchGameRound(IGameRoundPhase[] states) 
        {
            Phases = new List<IGameRoundPhase>(states);
        }


        public void Start()
        {
            _currentPhaseIndex = -1;
            NextPhase();
        }

        public void Stop()
        {
            _currentPhaseIndex = -1;
            
        }

        void NextPhase()
        {
            _currentPhaseIndex++;
            GameLoopContext.masterEntityEntity.RemoveCurrentGamePhase();
            
            var nextPhase = CurrentPhase;
            if(nextPhase!= null)
                GameLoopContext.masterEntityEntity.ReplaceCurrentGamePhase(nextPhase);


        }
    }
}