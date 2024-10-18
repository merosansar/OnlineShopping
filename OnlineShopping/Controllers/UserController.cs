using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.DataAccess.Models;
using OnlineShopping.DataAccess.Repository;
using OnlineShopping.Utility.LoadDropdown;
using OnlineShopping.Web.Services.IService;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;

namespace OnlineShopping.Web.Controllers
{
    public class UserController(EshopContext context, Dropdown dropdown,IEmailService emailservice,IUserService userservice, EncryptionDecryptionFun encryptdecrypt, IUserAuthenticationService authentication) :Controller
    {
         public readonly EshopContext _context = context;
         private readonly Dropdown Dropdown = dropdown;
         private readonly IEmailService Emailservice = emailservice;
         private readonly IUserService UserService = userservice;
         private readonly EncryptionDecryptionFun EncryptDecrypt = encryptdecrypt;
         private readonly IUserAuthenticationService Authentication = authentication;

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User u)
        {
            var m = Authentication.ReturnDecryptPassword("s",u.Username ?? "", u.PasswordHash??"").ToList().FirstOrDefault();
            int UserId = 0;
            string FullName = "";
            if (m != null) {
                FullName = m.FullName;
                
                if (m.PasswordHash != null)
            {
                    UserId = m.Id;
                string pass = m.PasswordHash.ToString();
                    
                 var decrypt = EncryptDecrypt.Decrypt(pass);
                if (decrypt != u.PasswordHash)
                {
                    return View();
                }
            }
            }

            var i = Authentication.LoginResponse("a",u.Username??"", u.PasswordHash??"").ToList().FirstOrDefault();
            if (i != null)
            {
                if (i.Code == "000")
                {
                    ViewBag.UserName = FullName;
                    TempData["FullName"] = FullName;
                    HttpContext.Session.SetInt32("UserId", UserId);
                    HttpContext.Session.SetString("FullName", FullName);
                    HttpContext.Session.SetString("Username", u.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult SellerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SellerLogin(User u)
        {
            var m = Authentication.ReturnDecryptPassword("s", u.Username ?? "", u.PasswordHash ?? "").ToList().FirstOrDefault();
            int UserId = 0;
            if (m != null)
            {


                if (m.PasswordHash != null)
                {
                    UserId = m.Id;
                    string pass = m.PasswordHash.ToString();
                    var decrypt = EncryptDecrypt.Decrypt(pass);
                    if (decrypt != u.PasswordHash)
                    {
                        return View();
                    }
                }
            }

            var i = Authentication.LoginResponse("a", u.Username ?? "", u.PasswordHash ?? "").ToList().FirstOrDefault();
            if (i != null)
            {
                if (i.Code == "000")
                {

                    HttpContext.Session.SetInt32("UserId", UserId);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }




        public IActionResult SellerRegister()
        {

            var i = Dropdown.GetDropDownList("Genderdata", "");
            var m = new User { Genderdata = i };
            return View(m);
        }
        [HttpPost]
        public IActionResult SellerRegister(User u)
        {

            if (TempData["VerificationCode"] != null)
            {
                var verificationcode = TempData["VerificationCode"].ToString();
                if (verificationcode != u.VerificationCode)
                {

                    ViewBag.Message = "Please provide valid   verification code. ";
                    ViewBag.VerificationCode = verificationcode;
                    var d = Dropdown.GetDropDownList("Genderdata", "");
                    var m = new User { Genderdata = d };
                    return View(m);
                }
            }
             return View();
        }
        public IActionResult Register(string name)
        {
            if (name == "googlesignup")
            {
                return RedirectToAction("LoginWithGoogle");
            }
            var i = Dropdown.GetDropDownList("Genderdata", "");
            var m = new User {Genderdata =  i };
            return View(m);
        }
        [HttpPost]
        public IActionResult Register(User u)
        {
            if(TempData["VerificationCode"]!=null) {
                var verificationcode = TempData["VerificationCode"].ToString();
                if (verificationcode != u.VerificationCode)
                {
                    
                    ViewBag.Message = "Please provide valid   verification code. ";
                    ViewBag.VerificationCode = verificationcode;
                    var d = Dropdown.GetDropDownList("Genderdata", "");
                    var m = new User { Genderdata = d };
                    return View(m);
                }
            }
           
            var PasswordHash = EncryptDecrypt.Encrypt(u.PasswordHash);
            //var decrypt = EncryptDecrypt.Decrypt(PasswordHash);
            var  i = UserService.ChangeUserInfo("i",u.UserId,u.Username??"",u.Email, PasswordHash, u.FullName??"",u.PhoneNumber,u.Address,u.City,u.Province,u.Zone,u.District,u.ProfilePicUrl,u.RoleId,u.GenderId,Convert.ToDateTime( u.Dob)).ToList();

            if(i.Count > 0 ) { return View("Login"); }
            return View();
        }

        public async Task LoginWithGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task LoginWithFacebook()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task<IActionResult> GoogleResponse()
        {
            // Authenticate the user with the Cookie Authentication scheme
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Check if the authentication was successful
            if (result.Succeeded)
            {
                // Extract user information from the authenticated principal
                var claimsIdentity = result.Principal.Identity as ClaimsIdentity;
                var name = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

                // You can handle user information here, such as storing it in a database
                // or performing additional actions based on user details.

                // Redirect to the home page after successful login
                return View(name);
            }
            return View();
        }

        [HttpPost]
        public IActionResult SignInGoogle()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

       
        //public async Task<IActionResult> GoogleResponse()
        //{
        //    // Authenticate the user with the Cookie Authentication scheme
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        //    // Check if the authentication was successful
        //    if (result.Succeeded)
        //    {
        //        // Extract user information from the authenticated principal
        //        var claimsIdentity = result.Principal.Identity as ClaimsIdentity;
        //        var name = claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value;

        //        // You can handle user information here, such as storing it in a database
        //        // or performing additional actions based on user details.

        //        // Redirect to the home page after successful login
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // If authentication was not successful, redirect to the login page
        //    return RedirectToAction("Login");
        //}


        [HttpPost]
        public async Task<IActionResult> SendVerificationCode(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be empty.");
            }

            var verificationCode = new Random().Next(100000, 999999).ToString();

            // Store the verification code (e.g., in the database or session)
            // For example:
            // await _verificationCodeService.StoreCodeAsync(email, verificationCode);

            var subject = "Your Verification Code";
            var message = $"Your verification code is: {verificationCode}";

            await   Emailservice.SendEmailAsync(email, subject, message);

            TempData["VerificationCode"] = verificationCode;

            return Ok(); // Return a success response
        }

    }
}
