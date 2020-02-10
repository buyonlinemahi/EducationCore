using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IResource
    {
        IEnumerable<Resource> getAllResource(int _organizationID);

      

        #region TrainingAndSeminar
		int AddTrainingAndSeminar(TrainingAndSeminar _trainingAndSeminar);
        int UpdateTrainingAndSeminar(TrainingAndSeminar _trainingAndSeminar);
        TrainingAndSeminar GetTrainingAndSeminarAll(int _organizationID);
        IEnumerable<BLModel.TrainingAndSeminar> GetAllTrainingAndSeminarByOrganizationID(int OrganizationID, int ClientID);
	#endregion
   
       #region Accreditation
		 int AddAccreditation(Accreditation _accreditation);
        int UpdateAccreditation(Accreditation _accreditation);
        Accreditation GetAccreditationAll(int _organizationID);
        IEnumerable<BLModel.Accreditation> GetAllAccreditationsByOrganizationID(int OrganizationID, int ClientID);

	#endregion
 
       #region PrivacyPolicy
		 int AddPrivacyPolicy(PrivacyPolicy _privacy);
        int UpdatePrivacyPolicy(PrivacyPolicy _privacy);
        DLModel.PrivacyPolicy GetPrivacyPolicyAll(int ClientID);
        DLModel.PrivacyPolicy GetPrivacyPolicyByID(int PrivacyPolicyID);
        IEnumerable<BLModel.PrivacyPolicy> GetAllPrivacyPolicyAccordingToOrganizationID(int OrganizationID, int ClientID);
	#endregion
                
       #region TermsCondition
		 int AddTermsCondition(TermsCondition _termsCondition);
        int UpdateTermsCondition(TermsCondition _termsCondition);
        DLModel.TermsCondition GetTermsConditionAll(int ClientID);
        DLModel.TermsCondition GetTermsConditionByID(int TermsConditionID);
        IEnumerable<DLModel.TermsCondition> GetAllTermAndConditionsAccordingToClientID(int ClientID);
	    #endregion

         #region NewsLetter
        int AddNewsLetter(NewsLetter _newsLetter);
        int UpdateNewsLetter(NewsLetter _newsLetter);
        NewsLetter GetNewsLetterAll(int _organizationID);
        IEnumerable<BLModel.NewsLetter> GetNewsLetterByClientID(int clientID, int orgID);
          #endregion

        #region Return Policy
        int AddReturnPolicy(DLModel.ReturnPolicy _returnPolicy);
        int UpdateReturnPolicy(DLModel.ReturnPolicy _returnPolicy);
        DLModel.ReturnPolicy GetReturnPolicyAll(int ClientID);
        DLModel.ReturnPolicy GetReturnPolicyByID(int ReturnPolicyID);
        IEnumerable<DLModel.ReturnPolicy> GetAllReturnPolicysAccordingToClientID(int ClientID);
        #endregion

        #region Delivery Term
        int AddDeliveryTerm(DLModel.DeliveryTerm _deliveryTerm);
        int UpdateDeliveryTerm(DLModel.DeliveryTerm _deliveryTerm);
        DLModel.DeliveryTerm GetDeliveryTermAll(int ClientID);
        DLModel.DeliveryTerm GetDeliveryTermByID(int DeliveryTermID);
        IEnumerable<DLModel.DeliveryTerm> GetAllDeliveryTermsAccordingToClientID(int ClientID);
        #endregion


        #region Certification
        int AddCertification(DLModel.Certification _certification);
        int UpdateCertification(DLModel.Certification _certification);
        DLModel.Certification GetCertificationAll(int _organizationID);
        IEnumerable<BLModel.Certification> GetAllCertificationsByOrganizationID(int OrganizationID, int ClientID);
        #endregion

    }
}
