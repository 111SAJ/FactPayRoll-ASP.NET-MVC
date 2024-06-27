﻿using smartTechAuthenticator.Models;
using smartTechAuthenticator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace smartTechAuthenticator.Services.Customers
{
    public interface ICustomersService
    {
        (int TotalCount, int FilteredCount, dynamic Customers) GetCustomers(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCustomersTestHistory(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string CustomerId);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCustomersOrderHistory(int skip, int take, string sortColumn, string sortColumnDir, string searchValue,string CustomerId);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCustomersIPHistory(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string CustomerId);

        Task<ResponseModel> UpdateCustomerDetails(CustomerInfoViewModel customer);
        Task<ResponseModel> DeleteCustomerDetails(CustomerInfoViewModel customer);
        Task<CustomerInfoViewModel> GetCustomers(Guid CustomerId);
        List<ManageQrViewModel> GetQrData();
       ResponseModel GenrateQrCode(ManageQrViewModel QrCodeModel);
        Task<ResponseModel> DeleteQrData(ManageQrViewModel model);
        List<ProductViewModel> GetAllProductData();
        List<SelectListItem> GetAllProductData1();
        Task<ResponseModel> UpdateProductDetails(ProductViewModel model);
        List<CustomerInfoViewModel> GetProductList();

        Task<ResponseModel> CreateProduct(CustomerInfoViewModel model);
        (int TotalCount, int FilteredCount, dynamic Customers) GetQrData(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Customers) GetProductAllList(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);

        List<SelectListItem> GetProductCategory();
        Task<ResponseModel> DeleteProductDetails(CustomerInfoViewModel model);
        Task<CustomerInfoViewModel> GetProduct(Guid Id);
        Task<PlansViewModel> GetPlans(Guid Id);
        Task<CustomerInfoViewModel> GetAccountant(Guid Id);
        Task<ResponseModel> UpdateProductData(CustomerInfoViewModel model);
        ResponseModel menuassign(MenuPermissionViewModel data);
        (int TotalCount, int FilteredCount, dynamic Categorys) GetCategorys(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Categorys) GetAccountants(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Categorys) GetPlans(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);


        Task<ResponseModel> CreateCategory(CustomerInfoViewModel model);
        Task<ResponseModel> CreatePlans(PlansViewModel model);
        Task<ResponseModel> CreateAccountant(CustomerInfoViewModel model);
        Task<CustomerInfoViewModel> GetCategoryDetail(string Id);
        Task<PlansViewModel> GetPlanDetail(string Id);
        Task<CustomerInfoViewModel> GetAccountantDetail(string Id);
        Task<ResponseModel> UpdateCategoryData(CustomerInfoViewModel model);
        Task<ResponseModel> UpdatePlanData(PlansViewModel model);
        Task<ResponseModel> UpdateAccountantData(CustomerInfoViewModel model);
        Task<ResponseModel> DeleteCategoryDetails(CustomerInfoViewModel model);
        Task<ResponseModel> DeletePlanDetails(PlansViewModel model);
        Task<ResponseModel> DeleteAccountantDetails(CustomerInfoViewModel model);
        List<SelectListItem> GetProductByCategory(ProductCategoryViewModel model);
        List<ViewTestHistoryModel> ViewCustomerTestList(Guid CustomerId);
        int NoofCustomer();
        int NoofCodes();
        int NoofTest();
        int NoOfPendding();
        int NoOfPostingNews();
        int NoOfUnSolvedTicket();
        int NoOfTotalTicket();
        int NoOfOrderList();
        int NoOfDailyOrderList();


        Task<ResponseModel> ResetQRData(ManageQrViewModel model);
        ResponseModel CheckGenrateQrCode(string QrCode);
        ResponseModel UpdateQrCode(int Id,string QrImageName);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCheckQrData(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        //banner
        (int TotalCount, int FilteredCount, dynamic Categorys) GetBannerCarousal(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> CreateBannerCarousal(BannerCarouselViewModel model);
        Task<ResponseModel> DeleteBannerCarousalDetails(BannerCarouselViewModel model);
        Task<BannerCarouselViewModel> GetBannerCarousalDetail(string CategoryId);
        Task<ResponseModel> UpdateBannerCarousalData(BannerCarouselViewModel model);
        List<BannerCarouselViewModel> GrtBannerCarouselList();
        Task<ResponseModel> InsertNewsDetails(NewsViewModel model);
        Task<ResponseModel> DeleteNewsDetails(Guid Id);
        Task<ResponseModel> UpdateNewsDetails(NewsViewModel model);
        List<NewsViewModel> GetNewList();
        NewsViewModel GetNewsData(Guid Id);
        NewsViewModel PostNewsData(Guid Id);
        Task<ProductNewViewModel> GetProductById(Guid ProductId);
        (int TotalCount, int FilteredCount, dynamic Categorys) Tickets(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Categorys) Tickets(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string startDate,string endDate, int status);
        Task<TicketViewModel> TicketDetails(Guid? id);
        List<TicketMessageSystemViewModels>ViewUserMessageList(Guid UserId, Guid? TicketId);
        Task<ResponseModel> UpdateTicket(TicketViewModel res);
        Task<CustomerInfoViewModel> GetProfileDetails(Guid UserId);
        //Task<CustomerInfoViewModel> GetProfileDetails(Guid UserId);
        Task<ResponseModel> UpdateProfileDetails(CustomerInfoViewModel model);

        (int TotalCount, int FilteredCount, dynamic Categorys) Shipping(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> CreateShiping(ShippingViewModel model);
        List<SelectListItem> GetStates();
        Task<ShippingViewModel> EditShip(string id);
        List<SelectListItem> GetDistrictts(int StateId, int districtId);
        Task<ResponseModel> UpdateShip(ShippingViewModel model);
        Task<ResponseModel> DeleteShipingDetails(string Id);
        (int TotalCount, int FilteredCount, dynamic Categorys) GetOrders(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        (int TotalCount, int FilteredCount, dynamic Categorys) GetOrders(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string date, string status);
        Task<OrderHistory> OrderHistoryDetails(string Id);
        CustomerInfoViewModel GetCustomerDetail(Guid? Id);
        Task<ResponseModel> Updatetarcking(string shipstatus, string OrderId,string TrackingNu, string TrackingCN);
        List<SelectListItem> GetNewsCategory();
        (int TotalCount, int FilteredCount, dynamic News) GetNewsDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        List<NewsViewModel> GrtNewsAllList();
        Task<ResponseModel> Create(CustomerInfoViewModel customer);
        Task<CustomerInfoViewModel> Subadmindetails(Guid CustomerId);
        Task<ResponseModel> UpdateSubadmindetails(CustomerInfoViewModel customer);
        Task<ResponseModel> DeleteSubadminDetails(CustomerInfoViewModel customer);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCertificateList(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string data);
        (int TotalCount, int FilteredCount, dynamic Customers) GetAdmindata(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<TrackingForms> EditVerify(int Id);
        Task<ResponseModel> UpdateVerify(TrackingForms customer);
        Task<ResponseModel> AddGallery(List<ProductGalleryViewModel> gallery);
        Task<ResponseModel> Savedata(AboutViewModel data);
        List<AboutViewModel> GetAboutList();
        AboutViewModel GetAboutData(Guid Id);
        Task<ResponseModel> UpdateAboutDetails(AboutViewModel model);
        Task<ResponseModel> DeleteAboutDetails(Guid Id);
        (int TotalCount, int FilteredCount, dynamic News) GetAboutDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> SaveFAQdata(FaqViewModel data);
        List<FaqViewModel> GetFAQList();
        FaqViewModel GetFAQData(Guid Id);
        Task<ResponseModel> UpdateFAQDetails(FaqViewModel model);
        Task<ResponseModel> DeleteFAQDetails(Guid Id);
        (int TotalCount, int FilteredCount, dynamic News) GetFAQDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> SaveHelpdata(HelpGuidViewModel helpdata);
        List<HelpGuidViewModel> GetHelpGuidList();
        HelpGuidViewModel GetHelpGuidData(Guid Id);
        Task<ResponseModel> UpdateHelpGuidDetails(HelpGuidViewModel Helpdata);
        Task<ResponseModel> DeleteHelpGuidDetails(Guid Id);
        (int TotalCount, int FilteredCount, dynamic News) GetHelpGuidDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> SaveTermPrivacydata(TermPrivacyViewModel TermPrivacydata);
        List<TermPrivacyViewModel> GetTermPrivacyList();
        TermPrivacyViewModel GetTermPrivacyData(Guid Id);
        Task<ResponseModel> UpdaTermPrivacyDetails(TermPrivacyViewModel TermPrivacydata);
        Task<ResponseModel> DeleteTermPrivacytDetails(Guid Id);
        (int TotalCount, int FilteredCount, dynamic News) GetTermPrivacyDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        List<ProductGalleryViewModel> GetGallery(string ProductId);
        Task<ResponseModel> DeleteGalleryImage(string Id);
        Task<TrackingFormsViewModel> GetCertificateData(int Id);
        (int TotalCount, int FilteredCount, dynamic Categorys) OrderHistoryList(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> Saveform(string Name, Guid UserId);

        (int TotalCount, int FilteredCount, dynamic Customers) GetStaffRollList(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> UpdateRole(CustomerInfo model);
        Task<ResponseModel> SaveSimpleText(FormPropertyViewModel data);
        Task<ResponseModel> SaveTextField(FormPropertyViewModel data);
        Task<ResponseModel> SaveDateField(FormPropertyViewModel data);
        Task<ResponseModel> Savecheckbox(FormPropertyViewModel data);
        Task<ResponseModel> SaveBlackcheckbox(FormPropertyViewModel data);
        Task<FormPropertyViewModel> GetForm(Guid? Id);
        Task<FormPropertyViewModel> GetFormDetail(Guid? FormIds);
        ResponseModel deleteformproperty(Guid? Id);
        Task<int> UpdateNumber(Guid? Id);
        (int TotalCount, int FilteredCount, dynamic Customers) getform(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
        Task<ResponseModel> DeleteFormDetails(Guid? Id);
        Task<ResponseModel> saveformresponce(FormPropertyViewModel data);
        Task<CustomerInfoViewModel> GetProduct();
        Task<ProductViewModel> FormResponseDetails(Guid? UserId);
        Task<ResponseModel> assignproform(CustomerInfoViewModel data);
        FormRes GetFormDetails();
        Task<ResponseModel> TicketMessage(TicketMessageSystemViewModels TicketMessage);
        (int TotalCount, int FilteredCount, dynamic Customers) GetCertificateFilterList(int skip, int take, string sortColumn, string sortColumnDir, string searchValue, string data, string date);
        (int TotalCount, int FilteredCount, dynamic Customers) FormResponseDetails(int skip, int take, string sortColumn, string sortColumnDir, string searchValue);
    }
}
