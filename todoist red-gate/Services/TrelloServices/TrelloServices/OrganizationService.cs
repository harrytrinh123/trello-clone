﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using todoist_red_gate.Controllers;
using todoist_red_gate.Models;
using todoist_red_gate.Services.TrelloServices.ITrelloServices;

namespace todoist_red_gate.Services.TrelloServices.TrelloServices
{
    public class OrganizationService : IOrganizationService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;
        public OrganizationService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = TrelloAuthenticationController.OAuthToken;
        }
        public async Task<Organization> Create(string displayName)
        {
            string url = BaseUrl + "/organizations?key=" + AppKey + "&token=" + Token + "&displayName=" + displayName;
            var httpResponse = await _client.PostAsync(url, null);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }

        public async Task Delete(string organizationId)
        {
            string url = BaseUrl + "/organizations/" + organizationId + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
        }

        public async Task<Organization> Get(string organizationId)
        {
            string url = BaseUrl + "/organizations/" +organizationId+ "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }

        public async Task<Organization> Update(string organizationId, Organization orgToUpdate)
        {
            string url = BaseUrl + "/organizations/" + organizationId + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(orgToUpdate);
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var task = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Models.Organization>(content);
        }
    }
}
