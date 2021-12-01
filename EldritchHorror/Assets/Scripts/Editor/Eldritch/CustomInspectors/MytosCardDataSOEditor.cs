using EldritchHorror.Cards;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace EldritchHorror
{
    [CanEditMultipleObjects, CustomEditor(typeof(MythosCardDataDefinition))]
    public class MytosCardDataSOEditor : OdinEditor
    {
        private CenteredSpriteDrawer _spriteDrawer;
        private MythosCardDataDefinition current => target as MythosCardDataDefinition;

        protected override void OnEnable()
        {
            base.OnEnable();
            _spriteDrawer = new CenteredSpriteDrawer("Front");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            current.FrontSprite = _spriteDrawer.Draw(current.FrontSprite, new Vector2(300, 500));
            EditorUtility.SetDirty(current);
        }
    }
}