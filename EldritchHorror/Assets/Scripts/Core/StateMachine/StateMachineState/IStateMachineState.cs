#region

using Entitas;
using System;

#endregion

namespace EldritchHorror.Core
{
    public interface IStateMachineState<T> :IStateInfoProvider, IComparable where T : class, IEntity
    {
        void Exit(T stateEntity);
        void Enter(T stateEntity);
    }
    
    public interface IStateInfoProvider
    {
       
    }
}