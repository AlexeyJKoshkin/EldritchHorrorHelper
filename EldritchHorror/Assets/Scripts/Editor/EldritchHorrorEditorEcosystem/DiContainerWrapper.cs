using GameKit.EditorContext;
using Zenject;

namespace EldritchHorrorEditorEcosystem {
    public class DiContainerWrapper : IDIWrapper
    {
        public DiContainer Container { get; private set; }

        public DiContainerWrapper()
        {
            Container = new DiContainer();
        }

        public void FlushBindings()
        {
            Container?.FlushBindings();
        }

        public void ResolveRoots()
        {
            Container?.ResolveRoots();
        }

        public void BindAsSingle<T>()
        {
            if (Container == null) return;
            Container.BindInterfacesAndSelfTo<T>().AsSingle();
        }

        public T Resolve<T>()
        {
            if (Container == null) return default;
            return Container.Resolve<T>();
        }
    }
}