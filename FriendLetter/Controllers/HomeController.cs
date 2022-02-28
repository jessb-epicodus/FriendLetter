using Microsoft.AspNetCore.Mvc;
using FriendLetter.Models;

namespace FriendLetter.Controllers
{
  public class HomeController : Controller
  {
    [Route("/hello")] // The route decorator is overriding the default URL path
    public string Hello() { return "Hello friend!"; }
    [Route("/goodbye")]
    public string Goodbye() { return "Goodbye friend."; }
    [Route("/")]  // root path
    public ActionResult Letter() 
    { 
      // model binding
      LetterVariable myLetterVariable = new LetterVariable(); 
      myLetterVariable.Recipient = "Lina";
      myLetterVariable.Sender = "Jasmine";
      myLetterVariable.Location = "Iceland";
      myLetterVariable.Souvenir = "Polar-Bear rug";
      return View(myLetterVariable); 
    } 
    [Route("/form")]
    public ActionResult Form() { return View(); 
    }
    [Route("/postcard")]
    public ActionResult Postcard(string recipient, string sender, string location, string souvenir)
    {
      LetterVariable myLetterVariable = new LetterVariable();
      myLetterVariable.Recipient = recipient;
      myLetterVariable.Sender = sender;
      myLetterVariable.Location = location;
      myLetterVariable.Souvenir = souvenir;
      return View(myLetterVariable);
    }
  }
}