using GameKit;

namespace EldritchHorror.Cards
{
    [AllowMultiItems]
    public class DifficultTypeSO : BaseGameCartSO
    {
        [ReadOnly] public MythosDifficultType DifficultType;
    }
}