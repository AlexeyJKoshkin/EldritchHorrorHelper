using Editor.EldrtichHorrorEditorEcosystem.EldritchCards;
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
            GameKit.Editor.EditorUtils.FixMissingScript(target);
            _cardType = new SubConfigsEditorFacade<MythosCardTypeSO>(serializedObject, serializedObject.FindProperty("_collection"),"Тип");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _cardType.OnInspectorGUI();
        }

    }
}