using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private const string WebhookSecret = "Sizin_Webhook_Açarınız";
        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            try
            {
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
                var stripeSignature = Request.Headers["Stripe-Signature"];
                var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, WebhookSecret);

                if (stripeEvent.Type == Event.PaymentIntentSucceeded)
                {
                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                    Console.WriteLine($"Ödəniş uğurla tamamlandı! PaymentIntent ID: {paymentIntent.Id}");
                }

                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine($"Stripe xətası: {e.Message}");
                return BadRequest();
            }
        }

    }
}
