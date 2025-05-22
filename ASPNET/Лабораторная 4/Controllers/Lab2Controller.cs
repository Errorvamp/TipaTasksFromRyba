using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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

        public class PersonVM
        {
            public System.Guid Id { get; set; }
            [Required]
            [DisplayName("Фамилия")]
            [StringLength(100, MinimumLength = 2)]
            public string LastName { get; set; }
            [Required]
            [DisplayName("Имя")]
            [StringLength(100)]
            public string FirstName { get; set; }
            [DisplayName("Отчество")]
            [StringLength(100)]
            public string Patronymic { get; set; }
            [Required]
            [DisplayName("Полных лет")]
            [Range(18, 100)]
            public int Age { get; set; }
            [DisplayName("Пoл")]
            [StringLength(1)]
            public string Gender { get; set; }
            [Required]
            [DisplayName("Трудоустроен")]
            public bool HasJob { get; set; }

            [DisplayName("Дата рождения")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime Birthday { get; set; }
            [DisplayName("Дата и время добавления")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddThh:mm}", ApplyFormatInEditMode = true)]
            public DateTime InsertedDateTime { get; set; }
            [DisplayName("Время подъема")]
            [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
            public DateTime WakeUpTime { get; set; }
        }

        [HttpGet]

        public ActionResult EditPerson(Guid personID)
        {
            if (MadelState.IsValid)
            {
                PersonVM model;
                using (var context = new abcEntities())
                {
                    Person person = context.People.Find(personID);
                    model = new PersonVM
                    {
                        Id = person.Id,
                        LastName = person.LastName,
                        FirstName = person.FirstName,
                        Patronymic = person.Patronymic,
                        Gender = person.Gender,
                        Age = person.Age,
                        HasJob = person.HasJob
                    };
                    context.People.Attach(editedPerson);
                    context.Entry(editedPerson).State = System.DateTime.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return RedirectToAction("ListOfPeople");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeletePerson(Guid personID)
        {
            Person personToDelete;
            using (var context = new abcEntities())
            {
                personToDelete = context.People.Find(personID);
            }
            return View(personToDelete);
        }


        [HttpPost, ActionName("DeletePerson")]

        public ActionResult DeleteConfirmed(Guid personID)
        {
            using (var context = new abcEntities())
            {
                Person personToDelete = new Person
                {
                    Id = personID
                };
                context.Entry(personToDelete).State = System.Data.Entity.EntityState.Deleted;

                return RedirectToAction("ListOfPeople");
            }
        }

        [ChildActionOnly]
        public ActionResult QuestionAnswered(Guid personID)
        {
            string message = "";
            using (var context = new abcEntities())
            {
                int questionAnsweredNumber = context.People.Find(personID).Answers.Count;
                message = $"Вопросов отвечено: {questionAnsweredNumber}.";
            }
            return PartialView("QuestionAnswered", message);
        }
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