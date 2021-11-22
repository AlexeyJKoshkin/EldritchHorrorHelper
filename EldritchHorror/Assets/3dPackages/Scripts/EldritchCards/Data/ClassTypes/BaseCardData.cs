using UnityEngine;

namespace Editor.EldrtichHorrorEditorEcosystem.EldritchCards
{
    /// <summary>
    /// Базовый тип карты
    /// </summary>
    public abstract class BaseCardDataSO : BaseGameCartSO
    {
        public CardTypeSO TypeSettings => _type;
        [SerializeField]
        private CardTypeSO _type;
    }
}