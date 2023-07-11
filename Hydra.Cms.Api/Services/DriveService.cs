using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace Hydra.Cms.Api.Services
{
    public class DriveService : IDriveService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public DriveService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<GalleryResultModel> GetFiles(HttpContext context)
        {
            var result = new GalleryResultModel();

            // Get the directory
            DirectoryInfo place = new DirectoryInfo(HydraHelper.GetDriveDirectory());

            // Using GetFiles() method to get list of all
            // the files present in the Train directory
            var Files = place.GetFiles().Where(s => s.Name.EndsWith(".jpg") || s.Name.EndsWith(".png") || s.Name.EndsWith(".bnp"));

            // Display the file names
            foreach (FileInfo i in Files)
            {
                result.Result.Add(new ImageModel() { Name = "Name", Src = HydraHelper.GetCurrentDomain(context) + "images/drive/" + i.Name });
            }
            result.statusCode = 200;
            return result;
        }

        public async Task<Result> Add(IFormFile formFile)
        {
            var result = new Result();
            if (formFile.Length > 0)
            {
                var filePath = HydraHelper.GetDriveDirectory();

                using (var stream = File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return result;
        }



    }
}