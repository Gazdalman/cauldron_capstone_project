using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;

namespace Cauldron.Services;

public class S3Service
{
  private readonly IAmazonS3 _s3Client;
  private readonly string _bucketName;

  public S3Service(IAmazonS3 s3Client, IConfiguration configuration)
  {
    _s3Client = s3Client;
    _bucketName = configuration["AWS:BucketName"] ?? throw new InvalidOperationException("BucketName is not configured.");
  }

  public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
  {
    var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
    Console.WriteLine(_bucketName);

    var uploadRequest = new TransferUtilityUploadRequest
    {
      InputStream = fileStream,
      Key = uniqueFileName,
      BucketName = _bucketName,
      ContentType = contentType
    };

    var fileTransferUtility = new TransferUtility(_s3Client);
    await fileTransferUtility.UploadAsync(uploadRequest);

    return $"https://{_bucketName}.s3.amazonaws.com/{uniqueFileName}";
  }
}
