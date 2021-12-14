#region

using System.IO;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace EldritchHorror.UserProfile
{
    public interface IJsonFileOperation
    {
        void Save(string path, string json);

        Task<string> LoadText(string path);
    }

    public class JsonFileOperation : IJsonFileOperation
    {
        public Task<string> LoadText(string path)
        {
            if (!File.Exists(path))
            {
                return Task.FromResult<string>(null);
            }

            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEndAsync();
            }
        }

        public void Save(string path, string json)
        {
            Thread thread = new Thread(o =>
                                       {
                                           if (!File.Exists(path))
                                           {
                                               File.Create(path);
                                           }

                                           File.WriteAllText(path, json);
                                       });
            thread.Start();
        }
    }
}