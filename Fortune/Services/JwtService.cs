using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Fortune.Services
{
    public interface IJwtService
    {
        string Encode(object value);
        T Decode<T>(string jwt);
    }
    public class JwtService : IJwtService
    {
        public T Decode<T>(string jwt)
        {
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);

            return decoder.DecodeToObject<T>(jwt, secret, verify: true);
        }

        public string Encode(object value)
        {
            var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(value, secret);
        }
    }
}
