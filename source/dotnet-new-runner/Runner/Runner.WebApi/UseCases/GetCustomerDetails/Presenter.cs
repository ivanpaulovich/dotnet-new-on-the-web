namespace Runner.WebApi.UseCases.GetCustomerDetails
{
    using Runner.Application;
    using Runner.Application.Outputs;
    using Runner.WebApi.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class Presenter : IOutputBoundary<GenerateOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public GenerateOutput Output { get; private set; }

        public void Populate(GenerateOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in output.Accounts)
            {
                List<TransactionModel> transactions = new List<TransactionModel>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new TransactionModel(
                        item.Amount,
                        item.Description,
                        item.TransactionDate);

                    transactions.Add(transaction);
                }

                accounts.Add(new AccountDetailsModel(
                    account.AccountId,
                    account.CurrentBalance,
                    transactions));
            }

            CustomerDetailsModel model = new CustomerDetailsModel(
                output.CustomerId,
                output.Personnummer,
                output.Name,
                accounts
            );

            ViewModel = new ObjectResult(model);
        }
    }
}
