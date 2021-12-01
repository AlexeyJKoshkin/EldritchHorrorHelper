using GameKit.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorrorEditorEcosystem
{
    public class EldritchHorrorEditorEcosystemGuiDrawer
    {
        private readonly EldritchHorrorEditorEcosystem _eldritchHorrorEditorEcosystem;
        private GridSelector<IEldritchHorrorEditorEcosystemGUI> _TabSelector;

        public EldritchHorrorEditorEcosystemGuiDrawer(IEldritchHorrorEditorEcosystemGUI[] gui, EldritchHorrorEditorEcosystem eldritchHorrorEditorEcosystem)
        {
            _eldritchHorrorEditorEcosystem = eldritchHorrorEditorEcosystem;
            _TabSelector = new GridSelector<IEldritchHorrorEditorEcosystemGUI>(false, (value, index) => new GUIContent(value.TabName), 0)
                           {
                               ItemDrawerCallback = ItemDrawerCallback
                           };
            _TabSelector.InitValues(gui);
        }

        private bool ItemDrawerCallback(IEldritchHorrorEditorEcosystemGUI element, int index, GUIContent name, bool isselected)
        {
            GUIStyle style = EditorStyles.miniButton;
            if (index == 0)
            {
                style = EditorStyles.miniButtonLeft;
            }

            if (index == _TabSelector.Count - 1)
            {
                style = EditorStyles.miniButtonRight;
            }

            return GUILayout.Toggle(isselected, name, style);
        }


        public void DrawGUI()
        {
            _TabSelector.DoSelectGUI();
            _TabSelector.CurrentValue?.DrawTabGUI();
        }
    }
}