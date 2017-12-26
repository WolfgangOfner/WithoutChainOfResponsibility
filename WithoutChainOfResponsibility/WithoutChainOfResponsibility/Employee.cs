namespace WithoutChainOfResponsibility
{
    public class Employee : IExpenseApprover
    {
        private readonly decimal _approvalLimit;

        public Employee(string name, string jobTitle, decimal approvalLimit)
        {
            Name = name;
            JobTitle = jobTitle;
            _approvalLimit = approvalLimit;
        }

        public string Name { get; set; }

        public string JobTitle { get; set; }


        public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
        {
            return expenseReport.Total > _approvalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;
        }
    }
}