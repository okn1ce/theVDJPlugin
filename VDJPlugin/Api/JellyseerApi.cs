using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using VDJPlugin.Models;
using VDJPlugin.Configuration;

namespace VDJPlugin.Api
{
    public class JellyseerApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public JellyseerApi(PluginConfiguration config)
        {
            _baseUrl = config.JellyseerApiUrl;
            _apiKey = config.JellyseerApiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _apiKey);
        }

        public async Task<List<JellyseerMedia>> SearchMediaAsync(string query)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/search?query={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<JellyseerMedia>>();
        }

        public async Task<List<JellyseerProfile>> GetQualityProfilesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/profile");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<JellyseerProfile>>();
        }

        public async Task<List<JellyseerRootFolder>> GetRootFoldersAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/rootfolder");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<JellyseerRootFolder>>();
        }

        public async Task RequestMediaAsync(int tmdbId, string mediaType, int profileId, int rootFolderId)
        {
            var request = new
            {
                tmdbId = tmdbId,
                mediaType = mediaType,
                profileId = profileId,
                rootFolderId = rootFolderId
            };

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/request", request);
            response.EnsureSuccessStatusCode();
        }
    }
} 