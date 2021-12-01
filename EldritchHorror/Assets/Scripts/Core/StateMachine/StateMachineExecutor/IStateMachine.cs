using System;

namespace EldritchHorror.Core
{
    public interface IStateMachine
    {
        bool IsWorking { get; }
        event Action FinishWorkEvent;
        void LogStateMachine();
        void Start();
        void Stop();
    }

    public interface ICycleStateMachine : IStateMachine
    {
    }

    public interface IOrderStateMachine : IStateMachine
    {
    }

    public interface IPrepareGameStateMachine : IOrderStateMachine
    {
    }
}