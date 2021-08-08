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
    public class LabelService : ILabelService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private string AppKey;
        private string Token;
        
        public LabelService(HttpClient client)
        {
            _client = client;
            AppKey = "07e57a8c0ff7205b8202479a1d9ed50d";
            Token = TrelloAuthenticationController.OAuthToken;
        }

        public async Task<Label> Create(string idBoard, string name, string color)
        {
            string url = BaseUrl + "/labels?key=" + AppKey + "&token=" + Token + "&name=" + name + "&color=" + color + "&idBoard=" + idBoard;
            var httpResponse = await _client.PostAsync(url, null);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retriece task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Label>(content);
            return task;
        }

        public async Task Delete(string id)
        {
            string url = BaseUrl + "/labels/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not delelte");
            }
        }

        public async Task<Label> Get(string id)
        {
            string url = BaseUrl + "/label/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if(!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var label = JsonConvert.DeserializeObject<Models.Label>(content);
            return label;
        }

        public async Task<Label> Update(string id, Label task)
        {
            var url = BaseUrl + "/labels/" + id + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update label");
            }

            var updatedTask = JsonConvert.DeserializeObject<Label>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }
    }
}
