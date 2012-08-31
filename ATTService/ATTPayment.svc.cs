using System.Collections.Generic;
using ATT_MSSDK;
using ATT_MSSDK.Notaryv1;
using ATT_MSSDK.Paymentv3;
using System.Configuration;

namespace ATTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ATTPayment" in code, svc and config file together.
    public class ATTPayment : IATTPayment
    {
        RequestFactory requestFactory;
        /// <summary>
        /// Global Variable Declaration
        /// </summary>
        private string endPoint;

        public ATTPayment()
        {
            this.endPoint = ConfigurationManager.AppSettings["endpoint"];
            List<RequestFactory.ScopeTypes> scopes = new List<RequestFactory.ScopeTypes>();
            scopes.Add(RequestFactory.ScopeTypes.Payment);
            this.requestFactory = new RequestFactory(this.endPoint, ConfigurationManager.AppSettings["api_key"], ConfigurationManager.AppSettings["secret_key"], scopes, null, null);

        }

        public string NewPaymentTransaction(double amount, int paymentCategory, string description, string merchantTransactionId, string merchantRedirectURI, string merchantProductId)
        {
            //// Get payment payload notarized.
            NotaryResponse notaryResponse = requestFactory.GetNotarizedForNewTransaction(amount, (PaymentCategories)paymentCategory, description, merchantTransactionId, merchantProductId, merchantRedirectURI);

            //// Get the TransactionRedirectUrl which points to AT&T platform transaction endpoint
            return requestFactory.GetNewTransactionRedirect(notaryResponse);
        }
    }
}
