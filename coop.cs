using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace Cooperative;

public class Cooperator
{
    public string Name { get; set; }
    public string Factory {get; set;}
    public int CoopNumber { get; set; }
    public int StaffNumber { get; set; }
    public int MonthlyContribution { get; set; }
    public int BuildingFundBalance { get; set; }
    public int InvestmentBalance = 0;
    public int SharesBalance = 0;
    public int SavingsBalance = 0;
    public const int DevelopmentLevy = 300;
    public const int MaxBuildingFund = 30000;
    public const int MaxInvestment = 80000;
    public const int MaxShares = 30000;
    public const int EntranceFee = 3500;
    public int CooperativeDevLevyBal;
    public int CooperativeEntranceFeeBal;

    //public List<int> CoopMembers = new List<int>();

    public int GenerateCoopNumber()
    {
        var rand = new Random();
        return rand.Next(1, 700);
    }

    public int GenerateStaffNumber()
    {
        var rand = new Random();
        return rand.Next(10000, 90000);
    }

    public Cooperator(string name, int contribution, string factory, int bf_amount, int inv_amount, int shares_amount)
    {
        Name = name;
        CoopNumber = GenerateCoopNumber();
        StaffNumber = GenerateStaffNumber();
        MonthlyContribution = contribution;
        Factory = factory;

        FirstSaving(contribution, bf_amount, shares_amount, inv_amount);
    }

    public void SaveMoney(int bf_amount, int inv_amount, int shares_amount, int savings_amount, int monthly_contribution)
    {
        if (monthly_contribution != bf_amount + inv_amount + savings_amount + DevelopmentLevy)
        {
            Console.WriteLine("Your savings do not add up, please check and try again");
        }

        CooperativeDevLevyBal += DevelopmentLevy;

        //monthly_contribution - DevelopmentLevy;

        //SavingsBalance += savings_amount;

        if (BuildingFundBalance <= MaxBuildingFund)
        {
            BuildingFundBalance += bf_amount;
        }
        else
        {
            SavingsBalance += bf_amount;
        }

        if (InvestmentBalance <= MaxInvestment)
        {
            InvestmentBalance += inv_amount;
        }
        else
        {
            SavingsBalance += inv_amount;
        }

        if (SharesBalance <= MaxShares)
        {
            SharesBalance += shares_amount;
        }
        else
        {
            SavingsBalance += shares_amount;
        }

        SavingsBalance += savings_amount;
    }
    
    public void FirstSaving(int monthly, int bf_amount, int shares_amount, int inv_amount)
    {
        if (monthly != EntranceFee + DevelopmentLevy + bf_amount + shares_amount + inv_amount)
        {
            Console.WriteLine("Your savings do not add up, please check and try again");
        }
        else
        {
            CooperativeDevLevyBal += DevelopmentLevy;
            CooperativeEntranceFeeBal += EntranceFee;
            BuildingFundBalance += bf_amount;
            SharesBalance += shares_amount;
            InvestmentBalance += inv_amount;
        }

       
    }
}