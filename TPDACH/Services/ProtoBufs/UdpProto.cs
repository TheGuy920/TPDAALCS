using ProtoBuf;

namespace TPDACH.Services.ProtoBufs;

[ProtoContract]
internal class UdpProto
{
    [ProtoMember(1)]
    public ulong ConnectionId { get; set; }

    [ProtoMember(2)]
    public uint ControlId { get; set; }

    [ProtoMember(3)]
    public uint OperationId { get; set; }

    [ProtoMember(4)]
    public required byte[] Data { get; set; }
}
