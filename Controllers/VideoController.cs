using Microsoft.AspNetCore.Mvc;
using videodownloader.Models;

namespace videodownloader.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoDownload _videoDownload;

        public VideoController(IVideoDownload videoDownload)
        {
            _videoDownload = videoDownload;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Download (string videourl)
        {
            if (string.IsNullOrEmpty(videourl))
            {
                ModelState.AddModelError("", "PLease Enter a valid URL");
                return View("Index");
            }

            var videopath = await _videoDownload.DownloadVideoAsync(videourl);
            byte[] videobytes= System.IO.File.ReadAllBytes(videopath);
            return File(videobytes, "application/octet-stream", Path.GetFileName(videopath));
        }
    }
}
