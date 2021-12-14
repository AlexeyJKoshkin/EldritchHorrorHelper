using EldritchHorror.GameplayStateMachine;
using Entitas;

namespace EldritchHorror.EntitasSystems
{


    public interface IEldritchUIController
    {
        void EnterGamePhase<T>(T phase, GameLoopEntity phaseEntity) where T : MainGamePlayState;
        void ExitGamePhase<T>(T phase,GameLoopEntity phaseEntity) where T : MainGamePlayState;
    }
}