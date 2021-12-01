using EldritchHorror.UI;
using System.Linq;
using UnityEngine;
using Zenject;

namespace EldritchHorror.Installers
{
    public class EldrtitchHorrorUIInstaller : MonoInstaller
    {
        [SerializeField] private EldritchWindowUIStorage _storage;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EldritchWindowUIStorage>().FromInstance(_storage).AsSingle();
            foreach (var window in _storage.AllWindows.Where(o => null != o)) Container.BindInterfacesTo(window.GetType()).FromInstance(window).AsSingle();
        }
    }
}