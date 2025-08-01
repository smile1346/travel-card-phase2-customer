namespace Examples;
using Swashbuckle.AspNetCore.Filters;

public class KYCRegistrationPOSTRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Consumer Wallet", File.ReadAllText("examples/KYCRegistrationPOSTRequest_Minimal.json"));
        yield return SwaggerExample.Create("Register", File.ReadAllText("examples/KYCRegistrationPOSTRequest.json"));
    }
}

public class KYCRegistrationPOSTRequestMerchantExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Merchant", File.ReadAllText("examples/KYCRegistrationPOSTRequest_MCHNT.json"));
    }
}

public class KYCRegistrationPATCHRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Patch Customer", File.ReadAllText("examples/KYCRegistrationPATCHRequest.json"));
    }
}

public class BillPaymentElectricTrainRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Electric Train", File.ReadAllText("examples/BillPaymentRequest_ElectricTrain.json"));
        yield return SwaggerExample.Create("BillPayment", File.ReadAllText("examples/BillPaymentRequest.json"));
    }
}

public class WalletPaymentRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("C2MP - Query Mode", File.ReadAllText("examples/GeneralTransactionPaymentRequestQuery.json"));
        yield return SwaggerExample.Create("C2MP - Transaction Mode", File.ReadAllText("examples/GeneralTransactionPaymentRequestTransaction.json"));
    }
}


public class CreateAccountRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Create Account", File.ReadAllText("examples/CreateAccountRequest.json"));
    }
}

public class UpdateAccountRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Update Account", File.ReadAllText("examples/UpdateAccountRequest.json"));
    }
}

public class GeneralTransactionRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Deposit with QR Code", File.ReadAllText("examples/GeneralTransactionDepositRequest_QR.json"));
        yield return SwaggerExample.Create("Deposit", File.ReadAllText("examples/GeneralTransactionDepositRequest.json"));
        yield return SwaggerExample.Create("Withdrawal", File.ReadAllText("examples/GeneralTransactionWithdrawalRequest.json"));
    }
}

public class UpdateMsisdnRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Update MSISDN", File.ReadAllText("examples/UpdateMsisdnRequest.json"));
    }
}

public class ReversePaymentRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Reverse Payment", File.ReadAllText("examples/ReversePaymentRequest.json"));
    }
}

public class CreateOpenBillRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Minimal", File.ReadAllText("examples/CreateOpenBillRequest_Minimal.json"));
        // yield return SwaggerExample.Create("Create Open Bill", File.ReadAllText("examples/CreateOpenBillRequest.json"));
    }
}

public class PayByConsumerTokenRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Pay By Scanning CPM QR Code", File.ReadAllText("examples/PayByConsumerTokenRequest.json"));
    }
}

public class PayByMerchantQRRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Pay By Scanning MPM QR Code", File.ReadAllText("examples/PayByMerchantQRRequest.json"));
    }
}

public class DeactivateOpenBillRequestExample : IMultipleExamplesProvider<string>
{
    public IEnumerable<SwaggerExample<string>> GetExamples()
    {
        yield return SwaggerExample.Create("Deactivate Open Bill", File.ReadAllText("examples/DeactivateOpenBillRequest.json"));
    }
}