#region

using EldritchHorror.Cards;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

#endregion

namespace EldritchHorror
{
    [CanEditMultipleObjects, CustomEditor(typeof(BaseCardDataSO), true)]
    public class BaseCardDataSOEditor : OdinEditor
    {
        private CenteredSpriteDrawer _spriteDrawer;
        private BaseCardDataSO current => target as BaseCardDataSO;

        protected override void OnEnable()
        {
            base.OnEnable();
          //  _spriteDrawer = new CenteredSpriteDrawer("Front");
        }

        /*public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            current.FrontSprite = _spriteDrawer.Draw(current.FrontSprite, new Vector2(300, 500));
            EditorUtility.SetDirty(current);
        }*/
    }
}