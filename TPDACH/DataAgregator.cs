using TPDRS.Services;

namespace TPDRS;

/// <summary>
/// Main entry class to initialize the data agregation and control hub
/// </summary>
public class DataAgregator
{
    public const uint DefaultPort = 17462;

    public static NetworkService StartNetworkService(uint port = DefaultPort)
        => new(port, true);
}
