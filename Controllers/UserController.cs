using ecom.DAL;
using ecom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        UserDAL userdal;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
            userdal = new UserDAL(configuration);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                int res = userdal.UserRegister(user);
                if (res == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            User users = userdal.UserLogin(user);
            if (users.Password == user.Password)
            {
                HttpContext.Session.SetString("username", users.Name );
                HttpContext.Session.SetString("userid", users.UserId.ToString());
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
      
    }
}

      /*  public ActionResult List()
        {
            var model = userdal.GetAllUser();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var employee = userdal.GetUserById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                int res = userdal.AddUser(user);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET:EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userdal.GetUserById(id);
            return View(user);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                int res = userdal.UpdateEmployee(user);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = userdal.GetUserById(id);
            return View(employee);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = userdal.DeleteUser(id);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }*/
    }









 