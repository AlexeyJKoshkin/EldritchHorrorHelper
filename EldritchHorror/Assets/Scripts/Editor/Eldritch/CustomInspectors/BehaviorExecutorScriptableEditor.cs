using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace EldritchHorror
{
    [CustomEditor(typeof(BehaviorExecutorScriptable))]
    public class BehaviorExecutorScriptableEditor : OdinEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}