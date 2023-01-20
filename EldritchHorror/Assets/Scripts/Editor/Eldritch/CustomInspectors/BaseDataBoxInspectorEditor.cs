#region

using EldritchHorror.Data.Provider;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    [CustomEditor(typeof(DataBox), true)]
    public class BaseDataBoxInspectorEditor : OdinEditor
    {
        private SubConfigsEditorFacade<ScriptableObject> _defenitions;

        protected override void OnEnable()
        {
            base.OnEnable();
            EditorUtils.FixMissingScript(target);
          //  ISubScriptableFactory factory = new DefaultSubScriptableFactory(((DataBox) target).ObjectType);
            _defenitions = new SubConfigsEditorFacade<ScriptableObject>(serializedObject, serializedObject.FindProperty("_collection"), "Definition");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _defenitions?.OnInspectorGUI();
        }
    }
}