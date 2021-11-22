using EldritchHorror.Data.Provider;
using EldritchHorrorEditorEcosystem;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorror
{
    [CustomEditor(typeof(DataBox),true)]
    public class BaseDataBoxInspectorEditor : OdinEditor
    {
        private SubConfigsEditorFacade<ScriptableObject> _defenitions;
        protected override void OnEnable()
        {
            base.OnEnable();
            GameKit.Editor.EditorUtils.FixMissingScript(target);
            Init(EditorUtils.FindAsset<EldritchHorrorEditorEcosystemLauncher>()?.Current);
        }

        private void Init(IEldritchHorrorEditorEcosystem current)
        {
            if(current == null) return;
            ISubScriptableFactory factory = new DefaultSubScriptableFactory(((DataBox)target).ObjectType);
            _defenitions = new SubConfigsEditorFacade<ScriptableObject>(serializedObject, serializedObject.FindProperty("_collection"),"Deinittion", factory);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _defenitions?.OnInspectorGUI();
        }
    }
}