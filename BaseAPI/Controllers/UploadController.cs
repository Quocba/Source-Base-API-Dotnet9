using Application.IService;
using Application.Payload.Request.Uploads;
using Domain.Share.Util;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/uploads")]
    public class UploadController(ILogger<UploadController> _logger) : Controller
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadRequest request)
        {
            if (request.file == null || request.file.Length == 0)
                return BadRequest("No file uploaded.");
            try
            {
                string folderPath;

                if (request.Folder.HasValue)
                {
                    folderPath = CommonUtil.GetFolderPath(request.Folder.Value);
                }

                else if (!string.IsNullOrEmpty(request.CustomeFolder))
                {
                    if (request.CustomeFolder.Contains("..") || Path.IsPathRooted(request.CustomeFolder))
                        return BadRequest("Invalid custom path.");

                    folderPath = request.CustomeFolder;
                }

                else
                {
                    return BadRequest("Folder not specified.");
                }


                var filePath = await CommonUtil.SaveImageToRootAsync(request.file, folderPath);
                return Ok(new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                _logger.LogError("[Upload API]" + ex.Message, ex.ToString());
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
