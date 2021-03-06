﻿using System;

namespace HCRGUniversity.Core.Data.Model
{
   public  class News : Base.BaseOrganizationColumn
    {
        public int NewsID { get; set; }
        public int NewsSectionID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsType { get; set; }
        public bool NewsEditorPick { get; set; }
        public DateTime NewsDate { get; set; }
        public string NewsAuthor { get; set; }
   }
}
