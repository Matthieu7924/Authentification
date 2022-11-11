using AuthMVC.Options;

namespace AuthMVC.Services;

public class PathService
{
    private readonly IConfiguration configuration;
    private readonly IWebHostEnvironment env;


    //constructeur 
    public PathService(IConfiguration configuration, IWebHostEnvironment env)
    {
        this.configuration = configuration;
        this.env = env;
    }

    //méthode
    public string GetUploadsPath(string? filename = null, bool withWebRootPath = true)//fonction pour récupérer le chemin de l'image à uploader
    {
        var pathOptions = new PathOptions();

        configuration.GetSection(PathOptions.Path).Bind(pathOptions);

        var uploadsPath = pathOptions.FruitsImages;

        if (null!=filename)
            uploadsPath = Path.Combine(uploadsPath, filename);

        return withWebRootPath ? Path.Combine(env.WebRootPath, uploadsPath) : uploadsPath;

    }
}
