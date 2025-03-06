using Final_CFF.BL.DTOs.PaymentDTOs;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace Final_CFF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Resident")]
    public class StripeController(IStripeService _service) : ControllerBase
    {
        private const string WebhookSecret = "rk_test_51QvgBDP9VoKxey61TIitIM3zA22bbHdNl5ok2GV6bjszKA2smNYt3jcSgwiEAkSF5RGDdhTS8jRddXbhXi1AqFTL00765jOzkp";
        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            try
            {
                var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
                var stripeSignature = Request.Headers["Stripe-Signature"];
                var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, WebhookSecret);

                //if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                //{
                //    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                //    Console.WriteLine($"Payment was successfully completed! PaymentIntent ID: {paymentIntent.Id}");
                //}

                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine($"Stripe error: {e.Message}");
                return BadRequest();
            }
            catch ( Exception ex )
            {
                throw new Exception(ex.Message );
            }
        }
        [HttpPost]
        public async Task<IActionResult> PaymentIntent(CreatePaymentDTO DTO)
        {
           _service.PaymentIntent(DTO);
            return Ok();
        }
      

        [HttpPost]
        public async Task<IActionResult> Charge( ChargeRequest request)
        {
            var charge = await _service.CreateCharge(request.Token, request.Amount);

            if (charge.Status == "succeeded")
            {
                return Ok("Ödəniş ugurla yerinə yetirildi.");
            }
            return BadRequest("Ödəniş zamani xeta  bas verdi.");
        }

    }
}
