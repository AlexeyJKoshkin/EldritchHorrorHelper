using EldritchHorror.Cards;
using GameKit.Editor;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace EldritchHorror
{
    [CustomEditor(typeof(MythosCardTypesHolder))]
    public class MythosCardTypesHolderEditor : OdinEditor
    {
        private SubConfigsEditorFacade<MythosCardTypeSO> _cardType;

        protected override void OnEnable()
        {
            base.OnEnable();
            EditorUtils.FixMissingScript(target);
            _cardType = new SubConfigsEditorFacade<MythosCardTypeSO>(serializedObject, serializedObject.FindProperty("_collection"), "Тип");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _cardType.OnInspectorGUI();
        }
    }
}