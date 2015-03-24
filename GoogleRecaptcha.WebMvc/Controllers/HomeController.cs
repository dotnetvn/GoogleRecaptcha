using System.Configuration;
using System.Web.Mvc;

namespace GoogleRecaptcha.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

		//
		// POST: /Home/
		[HttpPost]
		public ActionResult Index(FormCollection form)
		{
			IRecaptcha<RecaptchaV2Result> recaptcha = new RecaptchaV2(new RecaptchaV2Data() { Secret = ConfigurationManager.AppSettings["CaptchaSecretKey"] });
			var result = recaptcha.Verify();
			if (result.Success)
			{
				//TODO: write code here
			}

			return View();
		}

    }
}
