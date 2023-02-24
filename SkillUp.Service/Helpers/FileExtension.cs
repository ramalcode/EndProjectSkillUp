using Microsoft.AspNetCore.Http;
using NReco.VideoInfo;

namespace SkillUp.Service.Helpers
{
    public static class FileExtension
    {
        public static bool CheckFileType(this IFormFile file, string type) => file.ContentType.Contains(type);

        public static bool CheckFileSize(this IFormFile file, int kb) => kb * 1024 > file.Length;

        static string ChangeFileName(string oldName)
        {
            string extension = oldName.Substring(oldName.LastIndexOf('.'));
            if (oldName.Length < 32)
            {
                oldName = oldName.Substring(0, oldName.IndexOf('.'));
            }
            else
            {
                oldName = oldName.Substring(0, 31);
            }
            string newName = Guid.NewGuid() + oldName + extension;
            return newName;
        }

        public static string SaveFile(this IFormFile file, string path)
        {
            string fileName = ChangeFileName(file.FileName);
            using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return fileName;
        }

        public static void DeleteFile(this string file, string root, string folder)
        {
            string path = Path.Combine(root, folder, file);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static string CheckValidate(this IFormFile file, string type, int kb)
        {
            string result = "";
            if (!CheckFileType(file, type))
            {
                result += $"{file.FileName} file type must be {type}.";
            }
            if (!CheckFileSize(file, kb))
            {
                result += $"{file.FileName} file memory must be {kb} kilobayt";
            }
            return result;
        }

        public static TimeSpan VideoDuration(string filepath)
        {
            var probe = new FFProbe();
            var videoinfo = probe.GetMediaInfo(filepath);   
            var lectureduration = TimeSpan.FromSeconds(videoinfo.Duration.TotalSeconds);
            return lectureduration;

        }


        public static string ConvertTime(this TimeSpan duration)
        {
            string convert = string.Format("{0:%h}hr {0:%m} min", duration);
            return convert;
        }
    }
}
