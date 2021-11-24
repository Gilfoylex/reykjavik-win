// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proxy/dns/config.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.Proxy.Dns {

  /// <summary>Holder for reflection information generated from proxy/dns/config.proto</summary>
  public static partial class ConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for proxy/dns/config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChZwcm94eS9kbnMvY29uZmlnLnByb3RvEg54cmF5LnByb3h5LmRucxocY29t",
            "bW9uL25ldC9kZXN0aW5hdGlvbi5wcm90byJHCgZDb25maWcSKQoGc2VydmVy",
            "GAEgASgLMhkueHJheS5jb21tb24ubmV0LkVuZHBvaW50EhIKCnVzZXJfbGV2",
            "ZWwYAiABKA1CTAoSY29tLnhyYXkucHJveHkuZG5zUAFaI2dpdGh1Yi5jb20v",
            "eHRscy94cmF5LWNvcmUvcHJveHkvZG5zqgIOWHJheS5Qcm94eS5EbnNiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Xray.Common.Net.DestinationReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Proxy.Dns.Config), global::Xray.Proxy.Dns.Config.Parser, new[]{ "Server", "UserLevel" }, null, null, null)
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
      get { return global::Xray.Proxy.Dns.ConfigReflection.Descriptor.MessageTypes[0]; }
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
      server_ = other.server_ != null ? other.server_.Clone() : null;
      userLevel_ = other.userLevel_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config Clone() {
      return new Config(this);
    }

    /// <summary>Field number for the "server" field.</summary>
    public const int ServerFieldNumber = 1;
    private global::Xray.Common.Net.Endpoint server_;
    /// <summary>
    /// Server is the DNS server address. If specified, this address overrides the
    /// original one.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Xray.Common.Net.Endpoint Server {
      get { return server_; }
      set {
        server_ = value;
      }
    }

    /// <summary>Field number for the "user_level" field.</summary>
    public const int UserLevelFieldNumber = 2;
    private uint userLevel_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint UserLevel {
      get { return userLevel_; }
      set {
        userLevel_ = value;
      }
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
      if (!object.Equals(Server, other.Server)) return false;
      if (UserLevel != other.UserLevel) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (server_ != null) hash ^= Server.GetHashCode();
      if (UserLevel != 0) hash ^= UserLevel.GetHashCode();
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
      if (server_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Server);
      }
      if (UserLevel != 0) {
        output.WriteRawTag(16);
        output.WriteUInt32(UserLevel);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (server_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Server);
      }
      if (UserLevel != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(UserLevel);
      }
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
      if (other.server_ != null) {
        if (server_ == null) {
          Server = new global::Xray.Common.Net.Endpoint();
        }
        Server.MergeFrom(other.Server);
      }
      if (other.UserLevel != 0) {
        UserLevel = other.UserLevel;
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
            if (server_ == null) {
              Server = new global::Xray.Common.Net.Endpoint();
            }
            input.ReadMessage(Server);
            break;
          }
          case 16: {
            UserLevel = input.ReadUInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
