using lb5APS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lb5APS.Controllers
{
    public class UseSingleController : ApiController
    {
        //Звертання до синглтона і створення бд
        private Singleton single = Singleton.Build();

        //повертає всі елементи бд
        public IHttpActionResult Get([FromUri]int clock)
        {
            try
            {
                return Ok(single.ShowElByHour(clock));
            }catch(Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        //додає до бд елемент
        public IHttpActionResult Post([FromBody] Event e)
        {
            try
            {
                return Ok(single.AddEl(e));
            }catch(Exception exc)
            {
                return InternalServerError(exc);
            }
        }

        //очищує події
        public void Delete()
        {
            single.DelEl();
        }
    }
}
