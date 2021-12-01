using EldritchHorror.Data.Provider;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace EldritchHorror
{
    [CreateAssetMenu(menuName = "Installers/EldritchDataInstaller", fileName = "EldritchDataInstaller")]
    public class EldritchDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private EldritchHorrorDataStorage _dataStorage;

        public override void InstallBindings()
        {
            _dataStorage.Collection.ForEach(e => Container.BindInterfacesTo(e.GetType()).FromInstance(e).AsSingle());
            Container.BindInterfacesTo<EldritchHorrorDataStorage>().FromInstance(_dataStorage).AsSingle();

            Container.BindInterfacesTo<LocalDataBoxStorage>().AsSingle();
        }
    }
}