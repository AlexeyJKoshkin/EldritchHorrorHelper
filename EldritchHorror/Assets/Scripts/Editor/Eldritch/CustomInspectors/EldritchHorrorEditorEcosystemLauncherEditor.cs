using EldritchHorrorEditorEcosystem;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorror
{
    [CustomEditor(typeof(EldritchHorrorEditorEcosystemLauncher), true)]
    public class EldritchHorrorEditorEcosystemLauncherEditor : OdinEditor
    {
        private IEldritchHorrorEditorEcosystem current => (target as EldritchHorrorEditorEcosystemLauncher).Current;

        public override void OnInspectorGUI()
        {
            /*if (current!= null)
            {
                if (GUILayout.Button("Stop"))
                {
                    current.StopWork();
                    return;
                }
                current.DrawGUI();
            }
            else*/
            {
                base.OnInspectorGUI();
            }
        }
    }
}