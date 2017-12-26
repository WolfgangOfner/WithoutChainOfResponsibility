namespace WithoutChainOfResponsibility
{
    public interface IExpenseApprover
    {
        ApprovalResponse ApprovalExpense(IExpenseReport exepnseReport);
    }
}