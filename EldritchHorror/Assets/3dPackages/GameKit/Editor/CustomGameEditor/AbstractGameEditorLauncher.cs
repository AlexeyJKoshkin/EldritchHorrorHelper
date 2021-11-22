using Sirenix.OdinInspector;
using UnityEngine;

namespace GameKit.CustomGameEditor
{
    public abstract class AbstractGameEditorLauncher : ScriptableObject
    {
        public string Description;
        public abstract bool IsWork { get; }
        public virtual string EditorName => name;

        [Button, HideIf("IsWork")]
        public abstract void Lunch();

        [Button, ShowIf("IsWork")]
        public abstract void Stop();
    }
}