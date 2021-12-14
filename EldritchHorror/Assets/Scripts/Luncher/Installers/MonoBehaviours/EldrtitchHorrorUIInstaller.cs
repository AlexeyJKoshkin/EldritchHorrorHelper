#region

using EldritchHorror.UI;
using System;
using System.Linq;
using UnityEngine;
using Zenject;

#endregion

namespace EldritchHorror.Installers
{
    public class EldrtitchHorrorUIInstaller : MonoInstaller
    {
        [SerializeField] private EldritchWindowUIStorage _storage;

        public override void InstallBindings()
        {
            if (_storage == null)
            {
                throw new NullReferenceException("UI is Null");
            }

            BindInstance(_storage);
        }

        private void BindInstance(EldritchWindowUIStorage storage)
        {
            /*var storage = GameObject.Instantiate(_storage);
              GameObject.DontDestroyOnLoad(storage);*/

            Container.BindInterfacesTo<EldritchWindowUIStorage>().FromInstance(storage).AsSingle();
            foreach (var window in storage.AllWindows.Where(o => null != o))
                Container.BindInterfacesTo(window.GetType()).FromInstance(window).AsSingle();
            //  Container.Inject(window);
            Container.Bind<IEldritchHorrorSceneLauncher>().To<EldritchHorrorSceneLauncher>().AsSingle();
        }
    }
}