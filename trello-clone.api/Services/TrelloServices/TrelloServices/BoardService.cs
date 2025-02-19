﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
    public class BoardService : IBoardService
    {
        private const string BaseUrl = "https://api.trello.com/1";
        private readonly HttpClient _client;
        private readonly string AppKey;
        private readonly IConfiguration _config;
        public BoardService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
            AppKey = _config.GetValue<string>("Trello:ConsumerKey");
        }

        public async Task<Models.Board> Create(string nameBoard, string Token)
        {
            string url = BaseUrl + "/boards/?key=" + AppKey + "&token=" + Token + "&name=" + nameBoard;
            var httpResponse = await _client.PostAsync(url, null);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var task = JsonConvert.DeserializeObject<Models.Board>(content);
            return task;
        }

        public async Task Delete(string id, string Token)
        {
            string url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.DeleteAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not delelte");
            }
        }

        public async Task<Models.Board> Get(string id, string Token)
        {
            string url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Can not retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var board = JsonConvert.DeserializeObject<Models.Board>(content);
            return board;
        }

        public async Task<List<Models.Membership>> GetMemberships(string idBoard, string Token)
        {
            string url = BaseUrl + "/boards/" + idBoard + "/memberships?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.Membership>>(content);
            return tasks;
        }

        public async Task<Models.Board> Update(string id, Models.Board task, string Token)
        {
            var url = BaseUrl + "/boards/" + id + "?key=" + AppKey + "&token=" + Token;
            var content = JsonConvert.SerializeObject(task);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            var httpResponse = await _client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update label");
            }

            var updatedTask = JsonConvert.DeserializeObject<Models.Board>(await httpResponse.Content.ReadAsStringAsync());
            return updatedTask;
        }

        // Get actions on a card


        // Custom API
        public async Task<List<Models.Card>> GetAllCurentDateCardOfBoard(string boardId, string Token)
        {
            //string urlGetAllList = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            //var allListHttpResponse = await _client.GetAsync(urlGetAllList);
            //if(!allListHttpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Cannot get lists");
            //}
            //var allListContent = await allListHttpResponse.Content.ReadAsStringAsync();
            //var listList = JsonConvert.DeserializeObject<List<Models.List>>(allListContent);

            //List<Models.Card> allCard = new List<Models.Card>();
            //foreach (var list in listList)
            //{
            //    string urlGetCard = BaseUrl + "/lists/" + list.id + "/cards?key=" + AppKey + "&token=" + Token;
            //    var allCardHttpResponse = await _client.GetAsync(urlGetCard);
            //    var allCardContent = await allCardHttpResponse.Content.ReadAsStringAsync();
            //    var listCard = JsonConvert.DeserializeObject<List<Models.Card>>(allCardContent)
            //        .Where(x=>x.due != null).Where(x=>DateTime.Compare((DateTime)(x.due), DateTime.Now.Date) == 0);
            //    allCard.AddRange(listCard);
            //}
            //return allCard;
            return null;
        }

        public async Task<List<Models.Card>> GetAllCardBetween(string boardId, DateTime start, DateTime end, string Token)
        {
            return null;
            //string urlGetAllList = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            //var allListHttpResponse = await _client.GetAsync(urlGetAllList);
            //if (!allListHttpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Cannot get lists");
            //}
            //var allListContent = await allListHttpResponse.Content.ReadAsStringAsync();
            //var listList = JsonConvert.DeserializeObject<List<Models.List>>(allListContent);

            //List<Models.Card> allCard = new List<Models.Card>();
            //foreach (var list in listList)
            //{
            //    string urlGetCard = BaseUrl + "/lists/" + list.id + "/cards?key=" + AppKey + "&token=" + Token;
            //    var allCardHttpResponse = await _client.GetAsync(urlGetCard);
            //    var allCardContent = await allCardHttpResponse.Content.ReadAsStringAsync();
            //    var listCard = JsonConvert.DeserializeObject<List<Models.Card>>(allCardContent);
            //    listCard = listCard.Where(x => x.due != null).Where(x => x.due >= start && x.due <= end).ToList();
            //    allCard.AddRange(listCard);

            //}
            //return allCard;
        }

        // Week sumary, get list cards had complete, get list cards un finished
        public async Task<Models.WeekSumary> GetSumaryOfWeek(string boardId, string Token)
        {
            return null;
            //string urlGetAllList = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            //var allListHttpResponse = await _client.GetAsync(urlGetAllList);
            //if (!allListHttpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Cannot get lists");
            //}
            //var allListContent = await allListHttpResponse.Content.ReadAsStringAsync();
            //var listList = JsonConvert.DeserializeObject<List<Models.List>>(allListContent);

            //List<Models.Card> cardsComplete = new List<Models.Card>();
            //List<Models.Card> cardsUnfinished = new List<Models.Card>();
            //WeekSumary res = new WeekSumary();
            //foreach (var list in listList)
            //{
            //    string urlGetCard = BaseUrl + "/lists/" + list.id + "/cards?key=" + AppKey + "&token=" + Token;
            //    var allCardHttpResponse = await _client.GetAsync(urlGetCard);
            //    var allCardContent = await allCardHttpResponse.Content.ReadAsStringAsync();
            //    var listCard = JsonConvert.DeserializeObject<List<Models.Card>>(allCardContent);
            //    List<Models.Card> listCardCom = new List<Models.Card>();
            //    List<Models.Card> listCardUnf = new List<Models.Card>();
            //    if (list.name.Equals("Done"))
            //    {
            //        listCardCom = listCard.ToList();
            //        res.AddCardComplete(listCardCom);
            //    }
            //    listCardUnf = listCard.Where(x => x.due != null)
            //            .Where(x => x.due < DateTime.Now).ToList();
            //    res.AddCardUnfinished(listCardUnf);

            //}
            //return res;
        }

        // Get all cards unfinished of the board

        public async Task<List<Card>> GetCardsUnfinished(string boardId, string Token)
        {
            return null;
            //string urlGetAllList = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            //var allListHttpResponse = await _client.GetAsync(urlGetAllList);
            //if (!allListHttpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Cannot get lists");
            //}
            //var allListContent = await allListHttpResponse.Content.ReadAsStringAsync();
            //var listList = JsonConvert.DeserializeObject<List<Models.List>>(allListContent);

            //List<Models.Card> allCard = new List<Models.Card>();
            //foreach (var list in listList)
            //{
            //    string urlGetCard = BaseUrl + "/lists/" + list.id + "/cards?key=" + AppKey + "&token=" + Token;
            //    var allCardHttpResponse = await _client.GetAsync(urlGetCard);
            //    var allCardContent = await allCardHttpResponse.Content.ReadAsStringAsync();
            //    var listCard = JsonConvert.DeserializeObject<List<Models.Card>>(allCardContent);
            //    if (!list.name.Equals("Done"))
            //    {
            //        listCard = listCard.Where(x => x.due < DateTime.Now).ToList();
            //        allCard.AddRange(listCard);
            //    }

            //}
            //return allCard;
        }

        // Get all cards unfinished of the board from start date to end date
        public async Task<List<Card>> GetCardsUnfinished(string boardId, DateTime start, DateTime end, string Token)
        {
            return null;
            //string urlGetAllList = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            //var allListHttpResponse = await _client.GetAsync(urlGetAllList);
            //if (!allListHttpResponse.IsSuccessStatusCode)
            //{
            //    throw new Exception("Cannot get lists");
            //}
            //var allListContent = await allListHttpResponse.Content.ReadAsStringAsync();
            //var listList = JsonConvert.DeserializeObject<List<Models.List>>(allListContent);

            //List<Models.Card> allCard = new List<Models.Card>();
            //foreach (var list in listList)
            //{
            //    string urlGetCard = BaseUrl + "/lists/" + list.id + "/cards?key=" + AppKey + "&token=" + Token;
            //    var allCardHttpResponse = await _client.GetAsync(urlGetCard);
            //    var allCardContent = await allCardHttpResponse.Content.ReadAsStringAsync();
            //    var listCard = JsonConvert.DeserializeObject<List<Models.Card>>(allCardContent);
            //    if (!list.name.Equals("Done"))
            //    {
            //        listCard = listCard.Where(x => x.due != null).Where(x => x.due >= start && x.due <= end).ToList();
            //        allCard.AddRange(listCard);
            //    }
            //}
            //return allCard;
        }

        public async Task<List<List>> GetListsOnBoard(string boardId, string Token)
        {
            string url = BaseUrl + "/boards/" + boardId + "/lists?key=" + AppKey + "&token=" + Token;
            var httpResponse = await _client.GetAsync(url);
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve task");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<List<Models.List>>(content);
            return tasks;
        }
    }
}
