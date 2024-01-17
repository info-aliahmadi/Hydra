using Hydra.Infrastructure.ModuleExtension;
using Hydra.Infrastructure.Security.Extensions;
using Hydra.Sale.Api.Handler;
using Hydra.Sale.Api.Services;
using Hydra.Sale.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Hydra.Sale.Api.Endpoints
{
    public class SaleModule : IModule
    {
        private const string API_SCHEMA = "/Sale";
        public IServiceCollection RegisterModules(IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDeliveryDateService, DeliveryDateService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDiscountService, OrderDiscountService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderNoteService, OrderNoteService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductInventoryService, ProductInventoryService>();
            services.AddScoped<IProductManufacturerService, ProductManufacturerService>();
            services.AddScoped<IProductPictureService, ProductPictureService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductReviewHelpfulnessService, ProductReviewHelpfulnessService>();
            services.AddScoped<IProductTagService, ProductTagService>();
            services.AddScoped<IRelatedProductService, RelatedProductService>();
            services.AddScoped<ISearchTermService, SearchTermService>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<IShipmentItemService, ShipmentItemService>();
            services.AddScoped<IShippingMethodService, ShippingMethodService>();
            services.AddScoped<IShoppingCartItemService, ShoppingCartItemService>();
            services.AddScoped<IStateProvinceService, StateProvinceService>();
            services.AddScoped<ITaxCategoryService, TaxCategoryService>();
            services.AddScoped<ITaxRateService, TaxRateService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost(API_SCHEMA + "/GetAddressList", AddressHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetAddressById", AddressHandler.GetAddressById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddAddress", AddressHandler.AddAddress).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateAddress", AddressHandler.UpdateAddress).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteAddress", AddressHandler.DeleteAddress).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetCategoryList", CategoryHandler.GetList).RequirePermission("SALE.GET_CATEGORY_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetCategoryListForSelect", CategoryHandler.GetListForSelect).RequirePermission("SALE.GET_CATEGORY_LIST_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetCategoryHierarchy", CategoryHandler.GetCategoryHierarchy).RequirePermission("SALE.GET_CATEGORY_HIERARCHY");
            endpoints.MapGet(API_SCHEMA + "/GetCategoryById", CategoryHandler.GetCategoryById).RequirePermission("SALE.GET_CATEGORY_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddCategory", CategoryHandler.AddCategory).RequirePermission("SALE.ADD_CATEGORY");
            endpoints.MapPost(API_SCHEMA + "/UpdateCategory", CategoryHandler.UpdateCategory).RequirePermission("SALE.UPDATE_CATEGORY");
            endpoints.MapPost(API_SCHEMA + "/DeleteCategory", CategoryHandler.DeleteCategory).RequirePermission("SALE.DELETE_CATEGORY");

            endpoints.MapPost(API_SCHEMA + "/GetCountryList", CountryHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetCountrySeed", CountryHandler.GetCountrySeed).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetCountryById", CountryHandler.GetCountryById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddCountry", CountryHandler.AddCountry).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateCountry", CountryHandler.UpdateCountry).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteCountry", CountryHandler.DeleteCountry).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetCurrencyList", CurrencyHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetCurrencyById", CurrencyHandler.GetCurrencyById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddCurrency", CurrencyHandler.AddCurrency).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateCurrency", CurrencyHandler.UpdateCurrency).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteCurrency", CurrencyHandler.DeleteCurrency).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetDeliveryDateList", DeliveryDateHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetDeliveryDateById", DeliveryDateHandler.GetDeliveryDateById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddDeliveryDate", DeliveryDateHandler.AddDeliveryDate).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateDeliveryDate", DeliveryDateHandler.UpdateDeliveryDate).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteDeliveryDate", DeliveryDateHandler.DeleteDeliveryDate).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetDiscountList", DiscountHandler.GetList).RequirePermission("SALE.GET_DISCOUNT_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetDiscountListForSelect", DiscountHandler.GetListForSelect).RequirePermission("SALE.GET_LIST_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetDiscountById", DiscountHandler.GetDiscountById).RequirePermission("SALE.GET_DISCOUNT_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddDiscount", DiscountHandler.AddDiscount).RequirePermission("SALE.ADD_DISCOUNT");
            endpoints.MapPost(API_SCHEMA + "/UpdateDiscount", DiscountHandler.UpdateDiscount).RequirePermission("SALE.UPDATE_DISCOUNT");
            endpoints.MapPost(API_SCHEMA + "/DeleteDiscount", DiscountHandler.DeleteDiscount).RequirePermission("SALE.DELETE_DISCOUNT");

            endpoints.MapPost(API_SCHEMA + "/GetManufacturerList", ManufacturerHandler.GetList).RequirePermission("SALE.GET_MANUFACTURER_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetManufacturersForSelect", ManufacturerHandler.GetListForSelect).RequirePermission("SALE.GET_MANUFACTURERS_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetManufacturerById", ManufacturerHandler.GetManufacturerById).RequirePermission("SALE.GET_MANUFACTURER_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddManufacturer", ManufacturerHandler.AddManufacturer).RequirePermission("SALE.ADD_MANUFACTURER");
            endpoints.MapPost(API_SCHEMA + "/UpdateManufacturer", ManufacturerHandler.UpdateManufacturer).RequirePermission("SALE.UPDATE_MANUFACTURER");
            endpoints.MapPost(API_SCHEMA + "/DeleteManufacturer", ManufacturerHandler.DeleteManufacturer).RequirePermission("SALE.DELETE_MANUFACTURER");

            endpoints.MapPost(API_SCHEMA + "/GetOrderList", OrderHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetOrderById", OrderHandler.GetOrderById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddOrder", OrderHandler.AddOrder).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrder", OrderHandler.UpdateOrder).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrder", OrderHandler.DeleteOrder).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetOrderDiscountList", OrderDiscountHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetOrderDiscountById", OrderDiscountHandler.GetOrderDiscountById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddOrderDiscount", OrderDiscountHandler.AddOrderDiscount).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderDiscount", OrderDiscountHandler.UpdateOrderDiscount).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderDiscount", OrderDiscountHandler.DeleteOrderDiscount).RequirePermission("");

            endpoints.MapGet(API_SCHEMA + "/GetOrderItemList", OrderItemHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetOrderItemById", OrderItemHandler.GetOrderItemById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddOrderItem", OrderItemHandler.AddOrderItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderItem", OrderItemHandler.UpdateOrderItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderItem", OrderItemHandler.DeleteOrderItem).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetOrderNoteList", OrderNoteHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetOrderNoteById", OrderNoteHandler.GetOrderNoteById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddOrderNote", OrderNoteHandler.AddOrderNote).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderNote", OrderNoteHandler.UpdateOrderNote).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderNote", OrderNoteHandler.DeleteOrderNote).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetPaymentList", PaymentHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetPaymentById", PaymentHandler.GetPaymentById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddPayment", PaymentHandler.AddPayment).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdatePayment", PaymentHandler.UpdatePayment).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeletePayment", PaymentHandler.DeletePayment).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductList", ProductHandler.GetList).RequirePermission("SALE.GET_PRODUCT_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetProductById", ProductHandler.GetProductById).RequirePermission("SALE.GET_PRODUCT_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddProduct", ProductHandler.AddProduct).RequirePermission("SALE.ADD_PRODUCT");
            endpoints.MapPost(API_SCHEMA + "/UpdateProduct", ProductHandler.UpdateProduct).RequirePermission("SALE.UPDATE_PRODUCT");
            endpoints.MapPost(API_SCHEMA + "/DeleteProduct", ProductHandler.DeleteProduct).RequirePermission("SALE.DELETE_PRODUCT");

            endpoints.MapPost(API_SCHEMA + "/GetProductCategoryList", ProductCategoryHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductCategoryById", ProductCategoryHandler.GetProductCategoryById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductCategory", ProductCategoryHandler.AddProductCategory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductCategory", ProductCategoryHandler.UpdateProductCategory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductCategory", ProductCategoryHandler.DeleteProductCategory).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductInventoryList", ProductInventoryHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductInventoryById", ProductInventoryHandler.GetProductInventoryById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductInventory", ProductInventoryHandler.AddProductInventory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductInventory", ProductInventoryHandler.UpdateProductInventory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductInventory", ProductInventoryHandler.DeleteProductInventory).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductManufacturerList", ProductManufacturerHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductManufacturerById", ProductManufacturerHandler.GetProductManufacturerById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductManufacturer", ProductManufacturerHandler.AddProductManufacturer).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductManufacturer", ProductManufacturerHandler.UpdateProductManufacturer).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductManufacturer", ProductManufacturerHandler.DeleteProductManufacturer).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductPictureList", ProductPictureHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductPictureById", ProductPictureHandler.GetProductPictureById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductPicture", ProductPictureHandler.AddProductPicture).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductPicture", ProductPictureHandler.UpdateProductPicture).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductPicture", ProductPictureHandler.DeleteProductPicture).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductReviewList", ProductReviewHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductReviewById", ProductReviewHandler.GetProductReviewById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductReview", ProductReviewHandler.AddProductReview).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductReview", ProductReviewHandler.UpdateProductReview).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductReview", ProductReviewHandler.DeleteProductReview).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductReviewHelpfulnessList", ProductReviewHelpfulnessHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductReviewHelpfulnessById", ProductReviewHelpfulnessHandler.GetProductReviewHelpfulnessById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductReviewHelpfulness", ProductReviewHelpfulnessHandler.AddProductReviewHelpfulness).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductReviewHelpfulness", ProductReviewHelpfulnessHandler.UpdateProductReviewHelpfulness).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductReviewHelpfulness", ProductReviewHelpfulnessHandler.DeleteProductReviewHelpfulness).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetProductTagList", ProductTagHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetProductTagById", ProductTagHandler.GetProductTagById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddProductTag", ProductTagHandler.AddProductTag).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductTag", ProductTagHandler.UpdateProductTag).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductTag", ProductTagHandler.DeleteProductTag).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetRelatedProductList", RelatedProductHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetRelatedProductById", RelatedProductHandler.GetRelatedProductById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddRelatedProduct", RelatedProductHandler.AddRelatedProduct).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateRelatedProduct", RelatedProductHandler.UpdateRelatedProduct).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteRelatedProduct", RelatedProductHandler.DeleteRelatedProduct).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetSearchTermList", SearchTermHandler.GetList).AllowAnonymous();//RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetSearchTermById", SearchTermHandler.GetSearchTermById).AllowAnonymous();//.RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddSearchTerm", SearchTermHandler.AddSearchTerm).AllowAnonymous();//.RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateSearchTerm", SearchTermHandler.UpdateSearchTerm).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteSearchTerm", SearchTermHandler.DeleteSearchTerm).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetShipmentList", ShipmentHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetShipmentById", ShipmentHandler.GetShipmentById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddShipment", ShipmentHandler.AddShipment).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateShipment", ShipmentHandler.UpdateShipment).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteShipment", ShipmentHandler.DeleteShipment).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetShipmentItemList", ShipmentItemHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetShipmentItemById", ShipmentItemHandler.GetShipmentItemById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddShipmentItem", ShipmentItemHandler.AddShipmentItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateShipmentItem", ShipmentItemHandler.UpdateShipmentItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteShipmentItem", ShipmentItemHandler.DeleteShipmentItem).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetShippingMethodList", ShippingMethodHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetShippingMethodById", ShippingMethodHandler.GetShippingMethodById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddShippingMethod", ShippingMethodHandler.AddShippingMethod).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateShippingMethod", ShippingMethodHandler.UpdateShippingMethod).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteShippingMethod", ShippingMethodHandler.DeleteShippingMethod).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetShoppingCartItemList", ShoppingCartItemHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetShoppingCartItemById", ShoppingCartItemHandler.GetShoppingCartItemById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddShoppingCartItem", ShoppingCartItemHandler.AddShoppingCartItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateShoppingCartItem", ShoppingCartItemHandler.UpdateShoppingCartItem).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteShoppingCartItem", ShoppingCartItemHandler.DeleteShoppingCartItem).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetStateProvinceList", StateProvinceHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetStateProvinceById", StateProvinceHandler.GetStateProvinceById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddStateProvince", StateProvinceHandler.AddStateProvince).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateStateProvince", StateProvinceHandler.UpdateStateProvince).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteStateProvince", StateProvinceHandler.DeleteStateProvince).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetTaxCategoryList", TaxCategoryHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetTaxCategoryById", TaxCategoryHandler.GetTaxCategoryById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddTaxCategory", TaxCategoryHandler.AddTaxCategory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateTaxCategory", TaxCategoryHandler.UpdateTaxCategory).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteTaxCategory", TaxCategoryHandler.DeleteTaxCategory).RequirePermission("");

            endpoints.MapPost(API_SCHEMA + "/GetTaxRateList", TaxRateHandler.GetList).RequirePermission("");
            endpoints.MapGet(API_SCHEMA + "/GetTaxRateById", TaxRateHandler.GetTaxRateById).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/AddTaxRate", TaxRateHandler.AddTaxRate).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/UpdateTaxRate", TaxRateHandler.UpdateTaxRate).RequirePermission("");
            endpoints.MapPost(API_SCHEMA + "/DeleteTaxRate", TaxRateHandler.DeleteTaxRate).RequirePermission("");


            return endpoints;
        }

    }
}