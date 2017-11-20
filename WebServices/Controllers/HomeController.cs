using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServices.Models;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System.Security.Cryptography;

namespace WebServices.Controllers
{
    public class HomeController : Controller
    {
        public static ModelActiveUser activeUser;
        static string token;
        public IActionResult LoginForm()
        {
            return View();
        }

        static bool findCookie(string token)//TOKEN
        {
            if (Startup.item.UserTable.Any(it => it.Token.Equals(token)))
                return true;
            else
                return false;
        }

        static string addToken(Microsoft.AspNetCore.Http.HttpResponse res)
        {
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                byte[] tokenData = new byte[32]; //100% безопасно
                rng.GetBytes(tokenData);
                token = Convert.ToBase64String(tokenData);
            }
            
            res.Cookies.Append("_token", token + ";Max-Age=15552000;HttpOnly;");

            // add to bd token
            return token;
        }

        public void CheckLogin(string accountNumber, string password)
        {
            //if (accountNumber == "123" && password == "321")
            //{
            //    //View(GeneralForm());

            //    addToken(Response);
            //    Response.Redirect("/Home/GeneralForm/");

            //}
            //else
            //{
            //    Response.Redirect("/Home/Error/");
            //}
            //activeUser = Startup.AppKernel.Get<ModelActiveUser>(accountNumber);

            if (Startup.item.UserTable.Any(it => it.AccountNumber.Equals(accountNumber) && it.Password.Equals(password)))
            {
                //выделение активного юзера
                //activeUser = Startup.item.UserTable.First(it => it.AccountNumber.Equals(accountNumber));

                activeUser = Startup.AppKernel.Get<ModelActiveUser>(accountNumber);
                //создание модели активного юзера

                //return View("Your account is valid!\nHello "+activeUser.FirstName);
                Response.Redirect("/Home/GeneralForm");
                
            }
            else
                //возвращение об ошибке
                Response.Redirect("/Home/Error");
            //return View("Your account is not valid!");


        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult GeneralForm()
        {
            //if (Request.Cookies.Select(o => o.Key == "_token" && findCookie(o.Value)).ToArray().Length == 1)
            //{
            //    return View();
            //}
            //else
            //{
            //    return Error();
            //}
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //отображение страницы
        public IActionResult RegistrationForm()
        {
            //addToken(Response);
            return View();
        }


        public string calendarEvents(string year, string month)
        {
            //получение из бд события 
            //ArrayOfEvents.Evs = Startup.item.Events.Where(it => it.Month.Equals(month) && it.Year.Equals(year)).ToList();
            
            //Внимание! Велосипед
            //foreach (var item in Startup.item.Event)
            //{
            //    if (item.Month.Equals(month) && item.Year.Equals(year))
            //    {
            //        ArrayOfEvents.Evs.Add(item);
            //    }
            //}
            
            return JsonConvert.SerializeObject(ArrayOfEvents.Evs);
        }

        static Regex pass_regex = new Regex(@"^\w+$");
        static Regex account_regex = new Regex(@"^\d{4}$");
        static Regex name_regex = new Regex(@"^[А-Я][а-я]+$");

        //метод для создания новоого юзера.то есть должно быть добавелние в бд
        public string NewUser(string lastName, string firstName, DateTime dob, string password, string accountNumber, string groupName, string email)
        {
            
            //bike 
            bool passValid = pass_regex.IsMatch(password);
            bool accountValid = account_regex.IsMatch(accountNumber);
            bool lastNameValid = name_regex.IsMatch(lastName);
            bool firstNameValid = name_regex.IsMatch(firstName);
            //на мыло @
            bool emailValid = (email.Contains('@')) ? true : false;
            
            if (!passValid || !accountValid || !lastNameValid || !firstNameValid || !emailValid)
            {
                return "{\"ok\":false}";
            }
            else
            {
                UserTable ut = new UserTable();
                try
                {
                    ut.AccountNumber = accountNumber;
                    ut.Dob = dob;
                    ut.Email = email;
                    ut.FirstName = firstName;
                    ut.LastName = lastName;
                    ut.Password = password;
                    ut.Token = addToken(Response);
                    ut.GroupName = groupName;
                }
                catch (DbUpdateException ex)
                {
                    return "{\"ok\":false}";
                }
                //вот тут мне не нравится проверочка. тип если в бд уже такой есть, то не писать снова. 
                //но ведь др может совпадать. хотя. он же проверяет объект с объектом. одно поле не сошлось значит не тру
                if (!Startup.item.UserTable.All(it => it.Equals(ut)))
                {
                    //try
                    Startup.item.UserTable.Add(ut);
                    Startup.item.SaveChanges();
                }
                return "{\"ok\":true}";
            }
             
        }

        public string getLesson(string week,string groupName)
        {
            //ЧТЕНИЕ ИЗ БД РАСПИАНИЯ 
            //ArrayOfLectures.listLectures = Startup.item.TimeTables.Where(t => t.Week.Equals(week) && t.GroupName.Equals(groupName));
            return null;
        }

    }
}