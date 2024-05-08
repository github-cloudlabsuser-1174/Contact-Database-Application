using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // Add the new user to the list
                userlist.Add(user);
                // Redirect to the Index action to display the list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return to the Create view to display the form again
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var userInList = userlist.FirstOrDefault(u => u.Id == id);
                if (userInList == null)
                {
                    return HttpNotFound();
                }
                // Update the userInList properties with the values from the user parameter
                userInList.Name = user.Name;
                userInList.Email = user.Email;
                // Add other properties as needed

                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                userlist.Remove(user);
            }
            return RedirectToAction("Index");
        }
    }
}
