#region

using EldritchHorror;
using EldritchHorror.UserProfile;

#endregion

namespace EldritchHorrorEditorEcosystem
{
    public static class UserSaveProfileStorageTest
    {
        public static void DoFirstTest(IUserSaveProfileStorage userSaveProfileStorage)
        {
            LogTotalSaves(userSaveProfileStorage);
            LogSave(userSaveProfileStorage.Current);
        }


        private static void LogTotalSaves(IUserSaveProfileStorage userSaveProfileStorage)
        {
            foreach (var save in userSaveProfileStorage.AllSaves) LogSave(save);
        }

        private static void LogSave(IUserProfileSave save)
        {
            HLogger.TempLog(save.Name);
            HLogger.Log(save.UserProfileData.MythosCards.ToString());
        }
    }
}