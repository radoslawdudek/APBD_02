namespace LegacyApp;
using System;

public class UserValidationService
{
    public bool IsFullNameValid(string firstName, string lastName)
    {
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
    }

    public bool IsEmailValid(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }

    public bool IsUserOldEnough(DateTime dateOfBirth)
    {
        int age = CalculateAge(dateOfBirth);
        return age >= 21;
    }

    private int CalculateAge(DateTime dateOfBirth)
    {
        DateTime now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            age--;
        return age;
    }
    
    public void DetermineCreditLimit(User user, Client client, ICreditService creditService)
    {
        if (client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else
        {
            int creditLimit = creditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            if (client.Type == "ImportantClient")
            {
                creditLimit *= 2;
            }
            user.HasCreditLimit = true;
            user.CreditLimit = creditLimit;
        }
    }
    public bool IsCreditLimitValid(User user)
    {
        return !user.HasCreditLimit || user.CreditLimit >= 500;
    }
}


