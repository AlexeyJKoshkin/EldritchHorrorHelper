using Sirenix.OdinInspector;
using Zenject;

namespace GameKit.EditorContext
{
   // [HideMonoScript]
    public abstract class BaseCustomEditorInstaller : ScriptableObjectInstaller
    {
        public virtual void Initialize() { }
    }
}

