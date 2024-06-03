using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;

namespace TaakAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("uploadImageFile")]
        public async Task<IActionResult> UploadImageFile(IFormFile file, [FromQuery] int userId)
        {
            try
            {
                string filePath = await _fileService.UploadImageFile(file, userId);

                return Ok(new { message = "Archivo cargado con éxito.", filePath });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet("getProfileImage/{userId}")]
        public async Task<IActionResult> GetProfileImage(int userId)
        {
            try
            {
                var (fileData, fileType) = await _fileService.GetProfileImage(userId);
                return File(fileData, fileType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

