﻿using IntranetAPI.Contracts.V1;
using IntranetAPI.Contracts.V1.Requests.Files;
using IntranetAPI.Services.FilesServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Controllers.V1
{
    public class FilesController : ControllerBase
    {
        private readonly IFileService _service;

        public FilesController(IFileService service)
        {
            _service = service;
        }

        [HttpPost(ApiRoutes.Files.Upload)]
        public async Task<IActionResult> UploadFile([FromForm] UploadFileRequest request)
        {
            var result = await _service.UploadFileAsync(request);
            if(result!=true)
            {
                return BadRequest("File with that name already exists");
            }
            return Ok("Created");
        }

        [HttpDelete(ApiRoutes.Files.Delete)]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result = await _service.DeleteFileAsync(id);
            if(result!=true)
            {
                return BadRequest("Something went wrong");
            }
            return NoContent();
        }
    }
}
