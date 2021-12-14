#region

using EldritchHorror.UserProfile;
using Entitas;
using Entitas.CodeGeneration.Attributes;

#endregion

namespace EldritchHorror.Entitas.Components
{
    [MainLoop, Unique]
    public class UserProfileComponent : IComponent, IUserProfileData
    {
        public IUserProfileData UserProfileData;
        public MythosCardSaveSettings MythosCards => UserProfileData.MythosCards;
        public GameCardSetSettings GameSetCards => UserProfileData.GameSetCards;
    }
}