using OrderIntegration.BCompany.Bussiness.Dto;
using System.ServiceModel;

namespace OrderIntegration.BCompany.Bussiness.Abstract
{
    [ServiceContract]
    public interface IOrderSoapService
    {
        [OperationContract]
        Task<List<OrderDto>> GetOrdersByDate(DateTime date);
    }
}
