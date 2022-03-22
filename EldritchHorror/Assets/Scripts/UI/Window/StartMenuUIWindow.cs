
using EldritchHorror.UserProfile;
using UnityEngine;
using UnityEngine.UI;


namespace EldritchHorror.UI
{
    public class StartMenuUIWindow : EldritchWindow
    {
        private MainLoopEntity _entity;
        [SerializeField] private Button _statBtn;

        public void ShowSaves(IUserSaveProfileStorage storage, MainLoopEntity createEntity)
        {
            // создать кнопки для отображения сейвов
            _entity = createEntity;
            _statBtn.onClick.AddListener(() => { OnSelectSaves(storage.Current.UserProfileData); });
        }


        private void OnSelectSaves(IUserProfileData userProfileData)
        {
            _entity.ReplaceUserProfile(userProfileData);
            _entity.ReplacePlayerRole(true, true);
            _entity.isIsReady = true;
        }
    }
}