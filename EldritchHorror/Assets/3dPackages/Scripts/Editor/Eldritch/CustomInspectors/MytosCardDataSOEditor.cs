using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorror
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(MytosCardDataSO))]
    public class MytosCardDataSOEditor : OdinEditor
    {
        private MytosCardDataSO current => target as MytosCardDataSO;
        
        private CenteredSpriteDrawer _spriteDrawer;

        protected override void OnEnable()
        {
            base.OnEnable();
            _spriteDrawer = new CenteredSpriteDrawer("Front");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            current.FrontSprite =   _spriteDrawer.DrawWithFoldout(current.FrontSprite, new Vector2(300,500));
            EditorUtility.SetDirty(current);
        }
    }
}