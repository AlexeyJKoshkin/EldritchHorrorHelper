#region

using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace EldritchHorror.UI
{
    public class CurrentCardDeckView : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("Mythos Queue")]
        private Image _backImage;
        [SerializeField, FoldoutGroup("Mythos Queue")]
        private TextMeshProUGUI _cardsCounter;
        [SerializeField, FoldoutGroup("Mythos Queue")]
        public EndrithCardUIView CurrentCardPreview;

        public int CardCounter
        {
            set => _cardsCounter.text = value.ToString();
        }
    }
}