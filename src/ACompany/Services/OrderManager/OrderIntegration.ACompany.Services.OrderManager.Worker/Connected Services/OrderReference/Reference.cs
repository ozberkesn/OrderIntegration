﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDto", Namespace="http://tempuri.org/")]
    public partial class OrderDto : object
    {
        
        private int IdField;
        
        private System.DateTime CreatedDateField;
        
        private System.Collections.Generic.List<OrderReference.OrderItemDto> OrderItemsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public System.DateTime CreatedDate
        {
            get
            {
                return this.CreatedDateField;
            }
            set
            {
                this.CreatedDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Collections.Generic.List<OrderReference.OrderItemDto> OrderItems
        {
            get
            {
                return this.OrderItemsField;
            }
            set
            {
                this.OrderItemsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderItemDto", Namespace="http://tempuri.org/")]
    public partial class OrderItemDto : object
    {
        
        private string ItemNameField;
        
        private int QuantityField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ItemName
        {
            get
            {
                return this.ItemNameField;
            }
            set
            {
                this.ItemNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Quantity
        {
            get
            {
                return this.QuantityField;
            }
            set
            {
                this.QuantityField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderReference.IOrderSoapService")]
    public interface IOrderSoapService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderSoapService/GetOrdersByDate", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderReference.OrderDto>> GetOrdersByDateAsync(System.DateTime date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IOrderSoapServiceChannel : OrderReference.IOrderSoapService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class OrderSoapServiceClient : System.ServiceModel.ClientBase<OrderReference.IOrderSoapService>, OrderReference.IOrderSoapService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public OrderSoapServiceClient() : 
                base(OrderSoapServiceClient.GetDefaultBinding(), OrderSoapServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IOrderSoapService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OrderSoapServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(OrderSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), OrderSoapServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OrderSoapServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(OrderSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OrderSoapServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(OrderSoapServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OrderSoapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderReference.OrderDto>> GetOrdersByDateAsync(System.DateTime date)
        {
            return base.Channel.GetOrdersByDateAsync(date);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOrderSoapService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOrderSoapService_soap))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:5014/Orders.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return OrderSoapServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IOrderSoapService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return OrderSoapServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IOrderSoapService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IOrderSoapService_soap,
        }
    }
}
