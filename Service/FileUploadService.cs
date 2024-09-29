using Microsoft.Extensions.Hosting;


namespace my_orange_easyxls.Service
{
    public class FileUploadService
    {

        public static readonly string ext = ".pdf,.docx,.xlsx,.jpg,.jpeg,.png,.gif,.wps";
        public static readonly string[] aryExt = ext.Split(",");
        public static readonly string UploadPath = "/upload/";

        private readonly IWebHostEnvironment? _hostEnvironment;
        //IWebHostEnvironment Environment
        public FileUploadService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;

        }

        public string GetTemplateContent(string fileName)
        {

            string path = _hostEnvironment.WebRootPath + "/template/" + fileName + ".cs.html";
            string content = System.IO.File.ReadAllText(path);
            return content;

        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <returns></returns>
        public string GetFileName()
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            System.Random r = new Random();
            int i = r.Next(1, 9999);
            string rnd = i.ToString().PadLeft(4, '0');
            return fileName + rnd;
        }

        public string GetFilePath()
        {
            string path = _hostEnvironment.WebRootPath;
            string subPath = UploadPath + DateTime.Now.ToString("yyyyMMdd");
            string localPath = path + subPath;

            if (!System.IO.Directory.Exists(localPath))
            {
                System.IO.Directory.CreateDirectory(localPath);
            }

            return subPath;

        }

        public string? ErrorInfo { get; set; }


        public string GetExtName(string fileName)
        {

            string extName = ".jpg";
            foreach (var a in aryExt)
            {
                if (fileName.ToLower().EndsWith(a))
                {
                    extName = a;
                    break;
                }
            }

            return extName;

        }

        public string Create(IFormFile file)
        {
            string fileName = file.FileName;
            string extName = this.GetExtName(fileName);


            if (string.IsNullOrEmpty(extName))
            {

                this.ErrorInfo = "文件类型不支持，只支持：" + ext;
                return "";
            }
            string aFileName = this.GetFileName() + extName;
            string relativePath = this.GetFilePath() + "/" + aFileName; // 相对路径
            string filePath = _hostEnvironment.WebRootPath + relativePath; // 获取绝对路径

            // 保存文件到指定路径
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return relativePath;
        }

    }
}
