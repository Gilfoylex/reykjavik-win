// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proxy/vmess/outbound/config.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.Proxy.Vmess.Outbound {

  /// <summary>Holder for reflection information generated from proxy/vmess/outbound/config.proto</summary>
  public static partial class ConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for proxy/vmess/outbound/config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiFwcm94eS92bWVzcy9vdXRib3VuZC9jb25maWcucHJvdG8SGXhyYXkucHJv",
            "eHkudm1lc3Mub3V0Ym91bmQaIWNvbW1vbi9wcm90b2NvbC9zZXJ2ZXJfc3Bl",
            "Yy5wcm90byJACgZDb25maWcSNgoIUmVjZWl2ZXIYASADKAsyJC54cmF5LmNv",
            "bW1vbi5wcm90b2NvbC5TZXJ2ZXJFbmRwb2ludEJtCh1jb20ueHJheS5wcm94",
            "eS52bWVzcy5vdXRib3VuZFABWi5naXRodWIuY29tL3h0bHMveHJheS1jb3Jl",
            "L3Byb3h5L3ZtZXNzL291dGJvdW5kqgIZWHJheS5Qcm94eS5WbWVzcy5PdXRi",
            "b3VuZGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Xray.Common.Protocol.ServerSpecReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Proxy.Vmess.Outbound.Config), global::Xray.Proxy.Vmess.Outbound.Config.Parser, new[]{ "Receiver" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Config : pb::IMessage<Config> {
    private static readonly pb::MessageParser<Config> _parser = new pb::MessageParser<Config>(() => new Config());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Config> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.Proxy.Vmess.Outbound.ConfigReflection.Descriptor.MessageTypes[0]; }
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
      receiver_ = other.receiver_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config Clone() {
      return new Config(this);
    }

    /// <summary>Field number for the "Receiver" field.</summary>
    public const int ReceiverFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Xray.Common.Protocol.ServerEndpoint> _repeated_receiver_codec
        = pb::FieldCodec.ForMessage(10, global::Xray.Common.Protocol.ServerEndpoint.Parser);
    private readonly pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint> receiver_ = new pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint> Receiver {
      get { return receiver_; }
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
      if(!receiver_.Equals(other.receiver_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= receiver_.GetHashCode();
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
      receiver_.WriteTo(output, _repeated_receiver_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += receiver_.CalculateSize(_repeated_receiver_codec);
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
      receiver_.Add(other.receiver_);
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
            receiver_.AddEntriesFrom(input, _repeated_receiver_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code