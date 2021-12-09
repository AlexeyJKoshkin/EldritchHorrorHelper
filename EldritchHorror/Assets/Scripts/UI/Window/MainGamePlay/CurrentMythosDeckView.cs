using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace EldritchHorror.UI
{
    public class CurrentMythosDeckView : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("Mythos Queue")]
        private Image _backImage;
        [SerializeField, FoldoutGroup("Mythos Queue")]
        private MythosCardUIView _currentMytosPreview;
        [SerializeField, FoldoutGroup("Mythos Queue")]
        private TextMeshProUGUI _mythosCardsCounter;

        public int MythosCardCounter
        {
            set { _mythosCardsCounter.text = value.ToString(); }
        }

        public void SetCurrent(MythosCardEntity current)
        {
            _currentMytosPreview.UpdateView(current);
            _currentMytosPreview.gameObject.SetActive(current != null);
        }

        
    }
}