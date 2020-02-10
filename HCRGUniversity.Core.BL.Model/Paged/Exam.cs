using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
  public class Exam:BasePaged
    {
      public IEnumerable<BLModel.Exam> Exams { get; set; }
    }
}
