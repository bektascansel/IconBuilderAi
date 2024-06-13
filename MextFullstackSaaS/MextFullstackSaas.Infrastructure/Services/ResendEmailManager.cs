using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.Email;
using MextFullstackSaaS.Application.Common.Models.Emails;
using MextFullstackSaaS.Application.Common.Translations;
using Microsoft.Extensions.Localization;
using Resend;
using System.Web;

namespace MextFullstackSaaS.Infrastructure.Services;

public class ResendEmailManager : IEmailService
{
    private readonly IResend _resend;
    private readonly IRootPathService _rootPathService;
    private readonly IStringLocalizer<CommonTranslations> _localizer;

    public ResendEmailManager(IResend resend, IRootPathService rootPathService, IStringLocalizer<CommonTranslations> localizer)
    {
        _resend = resend;
        _rootPathService = rootPathService;
        _localizer = localizer;
    }

    //blazor çalışma url 
    private const string WebAppBaseUrl = "http://localhost:5067/";




    public async Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
    {
        var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);

        var encodedToken = HttpUtility.UrlEncode(emailDto.Token);

        var link = $"{WebAppBaseUrl}verify-email?email={encodedEmail}&token={encodedToken}";

        var htmlContent =
            await File.ReadAllTextAsync($"{_rootPathService.GetRootPath()}/email-templates/userauth-template.html", cancellationToken);

        htmlContent = htmlContent.Replace("{{{link}}}", link);

        htmlContent = htmlContent.Replace("{{{subject}}}", _localizer[CommonTranslationKeys.EmailVerificationSubject]);

        htmlContent = htmlContent.Replace("{{{content}}}", _localizer[CommonTranslationKeys.EmailVerificationContent]);

        htmlContent = htmlContent.Replace("{{{buttonText}}}", _localizer[CommonTranslationKeys.EmailVerificationButtonText]);

        await SendEmailAsync(new EmailSendDto(emailDto.Email, _localizer[CommonTranslationKeys.EmailVerificationSubject], htmlContent), cancellationToken);
    }

    

    public async Task SendEmailResetPasswordAsync(EmailSendResetPasswordDto emailDto, CancellationToken cancellationToken)
    {
        var encodedEmail = HttpUtility.UrlEncode(emailDto.Email);
        var encodedToken = HttpUtility.UrlEncode(emailDto.Token);
        var link = $"{WebAppBaseUrl}UsersAuth/forgot-password?email={encodedEmail}&token={encodedToken}";

        var htmlContent = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>";

        await SendEmailAsync(new EmailSendDto(emailDto.Email, "Password Reset | IconBuilderAI", htmlContent), cancellationToken);
    }

   
    public async Task SendPasswordChangedNotificationAsync(string email, CancellationToken cancellationToken)
    {
        var htmlContent = "<div>Your password has been changed. If you did not initiate this change, please contact our support team immediately.</div>";

        await SendEmailAsync(new EmailSendDto(email, "Password Changed Notification | IconBuilderAI", htmlContent), cancellationToken);
    }


    private Task SendEmailAsync(EmailSendDto emailSendDto, CancellationToken cancellationToken)
    {
        var message = new EmailMessage();

        message.From = "onboarding@resend.dev";

        foreach (var emailAddress in emailSendDto.Addresses)
            message.To.Add(emailAddress);

        message.Subject = emailSendDto.Subject;
        message.HtmlBody = emailSendDto.HtmlContent;

        return _resend.EmailSendAsync(message, cancellationToken);
    }

}