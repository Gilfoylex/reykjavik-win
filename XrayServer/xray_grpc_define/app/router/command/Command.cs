// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: app/router/command/command.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.App.Router.Command {

  /// <summary>Holder for reflection information generated from app/router/command/command.proto</summary>
  public static partial class CommandReflection {

    #region Descriptor
    /// <summary>File descriptor for app/router/command/command.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CommandReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiBhcHAvcm91dGVyL2NvbW1hbmQvY29tbWFuZC5wcm90bxIXeHJheS5hcHAu",
            "cm91dGVyLmNvbW1hbmQaGGNvbW1vbi9uZXQvbmV0d29yay5wcm90byKDAwoO",
            "Um91dGluZ0NvbnRleHQSEgoKSW5ib3VuZFRhZxgBIAEoCRIpCgdOZXR3b3Jr",
            "GAIgASgOMhgueHJheS5jb21tb24ubmV0Lk5ldHdvcmsSEQoJU291cmNlSVBz",
            "GAMgAygMEhEKCVRhcmdldElQcxgEIAMoDBISCgpTb3VyY2VQb3J0GAUgASgN",
            "EhIKClRhcmdldFBvcnQYBiABKA0SFAoMVGFyZ2V0RG9tYWluGAcgASgJEhAK",
            "CFByb3RvY29sGAggASgJEgwKBFVzZXIYCSABKAkSSwoKQXR0cmlidXRlcxgK",
            "IAMoCzI3LnhyYXkuYXBwLnJvdXRlci5jb21tYW5kLlJvdXRpbmdDb250ZXh0",
            "LkF0dHJpYnV0ZXNFbnRyeRIZChFPdXRib3VuZEdyb3VwVGFncxgLIAMoCRIT",
            "CgtPdXRib3VuZFRhZxgMIAEoCRoxCg9BdHRyaWJ1dGVzRW50cnkSCwoDa2V5",
            "GAEgASgJEg0KBXZhbHVlGAIgASgJOgI4ASI2ChxTdWJzY3JpYmVSb3V0aW5n",
            "U3RhdHNSZXF1ZXN0EhYKDkZpZWxkU2VsZWN0b3JzGAEgAygJIoIBChBUZXN0",
            "Um91dGVSZXF1ZXN0Ej8KDlJvdXRpbmdDb250ZXh0GAEgASgLMicueHJheS5h",
            "cHAucm91dGVyLmNvbW1hbmQuUm91dGluZ0NvbnRleHQSFgoORmllbGRTZWxl",
            "Y3RvcnMYAiADKAkSFQoNUHVibGlzaFJlc3VsdBgDIAEoCCIICgZDb25maWcy",
            "8AEKDlJvdXRpbmdTZXJ2aWNlEnsKFVN1YnNjcmliZVJvdXRpbmdTdGF0cxI1",
            "LnhyYXkuYXBwLnJvdXRlci5jb21tYW5kLlN1YnNjcmliZVJvdXRpbmdTdGF0",
            "c1JlcXVlc3QaJy54cmF5LmFwcC5yb3V0ZXIuY29tbWFuZC5Sb3V0aW5nQ29u",
            "dGV4dCIAMAESYQoJVGVzdFJvdXRlEikueHJheS5hcHAucm91dGVyLmNvbW1h",
            "bmQuVGVzdFJvdXRlUmVxdWVzdBonLnhyYXkuYXBwLnJvdXRlci5jb21tYW5k",
            "LlJvdXRpbmdDb250ZXh0IgBCZwobY29tLnhyYXkuYXBwLnJvdXRlci5jb21t",
            "YW5kUAFaLGdpdGh1Yi5jb20veHRscy94cmF5LWNvcmUvYXBwL3JvdXRlci9j",
            "b21tYW5kqgIXWHJheS5BcHAuUm91dGVyLkNvbW1hbmRiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Xray.Common.Net.NetworkReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.App.Router.Command.RoutingContext), global::Xray.App.Router.Command.RoutingContext.Parser, new[]{ "InboundTag", "Network", "SourceIPs", "TargetIPs", "SourcePort", "TargetPort", "TargetDomain", "Protocol", "User", "Attributes", "OutboundGroupTags", "OutboundTag" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.App.Router.Command.SubscribeRoutingStatsRequest), global::Xray.App.Router.Command.SubscribeRoutingStatsRequest.Parser, new[]{ "FieldSelectors" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.App.Router.Command.TestRouteRequest), global::Xray.App.Router.Command.TestRouteRequest.Parser, new[]{ "RoutingContext", "FieldSelectors", "PublishResult" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.App.Router.Command.Config), global::Xray.App.Router.Command.Config.Parser, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// RoutingContext is the context with information relative to routing process.
  /// It conforms to the structure of xray.features.routing.Context and
  /// xray.features.routing.Route.
  /// </summary>
  public sealed partial class RoutingContext : pb::IMessage<RoutingContext> {
    private static readonly pb::MessageParser<RoutingContext> _parser = new pb::MessageParser<RoutingContext>(() => new RoutingContext());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<RoutingContext> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.App.Router.Command.CommandReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoutingContext() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoutingContext(RoutingContext other) : this() {
      inboundTag_ = other.inboundTag_;
      network_ = other.network_;
      sourceIPs_ = other.sourceIPs_.Clone();
      targetIPs_ = other.targetIPs_.Clone();
      sourcePort_ = other.sourcePort_;
      targetPort_ = other.targetPort_;
      targetDomain_ = other.targetDomain_;
      protocol_ = other.protocol_;
      user_ = other.user_;
      attributes_ = other.attributes_.Clone();
      outboundGroupTags_ = other.outboundGroupTags_.Clone();
      outboundTag_ = other.outboundTag_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public RoutingContext Clone() {
      return new RoutingContext(this);
    }

    /// <summary>Field number for the "InboundTag" field.</summary>
    public const int InboundTagFieldNumber = 1;
    private string inboundTag_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string InboundTag {
      get { return inboundTag_; }
      set {
        inboundTag_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Network" field.</summary>
    public const int NetworkFieldNumber = 2;
    private global::Xray.Common.Net.Network network_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Xray.Common.Net.Network Network {
      get { return network_; }
      set {
        network_ = value;
      }
    }

    /// <summary>Field number for the "SourceIPs" field.</summary>
    public const int SourceIPsFieldNumber = 3;
    private static readonly pb::FieldCodec<pb::ByteString> _repeated_sourceIPs_codec
        = pb::FieldCodec.ForBytes(26);
    private readonly pbc::RepeatedField<pb::ByteString> sourceIPs_ = new pbc::RepeatedField<pb::ByteString>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<pb::ByteString> SourceIPs {
      get { return sourceIPs_; }
    }

    /// <summary>Field number for the "TargetIPs" field.</summary>
    public const int TargetIPsFieldNumber = 4;
    private static readonly pb::FieldCodec<pb::ByteString> _repeated_targetIPs_codec
        = pb::FieldCodec.ForBytes(34);
    private readonly pbc::RepeatedField<pb::ByteString> targetIPs_ = new pbc::RepeatedField<pb::ByteString>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<pb::ByteString> TargetIPs {
      get { return targetIPs_; }
    }

    /// <summary>Field number for the "SourcePort" field.</summary>
    public const int SourcePortFieldNumber = 5;
    private uint sourcePort_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint SourcePort {
      get { return sourcePort_; }
      set {
        sourcePort_ = value;
      }
    }

    /// <summary>Field number for the "TargetPort" field.</summary>
    public const int TargetPortFieldNumber = 6;
    private uint targetPort_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TargetPort {
      get { return targetPort_; }
      set {
        targetPort_ = value;
      }
    }

    /// <summary>Field number for the "TargetDomain" field.</summary>
    public const int TargetDomainFieldNumber = 7;
    private string targetDomain_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string TargetDomain {
      get { return targetDomain_; }
      set {
        targetDomain_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Protocol" field.</summary>
    public const int ProtocolFieldNumber = 8;
    private string protocol_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Protocol {
      get { return protocol_; }
      set {
        protocol_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "User" field.</summary>
    public const int UserFieldNumber = 9;
    private string user_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string User {
      get { return user_; }
      set {
        user_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Attributes" field.</summary>
    public const int AttributesFieldNumber = 10;
    private static readonly pbc::MapField<string, string>.Codec _map_attributes_codec
        = new pbc::MapField<string, string>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForString(18), 82);
    private readonly pbc::MapField<string, string> attributes_ = new pbc::MapField<string, string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, string> Attributes {
      get { return attributes_; }
    }

    /// <summary>Field number for the "OutboundGroupTags" field.</summary>
    public const int OutboundGroupTagsFieldNumber = 11;
    private static readonly pb::FieldCodec<string> _repeated_outboundGroupTags_codec
        = pb::FieldCodec.ForString(90);
    private readonly pbc::RepeatedField<string> outboundGroupTags_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> OutboundGroupTags {
      get { return outboundGroupTags_; }
    }

    /// <summary>Field number for the "OutboundTag" field.</summary>
    public const int OutboundTagFieldNumber = 12;
    private string outboundTag_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OutboundTag {
      get { return outboundTag_; }
      set {
        outboundTag_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as RoutingContext);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(RoutingContext other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (InboundTag != other.InboundTag) return false;
      if (Network != other.Network) return false;
      if(!sourceIPs_.Equals(other.sourceIPs_)) return false;
      if(!targetIPs_.Equals(other.targetIPs_)) return false;
      if (SourcePort != other.SourcePort) return false;
      if (TargetPort != other.TargetPort) return false;
      if (TargetDomain != other.TargetDomain) return false;
      if (Protocol != other.Protocol) return false;
      if (User != other.User) return false;
      if (!Attributes.Equals(other.Attributes)) return false;
      if(!outboundGroupTags_.Equals(other.outboundGroupTags_)) return false;
      if (OutboundTag != other.OutboundTag) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (InboundTag.Length != 0) hash ^= InboundTag.GetHashCode();
      if (Network != 0) hash ^= Network.GetHashCode();
      hash ^= sourceIPs_.GetHashCode();
      hash ^= targetIPs_.GetHashCode();
      if (SourcePort != 0) hash ^= SourcePort.GetHashCode();
      if (TargetPort != 0) hash ^= TargetPort.GetHashCode();
      if (TargetDomain.Length != 0) hash ^= TargetDomain.GetHashCode();
      if (Protocol.Length != 0) hash ^= Protocol.GetHashCode();
      if (User.Length != 0) hash ^= User.GetHashCode();
      hash ^= Attributes.GetHashCode();
      hash ^= outboundGroupTags_.GetHashCode();
      if (OutboundTag.Length != 0) hash ^= OutboundTag.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (InboundTag.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(InboundTag);
      }
      if (Network != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Network);
      }
      sourceIPs_.WriteTo(output, _repeated_sourceIPs_codec);
      targetIPs_.WriteTo(output, _repeated_targetIPs_codec);
      if (SourcePort != 0) {
        output.WriteRawTag(40);
        output.WriteUInt32(SourcePort);
      }
      if (TargetPort != 0) {
        output.WriteRawTag(48);
        output.WriteUInt32(TargetPort);
      }
      if (TargetDomain.Length != 0) {
        output.WriteRawTag(58);
        output.WriteString(TargetDomain);
      }
      if (Protocol.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(Protocol);
      }
      if (User.Length != 0) {
        output.WriteRawTag(74);
        output.WriteString(User);
      }
      attributes_.WriteTo(output, _map_attributes_codec);
      outboundGroupTags_.WriteTo(output, _repeated_outboundGroupTags_codec);
      if (OutboundTag.Length != 0) {
        output.WriteRawTag(98);
        output.WriteString(OutboundTag);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (InboundTag.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(InboundTag);
      }
      if (Network != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Network);
      }
      size += sourceIPs_.CalculateSize(_repeated_sourceIPs_codec);
      size += targetIPs_.CalculateSize(_repeated_targetIPs_codec);
      if (SourcePort != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(SourcePort);
      }
      if (TargetPort != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TargetPort);
      }
      if (TargetDomain.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TargetDomain);
      }
      if (Protocol.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Protocol);
      }
      if (User.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(User);
      }
      size += attributes_.CalculateSize(_map_attributes_codec);
      size += outboundGroupTags_.CalculateSize(_repeated_outboundGroupTags_codec);
      if (OutboundTag.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OutboundTag);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(RoutingContext other) {
      if (other == null) {
        return;
      }
      if (other.InboundTag.Length != 0) {
        InboundTag = other.InboundTag;
      }
      if (other.Network != 0) {
        Network = other.Network;
      }
      sourceIPs_.Add(other.sourceIPs_);
      targetIPs_.Add(other.targetIPs_);
      if (other.SourcePort != 0) {
        SourcePort = other.SourcePort;
      }
      if (other.TargetPort != 0) {
        TargetPort = other.TargetPort;
      }
      if (other.TargetDomain.Length != 0) {
        TargetDomain = other.TargetDomain;
      }
      if (other.Protocol.Length != 0) {
        Protocol = other.Protocol;
      }
      if (other.User.Length != 0) {
        User = other.User;
      }
      attributes_.Add(other.attributes_);
      outboundGroupTags_.Add(other.outboundGroupTags_);
      if (other.OutboundTag.Length != 0) {
        OutboundTag = other.OutboundTag;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            InboundTag = input.ReadString();
            break;
          }
          case 16: {
            Network = (global::Xray.Common.Net.Network) input.ReadEnum();
            break;
          }
          case 26: {
            sourceIPs_.AddEntriesFrom(input, _repeated_sourceIPs_codec);
            break;
          }
          case 34: {
            targetIPs_.AddEntriesFrom(input, _repeated_targetIPs_codec);
            break;
          }
          case 40: {
            SourcePort = input.ReadUInt32();
            break;
          }
          case 48: {
            TargetPort = input.ReadUInt32();
            break;
          }
          case 58: {
            TargetDomain = input.ReadString();
            break;
          }
          case 66: {
            Protocol = input.ReadString();
            break;
          }
          case 74: {
            User = input.ReadString();
            break;
          }
          case 82: {
            attributes_.AddEntriesFrom(input, _map_attributes_codec);
            break;
          }
          case 90: {
            outboundGroupTags_.AddEntriesFrom(input, _repeated_outboundGroupTags_codec);
            break;
          }
          case 98: {
            OutboundTag = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// SubscribeRoutingStatsRequest subscribes to routing statistics channel if
  /// opened by xray-core.
  /// * FieldSelectors selects a subset of fields in routing statistics to return.
  /// Valid selectors:
  ///  - inbound: Selects connection's inbound tag.
  ///  - network: Selects connection's network.
  ///  - ip: Equivalent as "ip_source" and "ip_target", selects both source and
  ///  target IP.
  ///  - port: Equivalent as "port_source" and "port_target", selects both source
  ///  and target port.
  ///  - domain: Selects target domain.
  ///  - protocol: Select connection's protocol.
  ///  - user: Select connection's inbound user email.
  ///  - attributes: Select connection's additional attributes.
  ///  - outbound: Equivalent as "outbound" and "outbound_group", select both
  ///  outbound tag and outbound group tags.
  /// * If FieldSelectors is left empty, all fields will be returned.
  /// </summary>
  public sealed partial class SubscribeRoutingStatsRequest : pb::IMessage<SubscribeRoutingStatsRequest> {
    private static readonly pb::MessageParser<SubscribeRoutingStatsRequest> _parser = new pb::MessageParser<SubscribeRoutingStatsRequest>(() => new SubscribeRoutingStatsRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SubscribeRoutingStatsRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.App.Router.Command.CommandReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRoutingStatsRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRoutingStatsRequest(SubscribeRoutingStatsRequest other) : this() {
      fieldSelectors_ = other.fieldSelectors_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SubscribeRoutingStatsRequest Clone() {
      return new SubscribeRoutingStatsRequest(this);
    }

    /// <summary>Field number for the "FieldSelectors" field.</summary>
    public const int FieldSelectorsFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_fieldSelectors_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> fieldSelectors_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> FieldSelectors {
      get { return fieldSelectors_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SubscribeRoutingStatsRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SubscribeRoutingStatsRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!fieldSelectors_.Equals(other.fieldSelectors_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= fieldSelectors_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      fieldSelectors_.WriteTo(output, _repeated_fieldSelectors_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += fieldSelectors_.CalculateSize(_repeated_fieldSelectors_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SubscribeRoutingStatsRequest other) {
      if (other == null) {
        return;
      }
      fieldSelectors_.Add(other.fieldSelectors_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            fieldSelectors_.AddEntriesFrom(input, _repeated_fieldSelectors_codec);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// TestRouteRequest manually tests a routing result according to the routing
  /// context message.
  /// * RoutingContext is the routing message without outbound information.
  /// * FieldSelectors selects the fields to return in the routing result. All
  /// fields are returned if left empty.
  /// * PublishResult broadcasts the routing result to routing statistics channel
  /// if set true.
  /// </summary>
  public sealed partial class TestRouteRequest : pb::IMessage<TestRouteRequest> {
    private static readonly pb::MessageParser<TestRouteRequest> _parser = new pb::MessageParser<TestRouteRequest>(() => new TestRouteRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TestRouteRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.App.Router.Command.CommandReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestRouteRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestRouteRequest(TestRouteRequest other) : this() {
      routingContext_ = other.routingContext_ != null ? other.routingContext_.Clone() : null;
      fieldSelectors_ = other.fieldSelectors_.Clone();
      publishResult_ = other.publishResult_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TestRouteRequest Clone() {
      return new TestRouteRequest(this);
    }

    /// <summary>Field number for the "RoutingContext" field.</summary>
    public const int RoutingContextFieldNumber = 1;
    private global::Xray.App.Router.Command.RoutingContext routingContext_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Xray.App.Router.Command.RoutingContext RoutingContext {
      get { return routingContext_; }
      set {
        routingContext_ = value;
      }
    }

    /// <summary>Field number for the "FieldSelectors" field.</summary>
    public const int FieldSelectorsFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_fieldSelectors_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> fieldSelectors_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> FieldSelectors {
      get { return fieldSelectors_; }
    }

    /// <summary>Field number for the "PublishResult" field.</summary>
    public const int PublishResultFieldNumber = 3;
    private bool publishResult_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool PublishResult {
      get { return publishResult_; }
      set {
        publishResult_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TestRouteRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TestRouteRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(RoutingContext, other.RoutingContext)) return false;
      if(!fieldSelectors_.Equals(other.fieldSelectors_)) return false;
      if (PublishResult != other.PublishResult) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (routingContext_ != null) hash ^= RoutingContext.GetHashCode();
      hash ^= fieldSelectors_.GetHashCode();
      if (PublishResult != false) hash ^= PublishResult.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (routingContext_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(RoutingContext);
      }
      fieldSelectors_.WriteTo(output, _repeated_fieldSelectors_codec);
      if (PublishResult != false) {
        output.WriteRawTag(24);
        output.WriteBool(PublishResult);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (routingContext_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RoutingContext);
      }
      size += fieldSelectors_.CalculateSize(_repeated_fieldSelectors_codec);
      if (PublishResult != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TestRouteRequest other) {
      if (other == null) {
        return;
      }
      if (other.routingContext_ != null) {
        if (routingContext_ == null) {
          RoutingContext = new global::Xray.App.Router.Command.RoutingContext();
        }
        RoutingContext.MergeFrom(other.RoutingContext);
      }
      fieldSelectors_.Add(other.fieldSelectors_);
      if (other.PublishResult != false) {
        PublishResult = other.PublishResult;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (routingContext_ == null) {
              RoutingContext = new global::Xray.App.Router.Command.RoutingContext();
            }
            input.ReadMessage(RoutingContext);
            break;
          }
          case 18: {
            fieldSelectors_.AddEntriesFrom(input, _repeated_fieldSelectors_codec);
            break;
          }
          case 24: {
            PublishResult = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Config : pb::IMessage<Config> {
    private static readonly pb::MessageParser<Config> _parser = new pb::MessageParser<Config>(() => new Config());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Config> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.App.Router.Command.CommandReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config(Config other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config Clone() {
      return new Config(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Config);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Config other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Config other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code