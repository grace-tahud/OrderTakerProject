using Newtonsoft.Json;
using OrderTakerProject.Core.Models;
using OrderTakerProject.Core.Models.DTOs;
using OrderTakerProject.UI.Models;
using OrderTakerProject.UI.Services.Interface;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace OrderTakerProject.UI.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private HttpClient _httpClient = new HttpClient();
        public DashboardService()
        {
            
        }
        

        public async Task<CustomerViewModel> GetCustomers()
        {
            var response = new CustomerViewModel();

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetCustomers")

            };
            using (var customerListResponse = await _httpClient.SendAsync(httpRequest))
            {
                var stringBody = customerListResponse.Content.ReadAsStringAsync();
                var customers = await customerListResponse.Content.ReadFromJsonAsync<GetCustomersResponse>();
                response.Customers = customers.Customers;
            }
            return response;
        }

        public async Task<OrderViewModel> GetExistingOrder(int purchaseOrderId)
        {
            var response = new OrderViewModel();
            var orderRequest = new GetPurchaseItemsRequest
            {
                PurchaseOrderId = purchaseOrderId
            };
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetPurchaseOrderById"),
                Content = new StringContent(JsonConvert.SerializeObject(orderRequest))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }

            };
            using (var purchaseOrderResponse = await _httpClient.SendAsync(httpRequest))
            {
                var stringBody = purchaseOrderResponse.Content.ReadAsStringAsync();
                var purchaseOrder = await purchaseOrderResponse.Content.ReadFromJsonAsync<GetPurchaseOrderResponse>();

                response.PurchaseOrder = purchaseOrder.PurchaseOrder;
            }

            var itemsRequest = new GetPurchaseItemsRequest
            {
                PurchaseOrderId = purchaseOrderId
            };

            var httpRequest1 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetPurchaseItemsByOrder"),
                Content = new StringContent(JsonConvert.SerializeObject(itemsRequest))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }

            };
            using (var purchaseItemsListResponse = await _httpClient.SendAsync(httpRequest1))
            {
                var stringBody = purchaseItemsListResponse.Content.ReadAsStringAsync();
                var purchaseItems = await purchaseItemsListResponse.Content.ReadFromJsonAsync<GetPurchaseItemsResponse>();
                response.PurchaseItems = purchaseItems.PurchaseItems;
            }
            return response;
        }

        public async Task<PurchaseItemViewModel> GetItems(int purchaseOrderId)
        {
            var response = new PurchaseItemViewModel();

            
            var itemsRequest = new GetPurchaseItemsRequest
            {
                PurchaseOrderId = purchaseOrderId
            };

            var httpRequest1 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetPurchaseItemsByOrder"),
                Content = new StringContent(JsonConvert.SerializeObject(itemsRequest))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }

            };
            using (var purchaseItemsListResponse = await _httpClient.SendAsync(httpRequest1))
            {
                var stringBody = purchaseItemsListResponse.Content.ReadAsStringAsync();
                var purchaseItems = await purchaseItemsListResponse.Content.ReadFromJsonAsync<GetPurchaseItemsResponse>();
                response.PurchaseItems = purchaseItems.PurchaseItems;
            }
            return response;
        }

        public async Task<OrderViewModel> GetOrders()
        {
            var response = new OrderViewModel();
            GetPurchaseOrdersResponse purchaseOrders = new GetPurchaseOrdersResponse();
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetPurchaseOrders")

            };
            using (var purchaseOrderListResponse = await _httpClient.SendAsync(httpRequest))
            {
                var stringBody = purchaseOrderListResponse.Content.ReadAsStringAsync();
                purchaseOrders = await purchaseOrderListResponse.Content.ReadFromJsonAsync<GetPurchaseOrdersResponse>();
                response.PurchaseOrders = purchaseOrders.PurchaseOrders;
                response.PurchaseOrder = purchaseOrders.PurchaseOrders.OrderByDescending(o => o.Id).FirstOrDefault();
            }
            var purchaseOrder = purchaseOrders.PurchaseOrders.OrderByDescending(o => o.Id).FirstOrDefault();
            var itemsRequest = new GetPurchaseItemsRequest
            {
                PurchaseOrderId = purchaseOrder != null ? purchaseOrder.Id + 1: 1
            };

            var httpRequest1 = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetPurchaseItemsByOrder"),
                Content = new StringContent(JsonConvert.SerializeObject(itemsRequest))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }

            };
            using (var purchaseItemsListResponse = await _httpClient.SendAsync(httpRequest1))
            {
                var stringBody = purchaseItemsListResponse.Content.ReadAsStringAsync();
                var purchaseItems = await purchaseItemsListResponse.Content.ReadFromJsonAsync<GetPurchaseItemsResponse>();
                response.PurchaseItems = purchaseItems.PurchaseItems;
            }
            return response;
        }

        public async Task<SKUViewModel> GetSkus()
        {
            var response = new SKUViewModel();

            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7043/api/order/taker/GetSKUs")

            };
            using (var skuListResponse = await _httpClient.SendAsync(httpRequest))
            {
                var stringBody = skuListResponse.Content.ReadAsStringAsync();
                var skus = await skuListResponse.Content.ReadFromJsonAsync<GetSKUsResponse>();
                response.SKUs = skus.SKUs;
            }
            return response;
        }
    }
}
