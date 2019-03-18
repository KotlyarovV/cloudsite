using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagsCloudVisualization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloudWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICloudPainter _cloudPainter;
        public ValuesController(ICloudPainter cloudPainter)
        {
            _cloudPainter = cloudPainter;
        }
        

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> GetFileInfo(Parameters parameters)
        {
            try
            {
                Task<string> readResult;
                using (var reader = new StreamReader(parameters.File.OpenReadStream(), Encoding.Default))
                {
                    readResult = reader.ReadToEndAsync();
                }

                await readResult;
                
                var text = readResult.Result;
                var bitmap = _cloudPainter.GetBitmap(
                    text, 
                    parameters.Colors, 
                    parameters.Width, 
                    parameters.Height, 
                    parameters.MinFont, 
                    parameters.MaxFont, 
                    parameters.FontName
                    );
           
                var ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Png);                
                return File(ms.ToArray(), "image/png");
            }
            catch (Exception)
            {
                return new StatusCodeResult(404);
            }
        }

    }
}
