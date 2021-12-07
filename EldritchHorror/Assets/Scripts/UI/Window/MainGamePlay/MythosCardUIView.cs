using System;
using UnityEngine;
using UnityEngine.UI;

namespace EldritchHorror.UI
{
    public class MythosCardUIView : MonoBehaviour
    {
        public event Action<MythosCardUIView> OnClickEvent
        {
            add
            {
                _onClickEvent -= value;
                _onClickEvent += value;
            }
            remove { _onClickEvent -= value; }
        }

        private Action<MythosCardUIView> _onClickEvent;
        
        public bool Interactable
        {
            get => this._actionBtn.interactable;
            set => _actionBtn.interactable = value;
        }
        
        [SerializeField] 
        protected Image ImageView;

        [SerializeField]
        private Button _actionBtn;
        private void Awake()
        {
            _actionBtn.onClick.AddListener(OnClickHandler);
        }

        private void OnClickHandler()
        {
            _onClickEvent?.Invoke(this);
        }

        public void UpdateView(MythosCardEntity entity)
        {
            ClearView();
            if(entity == null) return;
            InnerUpdateView(entity);
            gameObject.SetActive(true);
        }

        protected virtual void InnerUpdateView(MythosCardEntity entity)
        {
            ImageView.sprite = entity.mythosDef.Def.FrontSprite;
        }


        protected virtual void ClearView() { }

        private void Reset()
        {
            ImageView = GetComponentInChildren<Image>(true);
            _actionBtn = GetComponentInChildren<Button>(true);
        }
    }
}