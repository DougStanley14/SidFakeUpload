using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using microsvc_file_management.Services;
using System.Net.Http.Headers;

namespace microsvc_file_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NDDSFilesController : ControllerBase
    {
        private readonly NDDSFilesService _NDDSFilesService;
        public NDDSFilesController(NDDSFilesService nddsFilesService)
        {
            _NDDSFilesService = nddsFilesService;
        }
        // GridFS file CRUD operations:
        //[HttpPost("FileInfo")]
        //public async Task<ActionResult<List<NDDSFileInfo>>> GetInfo([FromForm] NDDSFileSearchMetadata searchData)
        //{
        //    var fileInfo = await _NDDSFilesService.GetFileInfoAsync(searchData);
        //    if (fileInfo == null) return NotFound();

        //    return fileInfo;
        //} 

        //[HttpGet("FileInfo/{hash:length(64)}")]
        //public async Task<ActionResult<NDDSFileInfo>> GetInfoByHash(string hash)
        //{
        //    var fileInfo = await _NDDSFilesService.GetFileInfoAsync(hash);
        //    if (fileInfo == null) return NotFound();
        //    return fileInfo;
        //}

        // Download a File
        //[HttpGet("{hash:length(64)}")]
        //public async Task<ActionResult<IFormFile>> Get(string hash)
        //{
        //    //if (!System.IO.File.Exists(filePath)) return BadRequest();
        //    var file = await _NDDSFilesService.GetAsync(hash);
        //    if (file == null) return NotFound();
        //    return File(file.Value.Data, file.Value.ContentType, file.Value.FileName);
        //}

        //[HttpPost]
        //public async Task<ActionResult<NDDSFileUploadResponse>> Post([FromForm] NDDSFileMetadata metadata, [FromForm] IFormFile file)
        //{
        //    Console.WriteLine("Hit Post Endpoint");
        //    //await _NDDSFilesService.CreateAsync(metadata, file);
        //    var fileInfo = await _NDDSFilesService.CreateAsync(file, metadata);
        //    HttpContext.Response.Headers.Add("startTime", Request.Headers["startTime"]);
        //    return fileInfo;
        //}

        //[HttpPost, DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName?.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }

        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            long size = file.Length;

            //foreach (var formFile in files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        var filePath = Path.GetTempFileName();

            //        using (var stream = System.IO.File.Create(filePath))
            //        {
            //            await formFile.CopyToAsync(stream);
            //        }
            //    }
            //}

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { fileSize = size });
        }

        [HttpGet]
        public ActionResult<List<fileInfo>> GetFileList()
        {
            var finfo = new List<fileInfo>
            {
                new fileInfo {name = "bezoder.doc", Url = "http://localhost:5198/api/NDDSFiles/bezkode.doc"},
                new fileInfo {name = "bezoder.jpg", Url = "http://localhost:5198/api/NDDSFiles/bezkode.jpg"},
                new fileInfo {name = "bezoder.png", Url = "http://localhost:5198/api/NDDSFiles/bezkode.png"},
            };

            return Ok(finfo);
        }
        //[HttpPut("{hash:length(64)}")]
        //public async Task<IActionResult> Put(string hash, [FromForm] NDDSFileMetadata metadata)
        //{
        //    var file = await _NDDSFilesService.GetFileInfoAsync(hash);
        //    if (file == null) return NotFound();
        //    await _NDDSFilesService.UpdateAsync(hash, metadata);
        //    return NoContent();
        //}

        //[HttpDelete("{hash:length(64)}")]
        //public async Task<IActionResult> Delete(string hash)
        //{
        //    var file = await _NDDSFilesService.GetFileInfoAsync(hash);
        //    if (file == null) return NotFound();
        //    await _NDDSFilesService.RemoveAsync(hash);
        //    return NoContent();
        //}
    }

    public class fileInfo
    {
        public string name { get; set; }
        public string Url { get; set; }
    }

    public class NDDSFileUploadResponse
    {
    }
}
