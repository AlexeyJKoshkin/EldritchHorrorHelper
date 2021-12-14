#region

using EldritchHorror.Core;
using EldritchHorror.GameplayStateMachine;
using System.Collections.Generic;

#endregion

namespace EldritchHorror
{
    public class EldritchGameRound : IStateMachine // StatesHolder<IGameRoundPhase>
    {
        private int _currentPhaseIndex;


        private List<IGameRoundPhase> Phases;

        public EldritchGameRound(IGameRoundPhase[] states)
        {
            Phases = new List<IGameRoundPhase>(states);
        }

        private GameLoopContext GameLoopContext { get; }

        private IGameRoundPhase CurrentPhase => _currentPhaseIndex < Phases.Count ? Phases[_currentPhaseIndex] : null;


        public void Start()
        {
            _currentPhaseIndex = -1;
            NextPhase();
        }

        public void Stop()
        {
            _currentPhaseIndex = -1;
        }

        private void NextPhase()
        {
            _currentPhaseIndex++;
            GameLoopContext.masterEntityEntity.RemoveCurrentGamePhase();

            var nextPhase = CurrentPhase;
            if (nextPhase != null)
            {
                GameLoopContext.masterEntityEntity.ReplaceCurrentGamePhase(nextPhase);
            }
        }
    }
}