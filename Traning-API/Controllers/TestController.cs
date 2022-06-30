using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Traning_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TestController : ControllerBase
    {
        //[Route("GetName")]
        [HttpGet]
        public string Name()
        {
            return "Vaild";
        }

        [Route("GetName")]
        [HttpGet]
        public string GetName()
        {
            return "Osama Alessa";
        }

        [Route("GetName22/{id}/{username}/{password}")]
        [HttpGet]
        public string GetName1(int id,string username , string password)
        {


            return username;
          
        }

        [Route("Check/{name}")]
        [HttpGet]
        public JsonResult CheckName(string name)
        {

            var list = new List<string>(){
            "Osama",
            "Ahmead",
            "Kother"
            };

            foreach (var item in list)
            {
                if( item==name)
                {
                    return new JsonResult(new { checkofName = true });

                }
            }
            return new JsonResult(new { checkofName = false });



        }

        [Route("CountVowels/{name}")]
        [HttpGet]
        public JsonResult Count(string name)
        {


            var vowels = 0;

            for(int i=0;i<name.Length;i++ )
            {
                if (IsVowel(char.ToLower(name[i])))
                    vowels++;
            }

           
            return new JsonResult(new { countOfVowels = vowels });
        }

        [HttpGet("SetName")]
        public JsonResult SetName([FromBody]  User user )
        {

            JsonResult json = new JsonResult(user);

            return json;
        }



        [HttpGet("Search")]
        public JsonResult SearchBetween_TwoDate(Order order)
        {

            var list = new List<Order>();

            list.Add(new Order { Name_Product = "Bnana", FromDate =System.DateTime.Now, User= new User {UserName="Osama",Password="12345678" } });
            list.Add(new Order { Name_Product = "Bnana1", FromDate = System.DateTime.Now, User= new User {UserName="Osama",Password="12345679" } });
            list.Add(new Order { Name_Product = "Bnana2", FromDate = System.DateTime.Now, User= new User {UserName="Osama",Password="123456710" } });


            list = list.Where(pass => pass.User.Password == order.User.Password).ToList();

            JsonResult json = new JsonResult(list);

          

            return json;


        }


        [HttpGet("Information")]
        public JsonResult Get_InformationEmployee(Employee emp)
        {

           

            return new JsonResult(emp);
        }

        //Check if a Chararchter is vowel 
        private bool IsVowel(char x)
        {

            string letterVowels = "auioe";

            for (int i = 0; i < letterVowels.Length; i++)
            {
                if (letterVowels[i] == x)
                    return true;
            }

            return false;
        }


    }
}
