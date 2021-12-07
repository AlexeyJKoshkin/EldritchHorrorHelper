using EldritchHorror;
using System;
using System.Collections.Generic;
using Zenject;

namespace Luncher
{
    public abstract class EldritchHorrorSceneContext<T> : SceneContext where T : IEldritchHorrorEntitasRuntimeSystemBuilder
    {
        private Feature _fixedUpdateExecute;

        private Feature _updateExecute;
        
        protected override void RunInternal()
        {
            PostResolve += OnPostResolveHandler;
            base.RunInternal();
        }

        protected  void OnPostResolveHandler()
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
        }

        private void Update()
        {
            _updateExecute.Execute();
        }
    }
}