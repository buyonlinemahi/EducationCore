using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class EvaluationQuestion : BasePaged
    {
        public IEnumerable<DLModel.EvaluationQuestion> EvaluationQuestions { get; set; }
    }
}
