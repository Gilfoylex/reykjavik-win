// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: common/protocol/headers.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Xray.Common.Protocol {

  /// <summary>Holder for reflection information generated from common/protocol/headers.proto</summary>
  public static partial class HeadersReflection {

    #region Descriptor
    /// <summary>File descriptor for common/protocol/headers.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HeadersReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1jb21tb24vcHJvdG9jb2wvaGVhZGVycy5wcm90bxIUeHJheS5jb21tb24u",
            "cHJvdG9jb2wiQgoOU2VjdXJpdHlDb25maWcSMAoEdHlwZRgBIAEoDjIiLnhy",
            "YXkuY29tbW9uLnByb3RvY29sLlNlY3VyaXR5VHlwZSpsCgxTZWN1cml0eVR5",
            "cGUSCwoHVU5LTk9XThAAEgoKBkxFR0FDWRABEggKBEFVVE8QAhIOCgpBRVMx",
            "MjhfR0NNEAMSFQoRQ0hBQ0hBMjBfUE9MWTEzMDUQBBIICgROT05FEAUSCAoE",
            "WkVSTxAGQl4KGGNvbS54cmF5LmNvbW1vbi5wcm90b2NvbFABWilnaXRodWIu",
            "Y29tL3h0bHMveHJheS1jb3JlL2NvbW1vbi9wcm90b2NvbKoCFFhyYXkuQ29t",
            "bW9uLlByb3RvY29sYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Xray.Common.Protocol.SecurityType), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Xray.Common.Protocol.SecurityConfig), global::Xray.Common.Protocol.SecurityConfig.Parser, new[]{ "Type" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum SecurityType {
    [pbr::OriginalName("UNKNOWN")] Unknown = 0,
    [pbr::OriginalName("LEGACY")] Legacy = 1,
    [pbr::OriginalName("AUTO")] Auto = 2,
    [pbr::OriginalName("AES128_GCM")] Aes128Gcm = 3,
    [pbr::OriginalName("CHACHA20_POLY1305")] Chacha20Poly1305 = 4,
    [pbr::OriginalName("NONE")] None = 5,
    [pbr::OriginalName("ZERO")] Zero = 6,
  }

  #endregion

  #region Messages
  public sealed partial class SecurityConfig : pb::IMessage<SecurityConfig> {
    private static readonly pb::MessageParser<SecurityConfig> _parser = new pb::MessageParser<SecurityConfig>(() => new SecurityConfig());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SecurityConfig> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Xray.Common.Protocol.HeadersReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityConfig() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityConfig(SecurityConfig other) : this() {
      type_ = other.type_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SecurityConfig Clone() {
      return new SecurityConfig(this);
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 1;
    private global::Xray.Common.Protocol.SecurityType type_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Xray.Common.Protocol.SecurityType Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SecurityConfig);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SecurityConfig other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != 0) hash ^= Type.GetHashCode();
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
      if (Type != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Type);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Type);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SecurityConfig other) {
      if (other == null) {
        return;
      }
      if (other.Type != 0) {
        Type = other.Type;
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
          case 8: {
            Type = (global::Xray.Common.Protocol.SecurityType) input.ReadEnum();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
