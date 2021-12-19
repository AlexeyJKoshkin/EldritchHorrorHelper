using EldritchHorror.UserProfile;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EldritchHorror.UI
{
    public class StartMenuUIWindow : EldritchWindow
    {
        [SerializeField] private Button _statBtn;
        private MainLoopEntity _entity;

        public void ShowSaves(IUserSaveProfileStorage storage, MainLoopEntity createEntity)
        {
            // создатькнопки для отображения сейвов
            _entity = createEntity;
            _statBtn.onClick.AddListener(() => { OnSelectSaves(storage.Current.UserProfileData); });
        }


        void OnSelectSaves(IUserProfileData userProfileData)
        {
            _entity.ReplaceUserProfile(userProfileData);
            _entity.ReplacePlayerRole(true, true);
            _entity.isIsReady = true;
        }
    }
}