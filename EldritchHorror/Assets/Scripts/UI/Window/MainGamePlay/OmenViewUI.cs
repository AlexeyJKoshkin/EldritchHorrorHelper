#region

using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace EldritchHorror.UI
{
    public class OmenViewUI : MonoBehaviour
    {
        [SerializeField, GameKit.ReadOnly] private int _currentTokenPlace = -1;
        [SerializeField] private RectTransform[] _omenImage;

        [SerializeField] private RectTransform _omenTokenView;

        public int CurrentPlace
        {
            get => _currentTokenPlace;
            set => SetTo(value);
        }

        [Button]
        private void SetTo(int place)
        {
            if (_currentTokenPlace == place)
            {
                return;
            }

            if (place < 0)
            {
                return;
            }

            if (place >= _omenImage.Length)
            {
                return;
            }

            _currentTokenPlace      = place;
            _omenTokenView.position = _omenImage[place].position;
        }
    }
}