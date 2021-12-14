#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace EldritchHorror.UI
{
    public class EndrithCardUIView : EntityMonoBehaviour<EldritchCardEntity>
    {
        [SerializeField] private Button _actionBtn;

        [SerializeField] protected Image ImageView;
        public bool Interactable
        {
            get => _actionBtn.interactable;
            set => _actionBtn.interactable = value;
        }

        private void Awake()
        {
            _actionBtn?.onClick.AddListener(OnClickHandler);
        }

        private void OnClickHandler()
        {
            if (Current == null)
            {
                return;
            }

            Current.isClick = true;
        }

        private void Reset()
        {
            ImageView  = GetComponentInChildren<Image>(true);
            _actionBtn = GetComponentInChildren<Button>(true);
        }

        protected override void UpdateView()
        {
            ImageView.sprite = Current.FrontSprite.Sprite;
            gameObject.SetActive(true);
        }

        protected override void Clear()
        {
            ImageView.sprite = Current.backSprite.Sprite;
        }

        public void ClearView()
        {
            Bind(null);
            gameObject.SetActive(false);
        }
    }
}