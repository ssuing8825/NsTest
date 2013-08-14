using System;
using NServiceBus;

namespace Model.Events
{

    public interface IAddressBillingMailingEventSet : IBaseMailingAddressEvent
    {
    }

    public interface IBaseMailingAddressEvent : ICustomerAttachmentPropertiesWithId, ITransactionSummaryEvent, IBaseEvent
    {
        IAddressProperties Current { get; set; }
        IAddressProperties Previous { get; set; }
    }

    public interface ITransactionSummaryEvent : ITransactionSummaryCoreProperties
    {
    }
    public interface IBaseEvent : IEvent, IPortfolioTiebackProperties, IEffectivityProperties
    {
        INotice[] Notices { get; set; }
    }

    public interface INotice
    {
        string Id { get; set; }
        string Description { get; set; }
        string Source { get; set; }
        string Property { get; set; }
        INoticeParameter[] Parameters { get; set; }
        string Severity { get; set; }

        INoticeParameter INoticeParameter
        {
            get;
            set;
        }
    }

    public interface INoticeParameter
    {
        string Name { get; set; }
        string Value { get; set; }
    }

    public interface IPortfolioTiebackProperties
    {
        DateTime? PortfolioActivityDate { get; set; }
        string PortfolioGroupId { get; set; }
    }

    public interface ITransactionSummaryCoreProperties
    {
        string CallingSystem { get; set; }
        string ModifyBy { get; set; }
        string ModifySource { get; set; }
    }


    public interface IAddressProperties : IMessage
    {

        string AddressId { get; set; }

        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string CityName { get; set; }
        string StateCode { get; set; }
        string ZipCode { get; set; }
        string CountryCode { get; set; }
        string DeliveryPointBarcode { get; set; }
        string CassCode { get; set; }
        string AddressLatitude { get; set; }
        string AddressLongitude { get; set; }
        string GeoPrecisionCode { get; set; }
        string AddressAccuracyCode { get; set; }
    }

    public interface ICustomerAttachmentPropertiesWithId
    {
        string CustomerId { get; set; }
        string Id { get; set; }
    }

    public interface IEffectivityProperties
    {
        DateTime? EffectiveDate { get; set; }
        DateTime? ExpirationDate { get; set; }
    }
}
