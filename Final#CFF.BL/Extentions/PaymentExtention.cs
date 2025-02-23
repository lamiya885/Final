//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Final_CFF.BL.Helpers;
//using FluentValidation;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Stripe;

//namespace Final_CFF.BL.Extentions;

//public static  class PaymentExtention
//{
//    public static void AddPaymentApi(this IServiceCollection services,IConfiguration configuration)
//    {
//        services.AddValidatorsFromAssemblyContaining<CreatePaymentRequestValidator>();
//        services.AddOptions<StripeConfig>().BindConfiguration(nameof(StripeConfig));
//        services.AddScoped<StripeClient>();
//    }
//    public static void MApPaymentsEndPoints(this IEndpointRouteBuilder routeBuilder)
//    {
//        var routeGroup = routeBuilder.MapGroup(prefix:ApiRoutes.Payments).W
//    }
//}
