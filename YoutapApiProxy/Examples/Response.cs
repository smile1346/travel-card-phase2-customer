namespace Examples;
using Swashbuckle.AspNetCore.Filters;

public class GetUserInfoResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get User Info", File.ReadAllText("examples/GetUserInfoResponse.json"));
    }
}

public class GetUserInfoResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Cannot find account id for msisdn", File.ReadAllText("examples/GetUserInfoResponse_NotFound.json"));
    }
}

public class KYCConfirmationResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("KYC Confirmation", File.ReadAllText("examples/KYCConfirmationResponse.json"));
    }
}

public class BillPaymentResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Electric Train", File.ReadAllText("examples/BillPaymentResponse_ElectricTrain.json"));
        // yield return SwaggerExample.Create("Successful Instant BillPayment", File.ReadAllText("examples/BillPaymentResponse_Successful.json"));
    }
}


public class BillPaymentResponseDelayedExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Delayed Payment", File.ReadAllText("examples/BillPaymentResponse_Delayed.json"));
    }
}

public class BillPaymentResponseInsufficientFundsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Insufficent Funds", File.ReadAllText("examples/BillPaymentResponse_InsufficientFunds.json"));
    }
}

public class BillPaymentResponseTooManyRequestsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Duplicated request", File.ReadAllText("examples/BillPaymentResponse_TooManyRequests.json"));
    }
}

public class GetPendingDelayedPaymentsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Pending Delayed Payments", File.ReadAllText("examples/GetPendingDelayedPaymentsResponse.json"));
    }
}

public class GetTransactionHistoryResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Transaction History", File.ReadAllText("examples/GetTransactionHistoryResponse.json"));
    }
}

public class GetTransactionLimitsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get fees for everything", File.ReadAllText("examples/GetTransactionLimitsResponse.json"));
    }
}

public class GetAvailableWalletTypesResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Available Wallet Types", File.ReadAllText("examples/GetAvailableWalletTypesResponse.json"));
    }
}

public class GetQuickAccountsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Quick Accounts", File.ReadAllText("examples/GetQuickAccountsResponse_Current.json"));
    }
}

public class GetSpecificAccountResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Get Specific Account", File.ReadAllText("examples/GetSpecificAccountResponse.json"));
    }
}

public class CreateAccountResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Create Account", File.ReadAllText("examples/CreateAccountResponse_Successful.json"));
    }
}

public class CreateAccountResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid Wallet Type Error", File.ReadAllText("examples/CreateAccountResponse_NotFound.json"));
    }
}

public class UpdateAccountResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successful Update Account", File.ReadAllText("examples/UpdateAccountResponse_Successful.json"));
    }
}

public class UpdateAccountResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid Account Id", File.ReadAllText("examples/UpdateAccountResponse_NotFound.json"));
    }
}

public class GetLinkedExternalAccountsResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Linked external accounts", File.ReadAllText("examples/GetLinkedExternalAccountsResponse.json"));
    }
}

public class KYCRegistrationPOSTResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Successfully Create User", File.ReadAllText("examples/KYCRegistrationPOSTResponse_New.json"));
    }
}

public class GeneralTransactionResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("QUERY Mode", File.ReadAllText("examples/GeneralTransactionDepositResponse_QUERY.json"));
        yield return SwaggerExample.Create("TRANSACTION Mode", File.ReadAllText("examples/GeneralTransactionDepositResponse_TRANSACTION.json"));
    }
}

public class GeneralTransactionResponseErrorExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Consumer token is expired", File.ReadAllText("examples/GeneralTransactionDepositResponse_ExpiredQR.json"));
        yield return SwaggerExample.Create("Could not parse cpmQrCode", File.ReadAllText("examples/GeneralTransactionDepositResponse_BadQR.json"));
        yield return SwaggerExample.Create("Balance limit reached", File.ReadAllText("examples/GeneralTransactionDepositResponse_BalanceLimitReached.json"));
        yield return SwaggerExample.Create("Transaction date is not current", File.ReadAllText("examples/GeneralTransactionDepositResponse_DateNotCurrent.json"));
        yield return SwaggerExample.Create("Transaction type not allowed for this account", File.ReadAllText("examples/GeneralTransactionResponse_TransactionTypeNotAllowedFromThisAccount.json"));
    }
}

public class GeneralTransactionResponseTooManyRequestsExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Duplicated request", File.ReadAllText("examples/GeneralTransactionDepositResponse_TooManyRequests.json"));
    }
}

public class WebhookExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("LOW_BALANCE", File.ReadAllText("examples/Webhook_LowBalance.json"));
        yield return SwaggerExample.Create("CASHIN", File.ReadAllText("examples/Webhook_CashIn.json"));
        yield return SwaggerExample.Create("CASHIN", File.ReadAllText("examples/Webhook_PaymentReversal.json"));
    }
}

public class ReversePaymentResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Transaction Not Found", File.ReadAllText("examples/ReversePaymentResponse_NotFound.json"));
    }
}

public class ReversePaymentResponseBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Transaction already reversed", File.ReadAllText("examples/ReversePaymentResponse_AlreadyReversed.json"));
    }
}

public class CreateOpenBillResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Merchant-Presented Mode QR Code/Open Bill", File.ReadAllText("examples/CreateOpenBillResponse.json"));
    }
}

public class CreateOpenBillResponseBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Account not belongs to merchant", File.ReadAllText("examples/CreateOpenBillResponse_BadRequest_AccountNotBelongsToMerchant.json"));
    }
}

public class WalletPaymentResponseSuccessExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("C2MP - Query Mode", File.ReadAllText("examples/GeneralTransactionPaymentResponseQuery.json"));
        yield return SwaggerExample.Create("C2MP - Transaction Mode", File.ReadAllText("examples/GeneralTransactionPaymentResponseTransaction.json"));
    }
}

public class PayByConsumerTokenResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Pay By Scanning CPM QR Code", File.ReadAllText("examples/PayByConsumerTokenResponse.json"));
    }
}

public class PayByConsumerTokenResponseNotFoundExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("could not retrieve customer details from acctid", File.ReadAllText("examples/PayByConsumerTokenResponse_NotFound.json"));
    }
}

public class PayByConsumerTokenResponseBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Consumer token is expired", File.ReadAllText("examples/PayByConsumerTokenResponse_ConsumerTokenIsExpired.json"));
        yield return SwaggerExample.Create("Could not find consumer token", File.ReadAllText("examples/PayByConsumerTokenResponse_CouldNotFindConsumerToken.json"));
    }
}

public class GetQRStringResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Consumer-Presented Mode QR Code", File.ReadAllText("examples/GetQRStringResponse.json"));
    }
}

public class GetQRStringResponseBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Invalid customer type", File.ReadAllText("examples/GetQRStringResponse_BadRequest_InvalidCustomerType.json"));
    }
}

public class PayByMerchantQRResponseExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Pay By Scanning MPM QR Code", File.ReadAllText("examples/PayByMerchantQRResponse_Success.json"));
    }
}

public class PayByMerchantQRResponseBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Bill reference already paid", File.ReadAllText("examples/PayByMerchantQRResponse_BillAlreadyPaid.json"));
        yield return SwaggerExample.Create("Bill not found", File.ReadAllText("examples/PayByMerchantQRResponse_BillNotFound.json"));
        yield return SwaggerExample.Create("Bill reference already expired", File.ReadAllText("examples/PayByMerchantQRResponse_BillAlreadyExpired.json"));
        yield return SwaggerExample.Create("Amount incorrect", File.ReadAllText("examples/PayByMerchantQRResponse_AmountIncorrect.json"));
        yield return SwaggerExample.Create("Bill reference is not active", File.ReadAllText("examples/PayByMerchantQRResponse_BillNotActive.json"));
    }
}

public class DeactivateOpenBillBadRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Bill not found", File.ReadAllText("examples/DeactivateOpenBillResponse_BillNotFound.json"));
        yield return SwaggerExample.Create("Bill reference already paid", File.ReadAllText("examples/PayByMerchantQRResponse_BillAlreadyPaid.json"));
        yield return SwaggerExample.Create("Bill reference already deactivated", File.ReadAllText("examples/DeactivateOpenBillResponse_BillAlreadyDeactivated.json"));
    }
}