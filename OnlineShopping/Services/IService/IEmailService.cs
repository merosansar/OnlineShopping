﻿namespace OnlineShopping.Web.Services.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
