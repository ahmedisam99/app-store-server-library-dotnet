using Xunit;

namespace Enjna.AppStoreServerLibrary.Tests;

public class ReceiptUtilityTests
{
    private readonly ReceiptUtility _receiptUtility = new();

    [Fact]
    public void ExtractTransactionIdFromAppReceipt_EmptyXcodeReceipt_ReturnsNull()
    {
        var receipt = TestUtilities.ReadResourceAsString("xcode.xcode-app-receipt-empty");
        var transactionId = _receiptUtility.ExtractTransactionIdFromAppReceipt(receipt);
        Assert.Null(transactionId);
    }

    [Fact]
    public void ExtractTransactionIdFromAppReceipt_XcodeReceiptWithTransaction_ReturnsTransactionId()
    {
        var receipt = TestUtilities.ReadResourceAsString("xcode.xcode-app-receipt-with-transaction");
        var transactionId = _receiptUtility.ExtractTransactionIdFromAppReceipt(receipt);
        Assert.Equal("0", transactionId);
    }

    [Fact]
    public void ExtractTransactionIdFromTransactionReceipt_LegacyTransaction_ReturnsTransactionId()
    {
        var receipt = TestUtilities.ReadResourceAsString("mock_signed_data.legacyTransaction");
        var transactionId = _receiptUtility.ExtractTransactionIdFromTransactionReceipt(receipt);
        Assert.Equal("33993399", transactionId);
    }
}
