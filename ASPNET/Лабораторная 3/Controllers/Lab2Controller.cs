using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAspNet2.Models;

namespace WebAspNet2.Controllers
{
    public class Lab2Controller : Controller
    {
        // GET: Lab2
        public ActionResult ListOfPeople()
        {
            List<Person> people = new List<Person>();
            using (var db = new abcEntities())
            {
                people = db.People.OrderByDescending(x => x.Age)
                    .ThenBy(x => x.LastName)
                    .ThenBy(x => x.FirstName).ToList();
            }
            return View(people);
        }
        public ActionResult PersonDetails(Guid personId)
        {
            Person model = new Person();
            using (var db = new abcEntities())
            {
                model = db.People.Find(personId);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult CreatePerson()
        {
            ViewBag.Genders = new SelectList(GetGendersList(), "Item1", "Item2");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePerson(Person newPerson)
        {
            if (ModelState.IsValid)
            {
                using (var context = new abcEntities())
                {
                    Person person = new Person
                    {
                        Id = Guid.NewGuid(),
                        lastName = newPerson.newPerson,
                        firstName = newPerson.firstName,
                        Patronymic = newPerson.patronymic,
                        Gender = newPerson.Gender,
                        Age = newPerson.Age,
                        HasJob = newPerson.HasJob,
                    };
                    newPerson.id = Guid.NewGuid();
                    context.People.Add(newPerson);
                    context.SaveChanges();
                }
                return RedirectToAction("ListOfPeople");
            }
            ViewBag.Genders = new SelectList(GetGendersList(), "Item1", "item2");
            return View(newPerson);
        }
        List<Tuple<string, string>> GetGendersList()
        {
            List<Tuple<string, string>> genders = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Ж", "Женский"),
                new Tuple<string, string>("м", "Мужской")
            };
            return genders;
        }
    public class abcEntities : DbContext
    {
        public abcEntities()
            :base("base=abcEntities")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Question> Question { get; set; }
    }
}