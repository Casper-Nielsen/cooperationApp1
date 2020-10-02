// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: trip.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace cooperationApp1.Protobuf {

  /// <summary>Holder for reflection information generated from trip.proto</summary>
  public static partial class TripReflection {

    #region Descriptor
    /// <summary>File descriptor for trip.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TripReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgp0cmlwLnByb3RvEhhjb29wZXJhdGlvbkFwcDEucHJvdG9idWYaH2dvb2ds",
            "ZS9wcm90b2J1Zi90aW1lc3RhbXAucHJvdG8i+AEKBFRyaXASDgoGVXNlcklk",
            "GAEgASgFEh0KFVN0YXJ0TG9jYXRpb25Gb3JtYXRlZBgCIAMoARIbChNFbmRM",
            "b2NhdGlvbkZvcm1hdGVkGAMgAygBEhAKCERpc3RhbmNlGAQgASgBEi0KCVN0",
            "YXJ0dGltZRgFIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXASKwoH",
            "RW5kdGltZRgGIAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5UaW1lc3RhbXASEgoK",
            "QnJlYWtDb3VudBgHIAEoBRIQCghBdmdCcmVhaxgIIAEoARIQCghBdmdTcGVl",
            "ZBgJIAEoAWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::cooperationApp1.Protobuf.Trip), global::cooperationApp1.Protobuf.Trip.Parser, new[]{ "UserId", "StartLocationFormated", "EndLocationFormated", "Distance", "Starttime", "Endtime", "BreakCount", "AvgBreak", "AvgSpeed" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Trip : pb::IMessage<Trip> {
    private static readonly pb::MessageParser<Trip> _parser = new pb::MessageParser<Trip>(() => new Trip());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Trip> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::cooperationApp1.Protobuf.TripReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Trip() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Trip(Trip other) : this() {
      userId_ = other.userId_;
      startLocationFormated_ = other.startLocationFormated_.Clone();
      endLocationFormated_ = other.endLocationFormated_.Clone();
      distance_ = other.distance_;
      starttime_ = other.starttime_ != null ? other.starttime_.Clone() : null;
      endtime_ = other.endtime_ != null ? other.endtime_.Clone() : null;
      breakCount_ = other.breakCount_;
      avgBreak_ = other.avgBreak_;
      avgSpeed_ = other.avgSpeed_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Trip Clone() {
      return new Trip(this);
    }

    /// <summary>Field number for the "UserId" field.</summary>
    public const int UserIdFieldNumber = 1;
    private int userId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int UserId {
      get { return userId_; }
      set {
        userId_ = value;
      }
    }

    /// <summary>Field number for the "StartLocationFormated" field.</summary>
    public const int StartLocationFormatedFieldNumber = 2;
    private static readonly pb::FieldCodec<double> _repeated_startLocationFormated_codec
        = pb::FieldCodec.ForDouble(18);
    private readonly pbc::RepeatedField<double> startLocationFormated_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<double> StartLocationFormated {
      get { return startLocationFormated_; }
    }

    /// <summary>Field number for the "EndLocationFormated" field.</summary>
    public const int EndLocationFormatedFieldNumber = 3;
    private static readonly pb::FieldCodec<double> _repeated_endLocationFormated_codec
        = pb::FieldCodec.ForDouble(26);
    private readonly pbc::RepeatedField<double> endLocationFormated_ = new pbc::RepeatedField<double>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<double> EndLocationFormated {
      get { return endLocationFormated_; }
    }

    /// <summary>Field number for the "Distance" field.</summary>
    public const int DistanceFieldNumber = 4;
    private double distance_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Distance {
      get { return distance_; }
      set {
        distance_ = value;
      }
    }

    /// <summary>Field number for the "Starttime" field.</summary>
    public const int StarttimeFieldNumber = 5;
    private global::Google.Protobuf.WellKnownTypes.Timestamp starttime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Starttime {
      get { return starttime_; }
      set {
        starttime_ = value;
      }
    }

    /// <summary>Field number for the "Endtime" field.</summary>
    public const int EndtimeFieldNumber = 6;
    private global::Google.Protobuf.WellKnownTypes.Timestamp endtime_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Endtime {
      get { return endtime_; }
      set {
        endtime_ = value;
      }
    }

    /// <summary>Field number for the "BreakCount" field.</summary>
    public const int BreakCountFieldNumber = 7;
    private int breakCount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int BreakCount {
      get { return breakCount_; }
      set {
        breakCount_ = value;
      }
    }

    /// <summary>Field number for the "AvgBreak" field.</summary>
    public const int AvgBreakFieldNumber = 8;
    private double avgBreak_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double AvgBreak {
      get { return avgBreak_; }
      set {
        avgBreak_ = value;
      }
    }

    /// <summary>Field number for the "AvgSpeed" field.</summary>
    public const int AvgSpeedFieldNumber = 9;
    private double avgSpeed_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double AvgSpeed {
      get { return avgSpeed_; }
      set {
        avgSpeed_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Trip);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Trip other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (UserId != other.UserId) return false;
      if(!startLocationFormated_.Equals(other.startLocationFormated_)) return false;
      if(!endLocationFormated_.Equals(other.endLocationFormated_)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Distance, other.Distance)) return false;
      if (!object.Equals(Starttime, other.Starttime)) return false;
      if (!object.Equals(Endtime, other.Endtime)) return false;
      if (BreakCount != other.BreakCount) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AvgBreak, other.AvgBreak)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(AvgSpeed, other.AvgSpeed)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (UserId != 0) hash ^= UserId.GetHashCode();
      hash ^= startLocationFormated_.GetHashCode();
      hash ^= endLocationFormated_.GetHashCode();
      if (Distance != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Distance);
      if (starttime_ != null) hash ^= Starttime.GetHashCode();
      if (endtime_ != null) hash ^= Endtime.GetHashCode();
      if (BreakCount != 0) hash ^= BreakCount.GetHashCode();
      if (AvgBreak != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AvgBreak);
      if (AvgSpeed != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(AvgSpeed);
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
      if (UserId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(UserId);
      }
      startLocationFormated_.WriteTo(output, _repeated_startLocationFormated_codec);
      endLocationFormated_.WriteTo(output, _repeated_endLocationFormated_codec);
      if (Distance != 0D) {
        output.WriteRawTag(33);
        output.WriteDouble(Distance);
      }
      if (starttime_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(Starttime);
      }
      if (endtime_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(Endtime);
      }
      if (BreakCount != 0) {
        output.WriteRawTag(56);
        output.WriteInt32(BreakCount);
      }
      if (AvgBreak != 0D) {
        output.WriteRawTag(65);
        output.WriteDouble(AvgBreak);
      }
      if (AvgSpeed != 0D) {
        output.WriteRawTag(73);
        output.WriteDouble(AvgSpeed);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (UserId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(UserId);
      }
      size += startLocationFormated_.CalculateSize(_repeated_startLocationFormated_codec);
      size += endLocationFormated_.CalculateSize(_repeated_endLocationFormated_codec);
      if (Distance != 0D) {
        size += 1 + 8;
      }
      if (starttime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Starttime);
      }
      if (endtime_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Endtime);
      }
      if (BreakCount != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(BreakCount);
      }
      if (AvgBreak != 0D) {
        size += 1 + 8;
      }
      if (AvgSpeed != 0D) {
        size += 1 + 8;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Trip other) {
      if (other == null) {
        return;
      }
      if (other.UserId != 0) {
        UserId = other.UserId;
      }
      startLocationFormated_.Add(other.startLocationFormated_);
      endLocationFormated_.Add(other.endLocationFormated_);
      if (other.Distance != 0D) {
        Distance = other.Distance;
      }
      if (other.starttime_ != null) {
        if (starttime_ == null) {
          Starttime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Starttime.MergeFrom(other.Starttime);
      }
      if (other.endtime_ != null) {
        if (endtime_ == null) {
          Endtime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Endtime.MergeFrom(other.Endtime);
      }
      if (other.BreakCount != 0) {
        BreakCount = other.BreakCount;
      }
      if (other.AvgBreak != 0D) {
        AvgBreak = other.AvgBreak;
      }
      if (other.AvgSpeed != 0D) {
        AvgSpeed = other.AvgSpeed;
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
            UserId = input.ReadInt32();
            break;
          }
          case 18:
          case 17: {
            startLocationFormated_.AddEntriesFrom(input, _repeated_startLocationFormated_codec);
            break;
          }
          case 26:
          case 25: {
            endLocationFormated_.AddEntriesFrom(input, _repeated_endLocationFormated_codec);
            break;
          }
          case 33: {
            Distance = input.ReadDouble();
            break;
          }
          case 42: {
            if (starttime_ == null) {
              Starttime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Starttime);
            break;
          }
          case 50: {
            if (endtime_ == null) {
              Endtime = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(Endtime);
            break;
          }
          case 56: {
            BreakCount = input.ReadInt32();
            break;
          }
          case 65: {
            AvgBreak = input.ReadDouble();
            break;
          }
          case 73: {
            AvgSpeed = input.ReadDouble();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
