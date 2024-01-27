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
            services.AddScoped<IProductInventoryService, ProductInventoryService>();
            services.AddScoped<IProductAttributeService, ProductAttributeService>();
            services.AddScoped<IProductReviewService, ProductReviewService>();
            services.AddScoped<IProductReviewHelpfulnessService, ProductReviewHelpfulnessService>();
            services.AddScoped<IProductTagService, ProductTagService>();
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
            endpoints.MapPost(API_SCHEMA + "/GetAddressList", AddressHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetAddressById", AddressHandler.GetAddressById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddAddress", AddressHandler.AddAddress).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateAddress", AddressHandler.UpdateAddress).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteAddress", AddressHandler.DeleteAddress).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetCategoryList", CategoryHandler.GetList).RequirePermission("SALE.GET_CATEGORY_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetCategoryListForSelect", CategoryHandler.GetListForSelect).RequirePermission("SALE.GET_CATEGORY_LIST_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetCategoryHierarchy", CategoryHandler.GetCategoryHierarchy).RequirePermission("SALE.GET_CATEGORY_HIERARCHY");
            endpoints.MapGet(API_SCHEMA + "/GetCategoryById", CategoryHandler.GetCategoryById).RequirePermission("SALE.GET_CATEGORY_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddCategory", CategoryHandler.AddCategory).RequirePermission("SALE.ADD_CATEGORY");
            endpoints.MapPost(API_SCHEMA + "/UpdateCategory", CategoryHandler.UpdateCategory).RequirePermission("SALE.UPDATE_CATEGORY");
            endpoints.MapPost(API_SCHEMA + "/DeleteCategory", CategoryHandler.DeleteCategory).RequirePermission("SALE.DELETE_CATEGORY");

            endpoints.MapPost(API_SCHEMA + "/GetCountryList", CountryHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetCountrySeed", CountryHandler.GetCountrySeed).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetCountryById", CountryHandler.GetCountryById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddCountry", CountryHandler.AddCountry).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateCountry", CountryHandler.UpdateCountry).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteCountry", CountryHandler.DeleteCountry).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetCurrencyList", CurrencyHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetAllCurrencies", CurrencyHandler.GetAllCurrencies).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetCurrencyById", CurrencyHandler.GetCurrencyById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddCurrency", CurrencyHandler.AddCurrency).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateCurrency", CurrencyHandler.UpdateCurrency).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteCurrency", CurrencyHandler.DeleteCurrency).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetDeliveryDateList", DeliveryDateHandler.GetList).RequirePermission("SALE.GET_DELIVERY_DATE_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetDeliveryDateById", DeliveryDateHandler.GetDeliveryDateById).RequirePermission("SALE.GET_DELIVERY_DATE_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddDeliveryDate", DeliveryDateHandler.AddDeliveryDate).RequirePermission("SALE.ADD_DELIVERY_DATE");
            endpoints.MapPost(API_SCHEMA + "/UpdateDeliveryDate", DeliveryDateHandler.UpdateDeliveryDate).RequirePermission("SALE.UPDATE_DELIVERY_DATE");
            endpoints.MapPost(API_SCHEMA + "/DeleteDeliveryDate", DeliveryDateHandler.DeleteDeliveryDate).RequirePermission("SALE.DELETE_DELIVERY_DATE");

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

            endpoints.MapPost(API_SCHEMA + "/GetProductAttributeList", ProductAttributeHandler.GetList).RequirePermission("SALE.GET_MANUFACTURER_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetProductAttributesForSelect", ProductAttributeHandler.GetListForSelect).RequirePermission("SALE.GET_PRODUCT_ATTRIBUTE_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetProductAttributeById", ProductAttributeHandler.GetProductAttributeById).RequirePermission("SALE.GET_MANUFACTURER_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddProductAttribute", ProductAttributeHandler.AddProductAttribute).RequirePermission("SALE.ADD_MANUFACTURER");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductAttribute", ProductAttributeHandler.UpdateProductAttribute).RequirePermission("SALE.UPDATE_MANUFACTURER");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductAttribute", ProductAttributeHandler.DeleteProductAttribute).RequirePermission("SALE.DELETE_MANUFACTURER");

            endpoints.MapPost(API_SCHEMA + "/GetOrderList", OrderHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetOrderById", OrderHandler.GetOrderById).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetOrderPaymentById", OrderHandler.GetOrderPaymentById).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetAllOrderStatus", OrderHandler.GetAllOrderStatus).AllowAnonymous();
            endpoints.MapGet(API_SCHEMA + "/GetAllShippingStatus", OrderHandler.GetAllShippingStatus).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/AddOrder", OrderHandler.AddOrder).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrder", OrderHandler.UpdateOrder).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderState", OrderHandler.UpdateOrderState).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrder", OrderHandler.DeleteOrder).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetOrderDiscountList", OrderDiscountHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetOrderDiscountById", OrderDiscountHandler.GetOrderDiscountById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddOrderDiscount", OrderDiscountHandler.AddOrderDiscount).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderDiscount", OrderDiscountHandler.UpdateOrderDiscount).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderDiscount", OrderDiscountHandler.DeleteOrderDiscount).RequirePermission("SALE.");

            endpoints.MapGet(API_SCHEMA + "/GetOrderItemList", OrderItemHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetOrderItemById", OrderItemHandler.GetOrderItemById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddOrderItem", OrderItemHandler.AddOrderItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderItem", OrderItemHandler.UpdateOrderItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderItem", OrderItemHandler.DeleteOrderItem).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetOrderNoteList", OrderNoteHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetOrderNoteById", OrderNoteHandler.GetOrderNoteById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddOrderNote", OrderNoteHandler.AddOrderNote).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateOrderNote", OrderNoteHandler.UpdateOrderNote).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteOrderNote", OrderNoteHandler.DeleteOrderNote).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetPaymentList", PaymentHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetPaymentById", PaymentHandler.GetPaymentById).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetAllPaymentStatus", PaymentHandler.GetAllPaymentStatus).AllowAnonymous();
            endpoints.MapPost(API_SCHEMA + "/AddPayment", PaymentHandler.AddPayment).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdatePayment", PaymentHandler.UpdatePayment).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeletePayment", PaymentHandler.DeletePayment).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetProductList", ProductHandler.GetList).RequirePermission("SALE.GET_PRODUCT_LIST");
            endpoints.MapGet(API_SCHEMA + "/GetProductById", ProductHandler.GetProductById).RequirePermission("SALE.GET_PRODUCT_BY_ID");
            endpoints.MapGet(API_SCHEMA + "/GetProductsByIds", ProductHandler.GetProductsByIds).RequirePermission("SALE.GET_PRODUCTS_BY_IDS");
            endpoints.MapGet(API_SCHEMA + "/GetProductsByInput", ProductHandler.GetProductsByInput).RequirePermission("SALE.GET_PRODUCTS_BY_INPUT");
            endpoints.MapPost(API_SCHEMA + "/AddProduct", ProductHandler.AddProduct).RequirePermission("SALE.ADD_PRODUCT");
            endpoints.MapPost(API_SCHEMA + "/UpdateProduct", ProductHandler.UpdateProduct).RequirePermission("SALE.UPDATE_PRODUCT");
            endpoints.MapGet(API_SCHEMA + "/DeleteProduct", ProductHandler.DeleteProduct).RequirePermission("SALE.DELETE_PRODUCT");
            endpoints.MapGet(API_SCHEMA + "/RemoveProduct", ProductHandler.RemoveProduct).RequirePermission("SALE.REMOVE_PRODUCT");


            endpoints.MapPost(API_SCHEMA + "/GetProductInventoryList", ProductInventoryHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetProductInventoryById", ProductInventoryHandler.GetProductInventoryById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddProductInventory", ProductInventoryHandler.AddProductInventory).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductInventory", ProductInventoryHandler.UpdateProductInventory).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductInventory", ProductInventoryHandler.DeleteProductInventory).RequirePermission("SALE.");


            endpoints.MapPost(API_SCHEMA + "/GetProductReviewList", ProductReviewHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetProductReviewById", ProductReviewHandler.GetProductReviewById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddProductReview", ProductReviewHandler.AddProductReview).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductReview", ProductReviewHandler.UpdateProductReview).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductReview", ProductReviewHandler.DeleteProductReview).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetProductReviewHelpfulnessList", ProductReviewHelpfulnessHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetProductReviewHelpfulnessById", ProductReviewHelpfulnessHandler.GetProductReviewHelpfulnessById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddProductReviewHelpfulness", ProductReviewHelpfulnessHandler.AddProductReviewHelpfulness).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductReviewHelpfulness", ProductReviewHelpfulnessHandler.UpdateProductReviewHelpfulness).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductReviewHelpfulness", ProductReviewHelpfulnessHandler.DeleteProductReviewHelpfulness).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetProductTagList", ProductTagHandler.GetList).RequirePermission("SALE.GET_PRODUCT_TAG_LIST");
            endpoints.MapPost(API_SCHEMA + "/GetProductTagListForSelect", ProductTagHandler.GetListForSelect).RequirePermission("SALE.GET_PRODUCT_TAG_LIST_FOR_SELECT");
            endpoints.MapGet(API_SCHEMA + "/GetProductTagById", ProductTagHandler.GetProductTagById).RequirePermission("SALE.GET_PRODUCT_TAG_BY_ID");
            endpoints.MapPost(API_SCHEMA + "/AddProductTag", ProductTagHandler.AddProductTag).RequirePermission("SALE.ADD_PRODUCT_TAG");
            endpoints.MapPost(API_SCHEMA + "/UpdateProductTag", ProductTagHandler.UpdateProductTag).RequirePermission("SALE.UPDATE_PRODUCT_TAG");
            endpoints.MapPost(API_SCHEMA + "/DeleteProductTag", ProductTagHandler.DeleteProductTag).RequirePermission("SALE.DELETE_PRODUCT_TAG");


            endpoints.MapPost(API_SCHEMA + "/GetSearchTermList", SearchTermHandler.GetList).AllowAnonymous();//RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetSearchTermById", SearchTermHandler.GetSearchTermById).AllowAnonymous();//.RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddSearchTerm", SearchTermHandler.AddSearchTerm).AllowAnonymous();//.RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateSearchTerm", SearchTermHandler.UpdateSearchTerm).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteSearchTerm", SearchTermHandler.DeleteSearchTerm).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetShipmentList", ShipmentHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetShipmentById", ShipmentHandler.GetShipmentById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddShipment", ShipmentHandler.AddShipment).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateShipment", ShipmentHandler.UpdateShipment).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteShipment", ShipmentHandler.DeleteShipment).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetShipmentItemList", ShipmentItemHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetShipmentItemById", ShipmentItemHandler.GetShipmentItemById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddShipmentItem", ShipmentItemHandler.AddShipmentItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateShipmentItem", ShipmentItemHandler.UpdateShipmentItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteShipmentItem", ShipmentItemHandler.DeleteShipmentItem).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetShippingMethodList", ShippingMethodHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetAllShippingMethods", ShippingMethodHandler.GetAllShippingMethods).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetShippingMethodById", ShippingMethodHandler.GetShippingMethodById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddShippingMethod", ShippingMethodHandler.AddShippingMethod).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateShippingMethod", ShippingMethodHandler.UpdateShippingMethod).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteShippingMethod", ShippingMethodHandler.DeleteShippingMethod).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetShoppingCartItemList", ShoppingCartItemHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetShoppingCartItemById", ShoppingCartItemHandler.GetShoppingCartItemById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddShoppingCartItem", ShoppingCartItemHandler.AddShoppingCartItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateShoppingCartItem", ShoppingCartItemHandler.UpdateShoppingCartItem).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteShoppingCartItem", ShoppingCartItemHandler.DeleteShoppingCartItem).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetStateProvinceList", StateProvinceHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetStateProvinceById", StateProvinceHandler.GetStateProvinceById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddStateProvince", StateProvinceHandler.AddStateProvince).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateStateProvince", StateProvinceHandler.UpdateStateProvince).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteStateProvince", StateProvinceHandler.DeleteStateProvince).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetTaxCategoryList", TaxCategoryHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetTaxCategoryById", TaxCategoryHandler.GetTaxCategoryById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddTaxCategory", TaxCategoryHandler.AddTaxCategory).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateTaxCategory", TaxCategoryHandler.UpdateTaxCategory).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteTaxCategory", TaxCategoryHandler.DeleteTaxCategory).RequirePermission("SALE.");

            endpoints.MapPost(API_SCHEMA + "/GetTaxRateList", TaxRateHandler.GetList).RequirePermission("SALE.");
            endpoints.MapGet(API_SCHEMA + "/GetTaxRateById", TaxRateHandler.GetTaxRateById).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/AddTaxRate", TaxRateHandler.AddTaxRate).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/UpdateTaxRate", TaxRateHandler.UpdateTaxRate).RequirePermission("SALE.");
            endpoints.MapPost(API_SCHEMA + "/DeleteTaxRate", TaxRateHandler.DeleteTaxRate).RequirePermission("SALE.");


            return endpoints;
        }

    }
}