// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proxy/shadowsocks/config.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.Proxy.Shadowsocks {

  /// <summary>Holder for reflection information generated from proxy/shadowsocks/config.proto</summary>
  public static partial class ConfigReflection {

    #region Descriptor
    /// <summary>File descriptor for proxy/shadowsocks/config.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ConfigReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5wcm94eS9zaGFkb3dzb2Nrcy9jb25maWcucHJvdG8SFnhyYXkucHJveHku",
            "c2hhZG93c29ja3MaGGNvbW1vbi9uZXQvbmV0d29yay5wcm90bxoaY29tbW9u",
            "L3Byb3RvY29sL3VzZXIucHJvdG8aIWNvbW1vbi9wcm90b2NvbC9zZXJ2ZXJf",
            "c3BlYy5wcm90byJUCgdBY2NvdW50EhAKCHBhc3N3b3JkGAEgASgJEjcKC2Np",
            "cGhlcl90eXBlGAIgASgOMiIueHJheS5wcm94eS5zaGFkb3dzb2Nrcy5DaXBo",
            "ZXJUeXBlImQKDFNlcnZlckNvbmZpZxIpCgV1c2VycxgBIAMoCzIaLnhyYXku",
            "Y29tbW9uLnByb3RvY29sLlVzZXISKQoHbmV0d29yaxgCIAMoDjIYLnhyYXku",
            "Y29tbW9uLm5ldC5OZXR3b3JrIkQKDENsaWVudENvbmZpZxI0CgZzZXJ2ZXIY",
            "ASADKAsyJC54cmF5LmNvbW1vbi5wcm90b2NvbC5TZXJ2ZXJFbmRwb2ludCpc",
            "CgpDaXBoZXJUeXBlEgsKB1VOS05PV04QABIPCgtBRVNfMTI4X0dDTRAFEg8K",
            "C0FFU18yNTZfR0NNEAYSFQoRQ0hBQ0hBMjBfUE9MWTEzMDUQBxIICgROT05F",
            "EAhCZAoaY29tLnhyYXkucHJveHkuc2hhZG93c29ja3NQAVorZ2l0aHViLmNv",
            "bS94dGxzL3hyYXktY29yZS9wcm94eS9zaGFkb3dzb2Nrc6oCFlhyYXkuUHJv",
            "eHkuU2hhZG93c29ja3NiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Xray.Common.Net.NetworkReflection.Descriptor, global::Xray.Common.Protocol.UserReflection.Descriptor, global::Xray.Common.Protocol.ServerSpecReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Xray.Proxy.Shadowsocks.CipherType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Proxy.Shadowsocks.Account), global::Xray.Proxy.Shadowsocks.Account.Parser, new[]{ "Password", "CipherType" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Proxy.Shadowsocks.ServerConfig), global::Xray.Proxy.Shadowsocks.ServerConfig.Parser, new[]{ "Users", "Network" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Proxy.Shadowsocks.ClientConfig), global::Xray.Proxy.Shadowsocks.ClientConfig.Parser, new[]{ "Server" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum CipherType {
    [pbr::OriginalName("UNKNOWN")] Unknown = 0,
    [pbr::OriginalName("AES_128_GCM")] Aes128Gcm = 5,
    [pbr::OriginalName("AES_256_GCM")] Aes256Gcm = 6,
    [pbr::OriginalName("CHACHA20_POLY1305")] Chacha20Poly1305 = 7,
    [pbr::OriginalName("NONE")] None = 8,
  }

  #endregion

  #region Messages
  public sealed partial class Account : pb::IMessage<Account> {
    private static readonly pb::MessageParser<Account> _parser = new pb::MessageParser<Account>(() => new Account());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Account> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.Proxy.Shadowsocks.ConfigReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Account() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Account(Account other) : this() {
      password_ = other.password_;
      cipherType_ = other.cipherType_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Account Clone() {
      return new Account(this);
    }

    /// <summary>Field number for the "password" field.</summary>
    public const int PasswordFieldNumber = 1;
    private string password_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "cipher_type" field.</summary>
    public const int CipherTypeFieldNumber = 2;
    private global::Xray.Proxy.Shadowsocks.CipherType cipherType_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Xray.Proxy.Shadowsocks.CipherType CipherType {
      get { return cipherType_; }
      set {
        cipherType_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Account);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Account other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Password != other.Password) return false;
      if (CipherType != other.CipherType) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (CipherType != 0) hash ^= CipherType.GetHashCode();
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
      if (Password.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Password);
      }
      if (CipherType != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) CipherType);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (CipherType != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) CipherType);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Account other) {
      if (other == null) {
        return;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      if (other.CipherType != 0) {
        CipherType = other.CipherType;
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
            Password = input.ReadString();
            break;
          }
          case 16: {
            CipherType = (global::Xray.Proxy.Shadowsocks.CipherType) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ServerConfig : pb::IMessage<ServerConfig> {
    private static readonly pb::MessageParser<ServerConfig> _parser = new pb::MessageParser<ServerConfig>(() => new ServerConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ServerConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.Proxy.Shadowsocks.ConfigReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServerConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServerConfig(ServerConfig other) : this() {
      users_ = other.users_.Clone();
      network_ = other.network_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServerConfig Clone() {
      return new ServerConfig(this);
    }

    /// <summary>Field number for the "users" field.</summary>
    public const int UsersFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Xray.Common.Protocol.User> _repeated_users_codec
        = pb::FieldCodec.ForMessage(10, global::Xray.Common.Protocol.User.Parser);
    private readonly pbc::RepeatedField<global::Xray.Common.Protocol.User> users_ = new pbc::RepeatedField<global::Xray.Common.Protocol.User>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Xray.Common.Protocol.User> Users {
      get { return users_; }
    }

    /// <summary>Field number for the "network" field.</summary>
    public const int NetworkFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Xray.Common.Net.Network> _repeated_network_codec
        = pb::FieldCodec.ForEnum(18, x => (int) x, x => (global::Xray.Common.Net.Network) x);
    private readonly pbc::RepeatedField<global::Xray.Common.Net.Network> network_ = new pbc::RepeatedField<global::Xray.Common.Net.Network>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Xray.Common.Net.Network> Network {
      get { return network_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ServerConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ServerConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!users_.Equals(other.users_)) return false;
      if(!network_.Equals(other.network_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= users_.GetHashCode();
      hash ^= network_.GetHashCode();
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
      users_.WriteTo(output, _repeated_users_codec);
      network_.WriteTo(output, _repeated_network_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += users_.CalculateSize(_repeated_users_codec);
      size += network_.CalculateSize(_repeated_network_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ServerConfig other) {
      if (other == null) {
        return;
      }
      users_.Add(other.users_);
      network_.Add(other.network_);
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
            users_.AddEntriesFrom(input, _repeated_users_codec);
            break;
          }
          case 18:
          case 16: {
            network_.AddEntriesFrom(input, _repeated_network_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ClientConfig : pb::IMessage<ClientConfig> {
    private static readonly pb::MessageParser<ClientConfig> _parser = new pb::MessageParser<ClientConfig>(() => new ClientConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ClientConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.Proxy.Shadowsocks.ConfigReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClientConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClientConfig(ClientConfig other) : this() {
      server_ = other.server_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClientConfig Clone() {
      return new ClientConfig(this);
    }

    /// <summary>Field number for the "server" field.</summary>
    public const int ServerFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Xray.Common.Protocol.ServerEndpoint> _repeated_server_codec
        = pb::FieldCodec.ForMessage(10, global::Xray.Common.Protocol.ServerEndpoint.Parser);
    private readonly pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint> server_ = new pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Xray.Common.Protocol.ServerEndpoint> Server {
      get { return server_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ClientConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ClientConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!server_.Equals(other.server_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= server_.GetHashCode();
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
      server_.WriteTo(output, _repeated_server_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += server_.CalculateSize(_repeated_server_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ClientConfig other) {
      if (other == null) {
        return;
      }
      server_.Add(other.server_);
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
            server_.AddEntriesFrom(input, _repeated_server_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
