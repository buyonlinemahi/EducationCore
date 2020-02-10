namespace HCRGUniversity.Core.Data.SqlServer.Constant
{
    public class StoredProcedureConst
    {
        private const string SQLExec = "EXEC ";

        public struct CarouselSetUpRepositoryProcedure
        {
            public const string GetCarouselSetUpAll = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CarouselSetUpAll @OrganizationID";
            public const string GetAllCarouselSetUp = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllCarouselSetUp @OrgID, @ClientID";
            public const string UpdateCarouselSetUp = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_CarouselSetUp  @CarouselID,@CarouselTitle,@CarouselDescription,@CarouselBgColor,@NewsID";
        }

        public struct CollegeEducatoinRepositoryProcedure
        {
            public const string GetCollegeEducationByEducationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CollegeEducationByEducationID @EducationID";
        }

        public struct ProfessionEducatoinRepositoryProcedure
        {
            public const string GetProfessionEducationByEducationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProfessionEducationByEducationID @EducationID";
        }


        public struct EducationRepositoryProcedure
        {
            public const string GetEducationCollegeAll = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationCollegeByCollegeID";

            public const string GetEducationFormatByEducationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationFormatByEducationID @EducationID";

            public const string GetEducationAndProfession = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationAndProfession @OrganizationID";

            public const string GetEducationAndEducationFormat = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationAndEducationFormat @OrganizationID";

            public const string GetEducationDetailPageContentByEducationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationDetailContentByEducationID @EducationID";

            public const string GetEducationNewsSearchByTextPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationNewsSearchByTextPaged @searchText,@UserID,@OrganizationID,@skip,@take";

            public static string GetEducationNewsSearchByTextPagedCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationNewsSearchByTextPagedCount @searchText,@UserID,@OrganizationID";

            public const string GetEducationCollegeByEducationFormatIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationCollegeByCollegeOREduFormatIDPaged NULL,@EducationFormatID,@skip,@take,@OrganizationID";

            public const string GetEducationCollegeByEducationFormatIDAndCollegeIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationCollegeByCollegeOREduFormatIDPaged @CollegeID,@EducationFormatID,@UserID,@skip,@take,@OrganizationID";

            public const string GetEducationByProfessionIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationByProfessionIDPaged @ProfessionID,@UserID,@skip,@take,@OrganizationID";

            public const string GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationByCollegeOREduFormatIDORDeptIDORPrfIDPaged @CollegeID,@EducationFormatID,@ProfessionID,@UserID,@skip,@take,@OrganizationID";

            public const string GetEducationCollegeByCollegeIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationCollegeByCollegeIDPaged @CollegeID,@userID,@skip,@take,@OrganizationID";

            public const string GetAllPagedEducationProfession = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedEducationProfession @Skip,@Take,@OrganizationID";
            public const string GetCountEducationProfession = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationProfessionCount";
            public const string GetAllPagedEducationByfilter = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedEducationSearchResult @CourseName,@Skip,@Take,@ClientID,@OrgID";
            public const string GETCourseExpirySendEmailAlert = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "GET_CourseExpirySendEmailAlert @OrganizationID";
            public const string UpdateMyEducationCompletedToPassed = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_MyEducationCompletedToPassed @EducationID";
            public const string UpdateEducationModulesTime = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationModulesTime @EducationID";
            public const string GetEducationLatestByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationLatestByUserID @UserID,@OrganizationID";
            public const string GetEducationsByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationsByClientID  @ClientID";



            public static string GetEducationReadyToDisplayByEducationName = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationReadyToDisplayByEducationName  @EducationName,@OrganizationID,@Skip,@Take";
            public static string GetEducationReadyToDisplayByEducationNameCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationReadyToDisplayByEducationNameCount  @EducationName,@OrganizationID";

            public const string GetCourseCatalogByPreview = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CourseCatalogByPreview @Skip,@Take,@ClientID,@OrgID";
            public const string GetCourseCatalogByPublished = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CourseCatalogByPublished @Skip,@Take,@ClientID,@OrgID";
            public const string GetCourseCatalogByExpired = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CourseCatalogByExpired @Skip,@Take,@ClientID,@OrgID"; 
        }

        public struct MyEducationRepositoryProcedure
        {
            public const string GetMyEducationCompletedByUserIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationCompletedByUserIDPaged @userID,@skip,@take";
            public const string GetMyEducationCompletedByUserIDPagedCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationCompletedByUserIDPagedCount @userID";

            public const string GetMyEducationInProgressByUserIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationInProgressByUserIDPaged @userID,@skip,@take";
            public static string GetMyEducationInProgressByUserIDPagedCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationInProgressByUserIDPagedCount @userID";

            public const string GetMyEducationDetailByUserIDPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationDetailByUserIDPaged @userID,@skip,@take";
            public const string AddEducationModuleToMyEducationByEducationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Add_EducationModuleToMyEducationByEducationID @MEID,@EducationID";
            public const string GetMyEducationModulesDetailsByMEID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationModulesDetailsByMEID @MEID,@UserID";
            public const string GetMyEducationModulesDetailByMEMID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationModulesDetailByMEMID @MEMID";
            public const string UpdateMyEducationModuleTimeLeft = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_MyEducationModuleTimeLeft @MEMID, @TimeLeft";
            public const string UpdateMyEducationExpiredByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_MyEducationExpiredByUserID @UserID";
            public const string GetCertificateDetailByMEID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CertificateDetailByMEID @MEID";
            public const string GetMyEducationDetailByUserIDPagedCOUNT = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationDetailByUserIDPagedCOUNT @userID";
            public const string GetMyEducationByID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_MyEducationByID @MEID";

            
        }

        public struct ProfessionRepositoryProcedure
        {
            public const string GetProfessionsByCollegeID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProfessionsByCollegeID @CollegeID";
            public const string GetProfessionNotAssociateWithEducation = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProfessionNotAssociateWithEducation @EducationID";
            public static string GetAllProfessionByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllProfessionByClientID @ClientID";
            public static string GetAllPagedProfessionByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedProfessionByClientID @Skip,@Take,@ClientID";
            public static string GetAllPagedProfessionByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedProfessionByClientIDCount @ClientID";
            public static string GetAllProfessionByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllProfessionByOrganizationID @OrganizationID";

            public const string GetAllPagedProfessionByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedProfessionByOrganizationID @Skip,@Take,@OrganizationID";
            public static string GetAllPagedProfessionByOrganizationIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedProfessionByOrganizationIDCount @OrganizationID";
        }

        public struct EducationFormatRepositoryProcedure 
        {
            public const string GetEducationFormatNotAssociateWithEducation = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationFormatNotAssociateWithEducation @EducationID";
            public const string GetAllPagedEducationFormat = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedEducationFormat @Skip,@Take";
            public const string GetEducationFormatByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationFormatByClientID @ClientID";
            public const string GetAllEducationFormatByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllEducationFormatByOrganizationID @OrganizationID";
            public const string GetAllEducationFormatByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllEducationFormatByClientID @ClientID";

        }

        public struct ShoppingRepositoryProcedure
        {
            public const string GetEducationShoppingCartByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationShoppingTemp @UserID";
            public const string GetShoppingDetailsByShippingPaymentID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ShoppingDetailsByShippingPaymentID @ShippingPaymentID";
            public const string GetEducationShoppingTempByShippingPaymentID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EducationShoppingTempByShippingPaymentID @ShippingPaymentID";
            public const string DeleteEducationFromShoppingCart = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_EducationFromShoppingCart @EducationShoppingTempID";
            public const string DeleteEducationFromShoppingCartByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_EducationFromShoppingCartByUserID @userID";
            public const string DeleteProductFromShoppingCart = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_ProductFromShoppingCart @ProductShoppingTempID";
            public const string DeleteProductFromShoppingCartByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_ProductFromShoppingCartByUserID @userID";
            public static string DeleteEducationShoppingCartByShippingPaymentID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_EducationShoppingCartByShippingPaymentID @ShippingPaymentID";
            public static string CheckAnyProductsIsOutOfStock = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Check_AnyProductsIsOutOfStock @UserID";
            public static string GetShoppingCartCoursesByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ShoppingCartCoursesByUserID @UserID";
        }

        public struct DiscountCouponRepositoryProcedure
        {
            public const string UpdateDiscountCouponStatus = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_DiscountCouponStatus @CouponCode,@CoupanValid";
            public const string GetDiscountCouponForCourses = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_DiscountCouponForCourses @ClientID";
            public const string GetDiscountCouponForProducts = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_DiscountCouponForProducts @ClientID";
            public const string GetAllPagedDiscountCoupon = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedDiscountCoupon @Skip,@Take,@OrganizationID";
            public const string GetAllPagedDiscountCouponForCourse = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedDiscountCouponForCourse @Skip,@Take,@OrganizationID";
            public const string GetDiscountCouponCountForCourse = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_DiscountCouponCountForCourses @ClientID";
        }

        public struct NewsRepositoryProcedure
        {
            public const string GetAllNewsDetail = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedNewsWithPhotoAndVideoAll @Type,@Skip,@Take,@OrganizationID";
            public const string GetNewsDetailByNewsID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_NewsFullDetailByNewsID @NewsID,@Type";
            public const string GetNewsDetailBySectionIDandType = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedNewsWithPhotoAndVideoBySectionIdAndTypeAll @Type,@SectionID,@Skip,@Take";
            public const string GetNewslatest = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_Newslatest @OrganizationID";
            public const string GetNewsDetailsAccordingToNewsSearch = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_NewsDetailsAccordingToNewsSearch  @NewsTitle,@OrganizationID";
            public const string GetAllNewsDetailCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_NewsWithPhotoAndVideoAllCount @Type,@OrganizationID";
            public const string GetNewsDetailBySectionIDandTypeCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_NewsWithPhotoAndVideoBySectionIdAndTypeAllCount @Type,@SectionID,@OrganizationID";
            public const string GetAllNewsByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllNewsByOrganizationID @OrgID, @ClientID";
            public const string GetNewsLetterByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_NewsLetterByClientID @ClientID, @OrgID";
        }


        public struct EducationModuleRepositoryProcedure
        {
            public const string AddEducationModule = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Insert_EducationModule @EducationID,@EducationModuleName,@EducationModuleDescription,@EducationModuleTime,@EducationModuleDate ,@EducationModulePosition";
            public const string UpdateEducationModule = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationModule @EducationModuleID,@EducationID,@EducationModuleName,@EducationModuleDescription,@EducationModuleTime,@EducationModuleDate ,@EducationModulePosition";
            public const string UpdateEducationModuleTime = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationModuleTime @EducationModuleID,@EducationModuleTime";
            public const string DeleteEducationModule = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_EducationModule @EducationModuleID";
            public const string GetAllPagedEducationModuleByEid = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedEducationModuleByEid @EducationId,@Skip,@Take";
            public static string GetOrganizationClientByEducationModuleID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrganizationClientByEducationModuleID @EducationModuleID";
        }

        public struct EducationModuleFileRepositoryProcedure
        {
            public const string DeleteEducationModuleFilesByFileTypeIdAndEducationModuleID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Delete_EducationModuleFilesByFileTypeIdAndEducationModuleID @EducationModuleFileID,@FileTypeID";
        }

        public struct FAQRepositoryProcedure
        {
            public const string Get_FAQByFaqCatIDAll = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_FAQByFaqCatIDAll @FAQCatID";
            public const string Get_FAQAll = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_FAQAll @OrganizationID";
            public const string GetAllPagedFAQs = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedFAQ @Skip, @Take, @OrganizationID";
            public const string GetAllFAQAccordingToOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllFAQAccordingToOrganizationID @OrgID, @ClientID";
        }

        public struct FAQCategoriesRepositoryProcedure
        {
            public const string GetAllFAQCategoriesAccordingToOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllFAQCategoriesAccordingToOrganizationID  @OrgID, @ClientID";
        }
        public struct PrivacyPolicyRepositoryProcedure
        {
            public const string GetAllPrivacyPolicyAccordingToOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPrivacyPolicyAccordingToOrganizationID @OrgID, @ClientID";
        }

        public struct AboutUsRepositoryProcedure
        {
            public const string GetAllAboutUsByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllAboutUsByOrganizationID @OrgID, @ClientID";
        }

        public struct AccreditationRepositoryProcedure
        {
            public const string GetAllAccreditationsByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllAccreditationsByOrganizationID @OrgID, @ClientID";
        }

        public struct CertificationRepositoryProcedure
        {
            public const string GetAllCertificationsByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllCertificationsByOrganizationID @OrgID, @ClientID";
        }

        public struct IndustryResearchRepositoryProcedure
        {
            public const string GetAllIndustryResearchesByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllIndustryResearchesByOrganizationID @OrgID, @ClientID";
        }

        public struct TrainingAndSeminarRepositoryProcedure
        {
            public const string GetAllTrainingAndSeminarByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllTrainingAndSeminarByOrganizationID @OrgID, @ClientID";
        }

        public struct UserSubscriptionRepositoryProcedure
        {
            public const string GetAllUserSubscriptionByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllUserSubscriptionByOrganizationID @OrgID, @ClientID";
        }
        public struct HomeContentRepositoryProcedure
        {
            public const string GetAllHomeContentByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllHomeContentByOrganizationID @ClientID,@OrgID";
        }

        public struct TermsAndConditionsRepositoryProcedure
        {
            public const string GetAllTermAndConditionsAccordingToClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllTermAndConditionsAccordingToClientID @ClientID";
        }
        public struct ReturnPolicyRepositoryProcedure
        {
            public const string GetAllReturnPolicysAccordingToClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllReturnPolicysAccordingToClientID @ClientID";
        }
        public struct AccreditorRepositoryProcedure
        {
            public const string GetAllAccreditorsByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllAccreditorsByOrganizationID @ClientID,@OrgID";
        }
        public struct DeliveryTermRepositoryProcedure
        {
            public const string GetAllDeliveryTermsAccordingToClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllDeliveryTermsAccordingToClientID @ClientID";
        }
        public struct PreTestQuestionRepositoryProcedure
        {
            public const string GetAllPreTestQuestionDetailByEID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PreTestQuestionsByEducationID @EducationID";
        }
        public struct ExamQuestionRepositoryProcedure
        {
            public const string GetAllExamQuestionDetailByEID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ExamQuestionsByEducationID @EducationID";
            public const string GetExamQuestionWrongAnswered = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ExamQuestionWrongAnswered @MEID";
        }
        public struct EvaluationQuestionRepositoryProcedure
        {
            public const string GetAllEvaluationQuestionDetailByEID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EvaluationQuestionsByEducationID @EducationID";
            public const string UpdateEducationEvaluation = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationEvaluation @EducationID";
            public const string AddEvaluationQuestionsFromEvaluationPredefinedQuestions = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Add_EvaluationQuestionsFromEvaluationPredefinedQuestions @EvaluationID";
           

        }
        public struct EducationEvaluationRepositoryProcedure
        {
            public const string UpdateEducationEvaluation = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationEvaluation @EducationID,@EvaluationID,@CourseEvaluationID";
        }
        public struct EducationPreTestQuestionRepository
        {
            public const string UpdateEducationPreTestQuestion = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationPreTestQuestion @EducationID,@PreTestID,@CoursePreTestID";
        }
        public struct EducationExamQuestionRepository
        {
            public const string UpdateEducationExamQuestion = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_EducationExamQuestion  @EducationID,@ExamID,@CourseExamID";
        }

        public struct OrganizationRepository
        {
            public const string GetOrganizationMenuByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrganizationMenuByOrganizationID  @OrganizationID";
        }


        public struct EventsRepositoryProcedure
        {
            public const string GetEventsAllPaged = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EventsAllPaged @skip,@take, @ClientID,@OrgID";
            public const string GetEventsAllPagedCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EventsAllPagedCount @ClientID,@OrgID";
            public const string GetEventsByEventDateRange = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EventsByEventDateRange @startDate,@endDate,@OrganizationID";
            public const string GetEventsUpcoming = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EventsUpcoming @OrganizationID";
        }

        public struct FacultyRepositoryProcedure
        {
            public const string GetPagedFaculty = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedFaculty @Skip,@Take,@OrganizationID ";
            public const string GetAllFacultiesByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllFacultiesByOrganizationID @Skip, @Take, @OrgID, @ClientID";
            public const string GetAllFacultiesByOrganizationIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllFacultiesByOrganizationIDCount @OrgID, @ClientID";            
            
        }
        public struct SuggestCourseProcedure
        {
            public const string GetPagedSuggestCourse = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedSuggestCourse @Skip,@Take";
            public const string GetAllSuggestCoursesByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllSuggestCoursesByOrganizationID @ClientID,@OrgID";            
        }
        public struct EnterprisePackageRegisterRepositoryProcedur
        {
            public const string GetPagedEnterprisePackageRegisters = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedEnterprisePackageRegisters @Skip,@Take,@OrganizationID";
            public const string GetAllEnterprisePackageRegistersByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllEnterprisePackageRegistersByOrganizationID  @OrganizationID";
        }

        public struct LogSessionRepositoryProcedure
        {
            public const string GetLogSessionByUserName = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_LogSessionByUserName @username,@skip,@take,@OrganizationID";
            public const string GetLogSessionByUserNameCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_LogSessionByUserNameCount @username,@OrganizationID";
        }

        public struct ProductRepositoryProcedure
        {
            public const string GetPagedProductByProductName = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PagedProductByProductName @searchText,@Skip,@Take";
            public static string GetProductShoppingTempByID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProductShoppingTempByID @ProductShoppingTempID";

            public const string GetProductPurchaseDetailCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProductPurchaseDetailCount @Skip,@Take,@OrganizationID";
            public const string GetProductPurchaseDetail = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ProductPurchaseDetail @Skip,@Take,@OrganizationID"; 
        }

        public struct CertificationTitleOptionProcedure
        {
            public const string GETCourseNameDropDownList = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "GET_CourseNameDropDownList @OrganizationID";
        }


        public struct ProductShippingDetailRepositoryProcedure
        {
            public const string UpdateProductShippingDetailByShippingPaymentID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_ProductShippingDetailByShippingPaymentID @ShippingPaymentID,@CreatedBy,@ProductShippedOn";

        }
        public struct ClientRepositoryProcedure
        {
            public const string GetOrganizationClientsByID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrganizationClientsByID @OrganizationID,@Skip,@Take";
            public const string GetOrganizationClientsByIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrganizationClientsByIDCount @OrganizationID";
            public const string GetClientsByPlanID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ClientsByPlanID  @PlanID";
            public static string GetClientDetailByFilter = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ClientDetailByLoggedClientID @SearchText,@Skip,@Take,@ClientID";
            public static string GetClientDetailByFilterCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ClientDetailByLoggedClientIDCount @SearchText,@ClientID";
            public static string GetOrganizationContactByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrganizationContactByOrganizationID @OrgID, @ClientID";
            public static string GetOrgSingleContactByOrgID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_OrgSingleContactByOrgID @OrganizationID";
            public static string UpdateClientSessionIDByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_ClientSessionIDByClientID @ClientID,@ClientSessionID";
            public static string ResetClientSessionID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Reset_ClientSessionID @ClientID";
        }
        public struct PlanRepositoryProcedure
        {
            public const string GetAllPlanAccToPackages = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPlanAccToPackages";
            public const string GetAllPlansByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPlansByClientID  @ClientID";
            public const string GetAllPagedPlanByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedPlanByClientID  @ClientID,@OrgID,@Skip,@Take";
            public const string GetAllPagedPlanByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedPlanByClientIDCount  @ClientID,@OrgID";
        }

        public struct UserRepositoryProcedure
        {
            public const string GetDefaulClientAdminByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_DefaulClientAdminByOrganizationID @OrganizationID";
            public const string GetUsersByPlanID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UsersByPlanID  @PlanID";
            public const string GetUserMenuGroupByMenuIDs = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserMenuGroupByMenuIDs @MenuIDs, @OrganizationID";
            public const string GetUserMenuGroupByGroupName = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserMenuGroupByGroupName @GroupName, @OrganizationID";
            public static string GetAllPagedUserByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllPagedUserByClientID @Skip, @Take,@ClientID";
            public static string GetUserDetailByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserDetailByClientID @SearchText,@Skip, @Take,@ClientID";
            public static string GetUserDetailByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserDetailByClientIDCount @SearchText,@ClientID";
            public static string GetAllUserMenuGroupAndPremissionAccordingToOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllUserMenuGroupAndPremissionAccordingToOrganizationID @OrganizationID";
            public const string GetClientAndUserbySearchCriterias = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ClientAndUserbySearchCriterias @OrganizationID,@ClientTypeID,@SelectionTypeName,@SelectionClientTypeID,@SearchText";
            public static string UpdateUserSessionIDByUserID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Update_UserSessionIDByUserID @UserID,@UserSessionID";
            public static string ResetUserSessionID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Reset_UserSessionID @UserID";
        }
        public struct MenuRepository
        {
            public const string GetUserMenuByGroupID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserMenuByGroupID @UserMenuGroupID";

            public static string GetUserMenuBySpecialMenuID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UserMenuBySpecialMenuID @SpecialMenuIDs";
        }
        public struct CoursesPlanRepositoryProcedure
        {
            public const string CheckCoursesAreadyExistsForPlan = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Check_CoursesAreadyExistsForPlan  @PlanID,@CourseID";
            public const string GetCoursesPlanAccToPlanID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_CoursesPlanAccToPlanID  @PlanID";
            public const string GetAllCoursesPlan = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllCoursesPlan";
        }
        public struct UserPlanRepositoryProcedure
        {
            public const string GetUsersPlanAccToPlanID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_UsersPlanAccToPlanID  @PlanID";
            public const string CheckUserAreadyExistsForPlan = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Check_UserAreadyExistsForPlan  @PlanID,@UserID";
            public const string GetAllUsersPlan = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllUsersPlan";

            public static string AddMyEducationRecordByPlanID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Add_MyEducationRecordByPlanID  @PlanID";
        }

        public struct ExamRepositoryProcedure
        {
            public const string GetExamDetailsByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ExamDetailsByClientID @SearchText, @ClientID,@OrgID,@Skip,@Take";
            public const string GetExamDetailsByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_ExamDetailsByClientIDCount @SearchText, @ClientID,@OrgID";
            public static string GetAllActiveExamByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllActiveExamByClientID @ClientID";
        }

        public struct PreTestRepositoryProcedure
        {
            public const string GetPreTestDetailsByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PreTestDetailsByClientID @SearchText, @ClientID,@OrgID,@Skip,@Take";
            public const string GetPreTestDetailsByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_PreTestDetailsByClientIDCount @SearchText, @ClientID,@OrgID";
            public static string GetAllActivePreTestByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllActivePretestByClientID @ClientID";
        }

        public struct EvaluationRepositoryProcedure
        {
            public const string GetEvaluationDetailsByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EvaluationDetailsByClientID @SearchText,@ClientID,@OrgID,@Skip,@Take";
            public const string GetEvaluationDetailsByClientIDCount = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_EvaluationDetailsByClientIDCount @SearchText,@ClientID,@OrgID";
            public static string GetAllActiveEvaluationByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllActiveEvaluationByClientID @ClientID";
        }

        public struct CollegeRepositoryProcedure
        {
            public const string GetAllCollegeByClientID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllCollegeByClientID @ClientID";
            public static string GetAllCollegeByOrganizationID = SQLExec + Consts.Schema.DBO + Consts.Schema.DOT + "Get_AllCollegeByOrganizationID @OrganizationID";
        }

       
    }
} 