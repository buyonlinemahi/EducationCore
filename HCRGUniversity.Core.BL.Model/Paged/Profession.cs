using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.BL.Model.Paged
{
  public class Profession : BasePaged
    {
      public IEnumerable<BLModel.Profession> Professions { get; set; }
    }
}
