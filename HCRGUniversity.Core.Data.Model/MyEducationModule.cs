﻿
using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class MyEducationModule
    {
        public int MEMID { get; set; }
        public int EducationModuleID { get; set; }
        public int MEID { get; set; }
        public bool Completed { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string TimeLeft { get; set; }
    }
}