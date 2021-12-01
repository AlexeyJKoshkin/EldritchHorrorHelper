using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorror
{
    public abstract class BaseDataBoxInspectorEditor<T> : OdinEditor where T : ScriptableObject
    {
        private SubConfigsEditorFacade<T> _defenitions;

        protected override void OnEnable()
        {
            base.OnEnable();
            EditorUtils.FixMissingScript(target);
            _defenitions = new SubConfigsEditorFacade<T>(serializedObject, serializedObject.FindProperty("_collection"));
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _defenitions?.OnInspectorGUI();
        }
    }
}