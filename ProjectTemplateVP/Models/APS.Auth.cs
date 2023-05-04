using Autodesk.Forge;
using RestSharp;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ProjectTemplateVP.Models
{
    public partial class APS
    {
        public string GetAuthUrl()
        {
            //var url = //build url here
            //return url;
        }

        public void GetCodeChallenge()
        {

        }

        public void GetCodeVerifier()
        {
            /*            const string src = "abcdefghijklmnopqrstuvwxyz_" +
                            "0123456789-";
                        Random random = new Random();
                        int length = 43;
                        var sb = new StringBuilder();
                        for (var i = 0; i < length; i++)
                        {
                            var c = src[random.Next(0, src.Length)];
                            sb.Append(c);
                        }*/
            var rBytes = new byte[24];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(rBytes);
                var base64 = Convert.ToBase64String(rBytes);
                Debug.WriteLine(base64);
                var result = Regex.Replace(base64, "[A-Za-z0-9]", "");
                Debug.WriteLine(result);
            }
        }

/*        public async Task<Tokens> GenerateTokens(string code)
        {
            dynamic internalAuth = await new ThreeLeggedApi().GettokenAsync(_clientId, _clientSecret, "authorization_code", code, _callbackUri);
*//*            dynamic publicAuth = await new ThreeLeggedApi().RefreshtokenAsync(_clientId, _clientSecret, "refresh_token", internalAuth.refresh_token, PublicTokenScopes);
*//*            return new Tokens
            {
*//*                PublicToken = publicAuth.access_token,
*//*                InternalToken = internalAuth.access_token,
*//*                RefreshToken = publicAuth.refresh_token,
*//*                ExpiresAt = DateTime.Now.ToUniversalTime().AddSeconds(internalAuth.expires_in)
            };
        }*/
    }
}
