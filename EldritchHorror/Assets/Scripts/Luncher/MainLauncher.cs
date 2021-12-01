using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    public class MainLauncher : SceneContext
    {
        private Feature _fixedUpdateExecute;

        private Feature _updateExecute;

        protected override void RunInternal()
        {
            PostResolve += OnPostResolveHandler;
            base.RunInternal();
        }

        private void OnPostResolveHandler()
        {
            PostResolve -= OnPostResolveHandler;

            var launcher = Container.Resolve<IEldritchHorrorlLuncher>();
            CreateUpdate(launcher);
        }


        private void CreateUpdate(IEldritchHorrorlLuncher launcher)
        {
            _updateExecute = launcher.BuildUpdate();
        }

        private void Update()
        {
            _updateExecute.Execute();
        }

        /*private void FixedUpdate()
        {
            _fixedUpdateExecute.Execute();
        }*/
    }
}