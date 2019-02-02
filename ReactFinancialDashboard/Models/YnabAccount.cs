using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ReactFinancialDashboard.Data;

namespace ReactFinancialDashboard.Models {
    public class YnabAccount {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool On_budget { get; set; }
        public bool Closed { get; set; }
        public string Note { get; set; }

        [DataType (DataType.Currency)]
        public double Balance { get; set; }

        [DataType (DataType.Currency)]
        public double Cleared_balance { get; set; }

        [DataType (DataType.Currency)]
        public double Uncleared_balance { get; set; }
        public string Transfer_payee_id { get; set; }
        public bool Deleted { get; set; }

        [DisplayFormat (DataFormatString = "{0:P2}")] //.04 => 4% 
        public double APR { get; set; }
        //todo: add code to update this when adding a new statement
        #endregion

        public void UpdateSelf () {
            //PersonalData personalData = new PersonalData();
            //APR = personalData.InterestRatesDictionary.Where(item => item.Key == Name).FirstOrDefault().Value;
            //ID = personalData.AccountsIdDictionary.Where(x => x.Key == Name).FirstOrDefault().Value;
            //Balance = Balance / 1000;
            //Cleared_balance = Cleared_balance / 1000;
            //Uncleared_balance = Uncleared_balance / 1000;
            //Type = Extensions.SplitString(Type);
        }
    }
    public class YnabAssetAccount : YnabAccount {
        public YnabAssetAccount () { }
        public YnabAssetAccount (YnabAccount ynabAccount) {
            //PersonalData myData = new PersonalData();
            ID = ynabAccount.ID;
            Name = ynabAccount.Name;
            Balance = ynabAccount.Balance;
            Type = ynabAccount.Type;
            On_budget = ynabAccount.On_budget;
            Closed = ynabAccount.Closed;
            Note = ynabAccount.Note;
            Cleared_balance = ynabAccount.Cleared_balance;
            Uncleared_balance = ynabAccount.Cleared_balance;
            Transfer_payee_id = ynabAccount.Transfer_payee_id;
            Deleted = ynabAccount.Deleted;
            APR = ynabAccount.APR;
        }

        public static List<YnabAssetAccount> SetAssetAccounts (ApplicationDbContext context) {
            List<YnabAccount> newestAssetAccounts = context.YnabAccounts.Where (act => act is YnabAssetAccount).ToList ();
            List<YnabAssetAccount> assets = new List<YnabAssetAccount> ();
            foreach (YnabAccount item in newestAssetAccounts) {
                YnabAssetAccount asset = new YnabAssetAccount (item);
                assets.Add (asset);
            }
            return assets;
        }
        public static List<YnabAssetAccount> SetOnBudgetAssets (ApplicationDbContext context) {
            List<YnabAccount> newestAssetAccounts = context.YnabAccounts.Where (act => act is YnabAssetAccount && act.On_budget).ToList ();
            List<YnabAssetAccount> assets = new List<YnabAssetAccount> ();
            foreach (YnabAccount item in newestAssetAccounts) {
                YnabAssetAccount asset = new YnabAssetAccount (item);
                assets.Add (asset);
            }
            return assets;
        }

    }
    public class YnabLiabilityAccount : YnabAccount {
        #region PROPERTIES
        [DataType (DataType.Date), Display (Name = "Payoff Date")] //todo set PayoffDate based on payoff priority
        public DateTime PayOffDate { get; set; }

        [DataType (DataType.Currency), Display (Name = "Payment")]
        public double GoalDateMonthlyAmount { get; set; }
        public PayoffPriority PayoffPriority { get; set; }

        //[NotMapped]
        //public Statement MostRecentStatement { get; set; }
        [NotMapped]
        public double CurrentBudgetedSpending { get; set; }

        [NotMapped]
        public string PaymentDue { get; set; }

        [NotMapped]
        [DataType (DataType.Date), Display (Name = "Last YNAB Payment")]
        public DateTime YnabLastPaymentDate { get; set; }

        [NotMapped]
        [DataType (DataType.Currency), Display (Name = "Spending Since Last Statement")]
        public double SpendingSinceStatement { get; set; }

        [NotMapped]
        [DataType (DataType.Currency), Display (Name = "Avalanche Payment Amount")]
        public double AvalancheMethodPayment { get; set; }
        #endregion
        #region CONSTRUCTORS
        public YnabLiabilityAccount () { }
        public YnabLiabilityAccount (YnabAccount ynabAccount) {
            //PersonalData myData = new PersonalData();
            ID = ynabAccount.ID;
            Name = ynabAccount.Name;
            Balance = ynabAccount.Balance;
            Type = ynabAccount.Type;
            On_budget = ynabAccount.On_budget;
            Closed = ynabAccount.Closed;
            Note = ynabAccount.Note;
            Cleared_balance = ynabAccount.Cleared_balance;
            Uncleared_balance = ynabAccount.Cleared_balance;
            Transfer_payee_id = ynabAccount.Transfer_payee_id;
            Deleted = ynabAccount.Deleted;
            //PayoffPriority = myData.PIFGoalStatus.Where(x => x.Key == Name).FirstOrDefault().Value;
            //PayOffDate = myData.PayOffDate;
            APR = ynabAccount.APR;
            GoalDateMonthlyAmount = PaymentAmount (APR, Balance, PayOffDate);
        }
        public YnabLiabilityAccount (YnabAccount ynabAccount, ApplicationDbContext context) {
            //PersonalData myData = new PersonalData();
            ID = ynabAccount.ID;
            Name = ynabAccount.Name;
            APR = ynabAccount.APR;
            Balance = ynabAccount.Balance;
            Type = ynabAccount.Type;
            On_budget = ynabAccount.On_budget;
            Closed = ynabAccount.Closed;
            Note = ynabAccount.Note;
            Cleared_balance = ynabAccount.Cleared_balance;
            Uncleared_balance = ynabAccount.Uncleared_balance;
            Transfer_payee_id = ynabAccount.Transfer_payee_id;
            Deleted = ynabAccount.Deleted;
            //todo call this only if type is credit card
            //try
            //{
            //    MostRecentStatement = Statement.GetMostRecentStatement(context, ID);
            //}
            //catch
            //{
            //    MostRecentStatement = new Statement();
            //}

            //PayoffPriority = myData.PIFGoalStatus.Where(x => x.Key == Name).FirstOrDefault().Value;

            //switch (PayoffPriority)
            //{
            //    case PayoffPriority.MinimumPayment:
            //        PayOffDate = myData.PayOffDate;
            //        break;
            //    case PayoffPriority.GoalDate:
            //        PayOffDate = myData.PayOffDate;
            //        break;
            //    case PayoffPriority.PIF:
            //        try
            //        {
            //            if (MostRecentStatement.PaymentDueDate < DateTime.Now)
            //            {
            //                PayOffDate = MostRecentStatement.PaymentDueDate.AddMonths(1);
            //            }
            //            else
            //            {
            //                PayOffDate = MostRecentStatement.PaymentDueDate;
            //            }
            //        }
            //        catch (Exception)
            //        {

            //        }
            //        break;
            //}
            GoalDateMonthlyAmount = PaymentAmount (APR, Balance, PayOffDate);
            YnabLastPaymentDate = GetMostRecentTranferInflowDate (context);
            //PaymentDue = SetPaymentDueStatus();
        }
        #endregion
        #region METHODS
        public static double PaymentAmount (double APR, double balance, DateTime payoffdate) {
            //page 120 of your notebook has the calculations
            balance = Math.Abs (balance);
            double paymentAmount = new double ();
            int months = Convert.ToInt32 ((payoffdate - DateTime.Now).TotalDays / 30);
            if (APR == 0) {
                paymentAmount = balance / months;
            } else {
                var monthlyinterestRate = APR / 12;
                var newInterestAccumlated = monthlyinterestRate * balance;
                var denominator = 1 - Math.Pow ((1 + monthlyinterestRate), -months);
                paymentAmount = Math.Round (newInterestAccumlated / denominator, 2);
            }
            return paymentAmount;
            ///////////////////////////// CONSTRUCTOR
        }
        public static DateTime PayoffDate (double APR, double balance, double paymentAmount) {
            var payoffDate = DateTime.Now;
            payoffDate.AddMonths (Convert.ToInt32 (Math.Log (1 - (APR * balance / paymentAmount)) / Math.Log (1 + APR)));
            return payoffDate;
        }
        public static List<YnabLiabilityAccount> GetLiabilityAccountList (ApplicationDbContext context) {
            List<YnabAccount> newestLiabilityAccounts = context.YnabAccounts.Where (act => act is YnabLiabilityAccount).ToList ();
            List<YnabLiabilityAccount> liabilities = new List<YnabLiabilityAccount> ();
            foreach (YnabAccount item in newestLiabilityAccounts) {
                YnabLiabilityAccount liability = new YnabLiabilityAccount (item, context);
                //liability.MostRecentStatement = Statement.GetMostRecentStatement(context, liability.ID);
                liabilities.Add (liability);
            }
            return liabilities;
        }
        public static double TotalCCPayments (ApplicationDbContext context) {
            List<YnabLiabilityAccount> ynabLiabilityAccounts = GetLiabilityAccountList (context);
            double totalCCPayments = new double ();
            foreach (YnabLiabilityAccount account in ynabLiabilityAccounts) {
                totalCCPayments += account.GoalDateMonthlyAmount;
            }
            return totalCCPayments;
        }
        public static List<YnabLiabilityAccount> CalculateAvalanchePayments (ApplicationDbContext context) {
            List<YnabLiabilityAccount> allCCAccounts = GetLiabilityAccountList (context);
            List<YnabLiabilityAccount> nonPriorityAccounts = allCCAccounts.Where (x => x.PayoffPriority != PayoffPriority.GoalDate).ToList ();
            YnabLiabilityAccount priorityAccount = allCCAccounts.Where (x => x.PayoffPriority == PayoffPriority.GoalDate).ToList ().FirstOrDefault (); //todo write test to make sure only one account in database is listed as priority
            List<YnabLiabilityAccount> updatedAccounts = new List<YnabLiabilityAccount> ();

            //total required for debt payoff goal
            double totalAvailableForCCdebt = new double ();
            foreach (YnabLiabilityAccount ccAcount in allCCAccounts) {
                totalAvailableForCCdebt += ccAcount.GoalDateMonthlyAmount;
            }

            //loop through non-priority accounts, determine their avalanche payment amount, and subtract that amount from totalAvailableForCCdebt
            foreach (YnabLiabilityAccount account in nonPriorityAccounts) {
                if (account.PayoffPriority == PayoffPriority.MinimumPayment) {
                    try {
                        //account.AvalancheMethodPayment = account.MostRecentStatement.StatementMinPayment + account.CurrentBudgetedSpending;

                    } catch (Exception) {
                        account.AvalancheMethodPayment = 0;
                    }
                } else {
                    account.AvalancheMethodPayment = Math.Abs (account.Balance);
                }
                totalAvailableForCCdebt -= account.AvalancheMethodPayment;
                updatedAccounts.Add (account);
            }
            priorityAccount.AvalancheMethodPayment = totalAvailableForCCdebt + priorityAccount.GoalDateMonthlyAmount;
            updatedAccounts.Add (priorityAccount);
            return updatedAccounts;
        }
        public DateTime GetMostRecentTranferInflowDate (ApplicationDbContext context) {
            DateTime transferTransactions = context.Transactions
                .Where (x => x.Account_name == Name)
                .Where (y => y.Transfer_transaction_id != null)
                .Where (amt => amt.Amount > 0)
                .Max (d => d.Date);
            return transferTransactions;
        }
        //public string SetPaymentDueStatus()
        //{
        //    try
        //    {
        //        if (MostRecentStatement.LastStatementDate < YnabLastPaymentDate)
        //        {
        //            return "Statement Paid";
        //        }
        //        else
        //        {
        //            return "Payment Due";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Unknown";
        //    }

        //}
        #endregion
    }

    public enum PayoffPriority {
        PIF,
        MinimumPayment,
        GoalDate
    }
}