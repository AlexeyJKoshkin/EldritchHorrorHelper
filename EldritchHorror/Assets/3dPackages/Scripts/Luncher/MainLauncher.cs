using Entitas;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    public class MainLauncher : SceneContext
    {
        [SerializeField] private EldritchHorrorCoreSystemSOInstaller eldritchHorrorCoreSystemSoInstaller;

        protected override void RunInternal()
        {
            PostResolve += OnPostResolveHandler;
            base.RunInternal();
        }

        private Feature _updateExecute;
        private Feature _fixedUpdateExecute;

        private void OnPostResolveHandler()
        {
            PostResolve -= OnPostResolveHandler;

            var launcher = Container.Resolve<IEldritchHorrorlLuncher>();
            CreateUpdate(launcher);
        }


        private void CreateUpdate(IEldritchHorrorlLuncher launcher)
        {
            List<ISystem> updateSystem = new List<ISystem>();
            foreach (var type in eldritchHorrorCoreSystemSoInstaller.UpdateSystem)
            {
                var system = this.Container.Resolve(type) as ISystem;
                updateSystem.Add(system);
            }

            _updateExecute = launcher.BuildUpdate(updateSystem);
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