using Zenject;

namespace EldritchHorrorEditorEcosystem {
    public abstract class BaseCustomEditorInstaller : ScriptableObjectInstaller
    {
        public virtual void Initialize(DiContainer diContainer)
        {
            diContainer.Inject(this);
        }
    }
}