using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
  public  class ExamQuestion :BasePaged
    {
      public IEnumerable<DLModel.ExamQuestion> ExamQuestions { get; set; }
    }
}
