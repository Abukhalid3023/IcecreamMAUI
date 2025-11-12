using IcecreamMAUI.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IcecreamMaui.Services
{
    public class AuthService
    {
        private const string AuthKey = "AuthKey";
        public LoggedInUser User { get; private set; }

        public string? Token { get; private set; }

        public void Signin(AuthResponseDTO dto)
        {
            var serialzed = JsonSerializer.Serialize(dto);
            Preferences.Default.Set(AuthKey, serialzed);
            (User, Token) = dto;
        }

        public void Initialize()
        {
            if (Preferences.Default.ContainsKey(AuthKey))
            {
                var serialized = Preferences.Default.Get<string?>(AuthKey, null);
                if (string.IsNullOrWhiteSpace(serialized))
                {
                    Preferences.Default.Remove(AuthKey);
                }
                else
                {
                    (User, Token) = JsonSerializer.Deserialize<AuthResponseDTO>(serialized)!;
                }
            }
        }

        public void Signout()
        {
            Preferences.Default.Remove(AuthKey);
            (User, Token) = (null, null);

        }
    }
}
