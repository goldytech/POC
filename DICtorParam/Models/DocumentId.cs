
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace DICtorParam.Models
{
    [JsonConverter(typeof(DocumentIdJsonConverter))]
    [TypeConverter(typeof(DocumentIdTypeConverter))]
    public readonly struct DocumentId : IComparable<DocumentId>, IEquatable<DocumentId>
    {
        public Guid Value { get; }

        public DocumentId(Guid value)
        {
            Value = value;
        }

        public static DocumentId New() => new DocumentId(Guid.NewGuid());
        public static DocumentId Empty { get; } = new DocumentId(Guid.Empty);

        public static DocumentId Assign(string value) => new DocumentId(Guid.Parse(value));

        public bool Equals(DocumentId other) => this.Value.Equals(other.Value);
        public int CompareTo(DocumentId other) => Value.CompareTo(other.Value);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is DocumentId other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
        public static bool operator ==(DocumentId a, DocumentId b) => a.CompareTo(b) == 0;
        public static bool operator !=(DocumentId a, DocumentId b) => !(a == b);

        class DocumentIdJsonConverter : JsonConverter<DocumentId>
        {
           

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DocumentId);
            }

            public override DocumentId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return new DocumentId(reader.GetGuid());
            }

            public override void Write(Utf8JsonWriter writer, DocumentId value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.Value);
            }
        }

        class DocumentIdTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                var stringValue = value as string;
                if (!string.IsNullOrEmpty(stringValue)
                    && Guid.TryParse(stringValue, out var guid))
                {
                    return new DocumentId(guid);
                }

                return base.ConvertFrom(context, culture, value);

            }
        }
    }
}