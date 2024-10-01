using ProtoBuf;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using TPDRS.Services.ProtoBufs;

namespace TPDRS.Services;

public class NetworkService
{
    private static readonly TimeSpan TIMEOUT = TimeSpan.FromMicroseconds(1);

    private readonly IPEndPoint ServerAddress;
    private readonly TcpListener ControlServer;
    private readonly UdpClient LiveDataServer;

    private readonly Thread LiveDataThread;
    private readonly ManualResetEvent UdpInteruptHandler;

    private readonly Thread ControlThread;
    private readonly ManualResetEvent TcpInteruptHandler;

    private readonly ConcurrentBag<ulong> ConnectionIds;

    internal NetworkService(uint port, bool start)
    {
        this.ServerAddress = new IPEndPoint(IPAddress.Any, (int)port);
        this.ControlServer = new TcpListener(this.ServerAddress);
        this.LiveDataServer = new UdpClient(this.ServerAddress);

        this.ControlThread = new Thread(RunControlServer)
        {
            IsBackground = true,
            Name = "ControlServer",
            Priority = ThreadPriority.Highest
        };

        this.LiveDataThread = new Thread(RunLiveDataServer)
        {
            IsBackground = false,
            Name = "LiveDataServer",
            Priority = ThreadPriority.Highest
        };

        this.UdpInteruptHandler = new ManualResetEvent(false);
        this.TcpInteruptHandler = new ManualResetEvent(false);
        this.ConnectionIds = [];

        if (!start)
            return;
    }

    private async void RunControlServer()
    {
        this.ControlServer.Start();

        while (true)
        {
            TcpClient client = await this.ControlServer.AcceptTcpClientAsync();

        }
    }

    public void Stop()
    {
        this.UdpInteruptHandler.Set();
        this.TcpInteruptHandler.Set();

        this.LiveDataThread.Join();
    }

    private void RunLiveDataServer()
    {
        while (true)
        {
            // Start the async receive
            Task<UdpReceiveResult> waitObject = this.LiveDataServer.ReceiveAsync();

            // While we wait for the UdpReceiveResult, we check for interupt signal
            while (!waitObject.Wait(TIMEOUT) && !this.UdpInteruptHandler.WaitOne(0))
                continue;

            // Either we have a result or we have been interupted
            if (this.UdpInteruptHandler.WaitOne(0))
                break;

            // We have a result
            UdpReceiveResult result = waitObject.Result;
            UdpProto proto = Serializer.Deserialize<UdpProto>(result.Buffer.AsSpan());

            // TODO: Process the data
        }
    }
}
