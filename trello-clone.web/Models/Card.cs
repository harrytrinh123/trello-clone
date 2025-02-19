﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trello_clone.web.Models
{
    public class Card
    {
        public string id { get; set; }
        public object checkItemStates { get; set; }
        public bool closed { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        public DescData descData { get; set; }
        public object dueReminder { get; set; }
        public string idBoard { get; set; }
        public string idList { get; set; }
        public List<object> idMembersVoted { get; set; }
        public int idShort { get; set; }
        public object idAttachmentCover { get; set; }
        public List<string> idLabels { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public double pos { get; set; }
        public string shortLink { get; set; }
        public bool isTemplate { get; set; }
        public string cardRole { get; set; }
        public Badges badges { get; set; }
        public bool dueComplete { get; set; }
        public object due { get; set; }
        public List<string> idChecklists { get; set; }
        public List<object> idMembers { get; set; }
        public List<Label> labels { get; set; }
        public string shortUrl { get; set; }
        public object start { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
        public Cover cover { get; set; }
    }
}
