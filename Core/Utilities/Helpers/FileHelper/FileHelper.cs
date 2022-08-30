using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {

                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);//seçilen dosyanın uzantısı elde edilir
                string guid = GuidHelper.GuidHelper.CreateGuid(); //benzersiz tanımlayıcı oluşturuyoruz
                string filePath = guid + extension; //dosyanın oluşturulan adını ve uzantısını yan yana getirip atıyoruz

                using (FileStream fileStream = File.Create(root + filePath))//belirtilen yolda yeni dosya olusturur ve üzerine yazar
                {
                    file.CopyTo(fileStream);//file dosyasını filestreama kopyala dedik
                    fileStream.Flush();//arabellekten siler
                    return filePath;//dosyanın yolunu geri gönderiyoruz

                }

            } 
            return null;
        }
    }
}
