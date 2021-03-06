// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: transport/internet/grpc/config.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.Transport.Internet.Grpc.Encoding {

  /// <summary>Holder for reflection information generated from transport/internet/grpc/config.proto</summary>
  public static partial class ConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for transport/internet/grpc/config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiR0cmFuc3BvcnQvaW50ZXJuZXQvZ3JwYy9jb25maWcucHJvdG8SJXhyYXku",
            "dHJhbnNwb3J0LmludGVybmV0LmdycGMuZW5jb2RpbmcikwEKBkNvbmZpZxIM",
            "CgRob3N0GAEgASgJEhQKDHNlcnZpY2VfbmFtZRgCIAEoCRISCgptdWx0aV9t",
            "b2RlGAMgASgIEhQKDGlkbGVfdGltZW91dBgEIAEoBRIcChRoZWFsdGhfY2hl",
            "Y2tfdGltZW91dBgFIAEoBRIdChVwZXJtaXRfd2l0aG91dF9zdHJlYW0YBiAB",
            "KAhCM1oxZ2l0aHViLmNvbS94dGxzL3hyYXktY29yZS90cmFuc3BvcnQvaW50",
            "ZXJuZXQvZ3JwY2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Transport.Internet.Grpc.Encoding.Config), global::Xray.Transport.Internet.Grpc.Encoding.Config.Parser, new[]{ "Host", "ServiceName", "MultiMode", "IdleTimeout", "HealthCheckTimeout", "PermitWithoutStream" }, null, null, null)
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
      get { return global::Xray.Transport.Internet.Grpc.Encoding.ConfigReflection.Descriptor.MessageTypes[0]; }
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
      host_ = other.host_;
      serviceName_ = other.serviceName_;
      multiMode_ = other.multiMode_;
      idleTimeout_ = other.idleTimeout_;
      healthCheckTimeout_ = other.healthCheckTimeout_;
      permitWithoutStream_ = other.permitWithoutStream_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Config Clone() {
      return new Config(this);
    }

    /// <summary>Field number for the "host" field.</summary>
    public const int HostFieldNumber = 1;
    private string host_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Host {
      get { return host_; }
      set {
        host_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "service_name" field.</summary>
    public const int ServiceNameFieldNumber = 2;
    private string serviceName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ServiceName {
      get { return serviceName_; }
      set {
        serviceName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "multi_mode" field.</summary>
    public const int MultiModeFieldNumber = 3;
    private bool multiMode_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool MultiMode {
      get { return multiMode_; }
      set {
        multiMode_ = value;
      }
    }

    /// <summary>Field number for the "idle_timeout" field.</summary>
    public const int IdleTimeoutFieldNumber = 4;
    private int idleTimeout_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int IdleTimeout {
      get { return idleTimeout_; }
      set {
        idleTimeout_ = value;
      }
    }

    /// <summary>Field number for the "health_check_timeout" field.</summary>
    public const int HealthCheckTimeoutFieldNumber = 5;
    private int healthCheckTimeout_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int HealthCheckTimeout {
      get { return healthCheckTimeout_; }
      set {
        healthCheckTimeout_ = value;
      }
    }

    /// <summary>Field number for the "permit_without_stream" field.</summary>
    public const int PermitWithoutStreamFieldNumber = 6;
    private bool permitWithoutStream_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool PermitWithoutStream {
      get { return permitWithoutStream_; }
      set {
        permitWithoutStream_ = value;
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
      if (Host != other.Host) return false;
      if (ServiceName != other.ServiceName) return false;
      if (MultiMode != other.MultiMode) return false;
      if (IdleTimeout != other.IdleTimeout) return false;
      if (HealthCheckTimeout != other.HealthCheckTimeout) return false;
      if (PermitWithoutStream != other.PermitWithoutStream) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Host.Length != 0) hash ^= Host.GetHashCode();
      if (ServiceName.Length != 0) hash ^= ServiceName.GetHashCode();
      if (MultiMode != false) hash ^= MultiMode.GetHashCode();
      if (IdleTimeout != 0) hash ^= IdleTimeout.GetHashCode();
      if (HealthCheckTimeout != 0) hash ^= HealthCheckTimeout.GetHashCode();
      if (PermitWithoutStream != false) hash ^= PermitWithoutStream.GetHashCode();
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
      if (Host.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Host);
      }
      if (ServiceName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ServiceName);
      }
      if (MultiMode != false) {
        output.WriteRawTag(24);
        output.WriteBool(MultiMode);
      }
      if (IdleTimeout != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(IdleTimeout);
      }
      if (HealthCheckTimeout != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(HealthCheckTimeout);
      }
      if (PermitWithoutStream != false) {
        output.WriteRawTag(48);
        output.WriteBool(PermitWithoutStream);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Host.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Host);
      }
      if (ServiceName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ServiceName);
      }
      if (MultiMode != false) {
        size += 1 + 1;
      }
      if (IdleTimeout != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(IdleTimeout);
      }
      if (HealthCheckTimeout != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(HealthCheckTimeout);
      }
      if (PermitWithoutStream != false) {
        size += 1 + 1;
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
      if (other.Host.Length != 0) {
        Host = other.Host;
      }
      if (other.ServiceName.Length != 0) {
        ServiceName = other.ServiceName;
      }
      if (other.MultiMode != false) {
        MultiMode = other.MultiMode;
      }
      if (other.IdleTimeout != 0) {
        IdleTimeout = other.IdleTimeout;
      }
      if (other.HealthCheckTimeout != 0) {
        HealthCheckTimeout = other.HealthCheckTimeout;
      }
      if (other.PermitWithoutStream != false) {
        PermitWithoutStream = other.PermitWithoutStream;
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
            Host = input.ReadString();
            break;
          }
          case 18: {
            ServiceName = input.ReadString();
            break;
          }
          case 24: {
            MultiMode = input.ReadBool();
            break;
          }
          case 32: {
            IdleTimeout = input.ReadInt32();
            break;
          }
          case 40: {
            HealthCheckTimeout = input.ReadInt32();
            break;
          }
          case 48: {
            PermitWithoutStream = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
