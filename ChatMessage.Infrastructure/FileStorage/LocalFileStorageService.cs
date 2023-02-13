using ChatMesssage.Application.Common.FileStorage;
using ChatMesssage.Domain.Core.Common;
using ChatMesssage.Infrastructure.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ChatMesssage.Infrastructure.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly IHttpContextAccessor _context;

    public LocalFileStorageService(IHostingEnvironment hostingEnvironment, IHttpContextAccessor context)
    {
        _hostingEnvironment = hostingEnvironment;
        _context = context;
    }
    public async Task<FileSaveResultDto?> UploadAsync<T>(IFormFile file, FileType supportedFileType, CancellationToken cancellationToken = default)
    where T : class
    {
        if (file == null || file.Length == 0)
        {
            return null;
        }

        if (Path.GetExtension(file.FileName) is null || !supportedFileType.GetDescriptionList().Contains(Path.GetExtension(file.FileName).ToLower()))
            throw new InvalidOperationException("File Format Not Supported.");

        if (file.Name is null)
            throw new InvalidOperationException("Name is required.");

        var fileSaveResult = new FileSaveResultDto();

        string folder = typeof(T).Name;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            folder = folder.Replace(@"\", "/");
        }

        string folderName = supportedFileType switch
        {
            FileType.Image => Path.Combine("Files", "Images", folder),
            FileType.Video => Path.Combine("Files", "Videos", folder),
            _ => Path.Combine("Files", "Others", folder),
        };

        string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        Directory.CreateDirectory(pathToSave);

        var fileName = file.FileName.Trim('"');
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        var uniqueFileName = Guid.NewGuid().ToString();

        var uniqueFileNameWithExtension = uniqueFileName + fileExtension;

        fileName = RemoveSpecialCharacters(fileName);
        fileName = fileName.ReplaceWhitespace("-");

        string fullPath = Path.Combine(pathToSave, uniqueFileNameWithExtension);
        string dbPath = Path.Combine(folderName, uniqueFileNameWithExtension);

        if (File.Exists(dbPath))
        {
            dbPath = NextAvailableFilename(dbPath);
            fullPath = NextAvailableFilename(fullPath);
        }

        using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        fileSaveResult.FilePath = dbPath.Replace("\\", "/");
        fileSaveResult.Extension = fileExtension;
        fileSaveResult.FileName = fileName;
        fileSaveResult.Size = Convert.ToInt32(Math.Ceiling((double)file.Length / 1000)); //KB

        return fileSaveResult;
    }

    public static string RemoveSpecialCharacters(string str)
    {
        return Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
    }

    public void Remove(string? path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    private const string NumberPattern = "-{0}";

    private static string NextAvailableFilename(string path)
    {
        if (!File.Exists(path))
        {
            return path;
        }

        if (Path.HasExtension(path))
        {
            return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path), StringComparison.Ordinal), NumberPattern));
        }

        return GetNextFilename(path + NumberPattern);
    }

    private static string GetNextFilename(string pattern)
    {
        string tmp = string.Format(pattern, 1);

        if (!File.Exists(tmp))
        {
            return tmp;
        }

        int min = 1, max = 2;

        while (File.Exists(string.Format(pattern, max)))
        {
            min = max;
            max *= 2;
        }

        while (max != min + 1)
        {
            int pivot = (max + min) / 2;
            if (File.Exists(string.Format(pattern, pivot)))
            {
                min = pivot;
            }
            else
            {
                max = pivot;
            }
        }

        return string.Format(pattern, max);
    }

    public string GetFilePath(string? path)
    {
        if (string.IsNullOrEmpty(path)) return string.Empty;

        var baseUri = new Uri(_context.HttpContext.Request.Scheme + "://" + _context.HttpContext.Request.Host.Value);
        var myUri = new Uri(baseUri, path);
        return myUri.AbsoluteUri;
    }
}
