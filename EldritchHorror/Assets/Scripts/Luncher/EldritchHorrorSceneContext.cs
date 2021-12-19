#region

using EldritchHorror;
using System;
using Zenject;

#endregion

namespace Luncher
{
    public abstract class EldritchHorrorSceneContext<T> : SceneContext where T : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        protected static Action OnUpdate;
        protected static Action OnFixedUpdate;
        protected static Action OnLateUpdate;
        
        private Feature _fixedUpdateExecute;

        private Feature _updateExecute;

        protected override void RunInternal()
        {
            PostResolve += OnPostResolveHandler;
            base.RunInternal();
        }

        protected void OnPostResolveHandler()
        {
            PostResolve -= OnPostResolveHandler;
            LunchScene(Container.Resolve<T>());
        }

        protected virtual void LunchScene(T launcher)
        {
            CreateUpdate(launcher);
        }


        protected void CreateUpdate(T launcher)
        {
            _updateExecute = launcher.BuildUpdate();
            OnUpdate += _updateExecute.Execute;
        }


        protected virtual void OnDestroy()
        {
            OnUpdate -= _updateExecute.Execute;
        }

        private void Update()
        {
           OnUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }
    }
}