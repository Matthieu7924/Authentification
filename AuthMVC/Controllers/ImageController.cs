using AuthMVC.Models;

namespace AuthMVC.Controllers
{
    public class ImageController 
    {
        private readonly PathController pathController;

        public ImageController(PathController pathService)
        {
            this.pathController = pathService;
        }

        public async Task<Image> UploadAsync(Image image)
        {
            var uploadsPath = pathController.GetUploadsPath();

            var imageFile = image.File;
            var imageFileName = GetRandomFileName(imageFile.FileName);
            var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

            using (var fs = new FileStream(imageUploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fs);
            }

            image.Name = imageFile.FileName;
            image.Path = pathController.GetUploadsPath(imageFileName, withWebRootPath: false);

            return image;
        }

        public void DeleteUploadedFile(Image? image)
        {
            if (image == null)
            {
                return;
            }
            var imagePath = pathController.GetUploadsPath(Path.GetFileName(image.Path));

            if (File.Exists(imagePath))
                File.Delete(imagePath);
        }






        private string GetRandomFileName(string filename)
        {
            return Guid.NewGuid() + Path.GetExtension(filename);
        }

    }
}
