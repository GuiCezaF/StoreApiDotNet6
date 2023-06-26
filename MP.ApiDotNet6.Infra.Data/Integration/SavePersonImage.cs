using MP.ApiDotNet6.Domain.Integration;

namespace MP.ApiDotNet6.Infra.Data.Integration
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _filePath;

        public SavePersonImage()
        {
            _filePath = "./../../Images";
        }

        public string Save(string imageBase64)
        {
            var fileExt = imageBase64.Substring(imageBase64
                .IndexOf("/") + 1, imageBase64.IndexOf(";") - imageBase64.IndexOf("/") - 1);

            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);

            var imgBytes = Convert.FromBase64String(base64Code);

            var fileName = Guid.NewGuid().ToString() + "." + fileExt;

            using (var imageFile = new FileStream(_filePath + "/" + fileName, FileMode.Create))
            {
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
            }

            return _filePath + "/" + fileName;
        }
    }
}