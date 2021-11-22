using Editor.EldrtichHorrorEditorEcosystem.EldritchCards.Data;
using GameKit;
using GameKit.Editor;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    [AllowMultiItems]
    public class DifficultTypeSO : BaseGameCartSO
    {
        [ReadOnly]
        public MythosDifficultType DifficultType;
    }
}