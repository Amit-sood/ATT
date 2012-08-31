using System.ServiceModel;

namespace ATTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IATTPayment" in both code and config file together.
    [ServiceContract]
    public interface IATTPayment
    {
        [OperationContract]
        string NewPaymentTransaction(double amount, int paymentCategory, string description, string merchantTransactionId, string merchantRedirectURI, string merchantProductId);
    }
}
