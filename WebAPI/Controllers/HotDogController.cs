using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/hotdog")]
    public class HotDogController : ApiController
    {
        private WebAPIContext db = new WebAPIContext();
        
        public IQueryable<HotDog> GetHotDogs()
        {
            return db.HotDogs;
        }
        [ResponseType(typeof(HotDog))]
        public IHttpActionResult GetHotDog(int id)
        {
            HotDog hotdog = db.HotDogs.Find(id);
            if (hotdog == null)
            {
                return NotFound();
            }

            return Ok(hotdog);
        }
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotDog(int id, HotDog hotdog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotdog.HotDogId)
            {
                return BadRequest();
            }

            db.Entry(hotdog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotDogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        [ResponseType(typeof(HotDog))]
        public IHttpActionResult PostHotDog(HotDog hotdog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HotDogs.Add(hotdog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hotdog.HotDogId }, hotdog);
        }
        
        [ResponseType(typeof(HotDog))]
        [HttpPost]
        [Route("{id:int}/order")]
        public IHttpActionResult OrderHotDog([FromUri] int id, [FromBody] OrderHotDog hotdog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbHotdog = db.HotDogs.FirstOrDefault(x => x.HotDogId == id);
            var order = new Order
            {
                Customer = "xx",
                OrderDate = DateTime.Now                
            };

            db.Orders.Add(order);

            var orderDetails = new OrderDetail
            {
                HotDog = dbHotdog,
                Order = order,
                Quantity = hotdog.Quantity
            };

            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();

            return Ok();
        }

        [ResponseType(typeof(HotDog))]
        [HttpGet]
        [Route("cart")]
        public IHttpActionResult GetCart()
        {
            var hotDogs = db.OrderDetails.Select(x => x.HotDog);
            return Ok(hotDogs);
        }
        
        [ResponseType(typeof(HotDog))]
        public IHttpActionResult DeleteHotDog(int id)
        {
            HotDog hotdog = db.HotDogs.Find(id);
            if (hotdog == null)
            {
                return NotFound();
            }

            db.HotDogs.Remove(hotdog);
            db.SaveChanges();

            return Ok(hotdog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotDogExists(int id)
        {
            return db.HotDogs.Count(e => e.HotDogId == id) > 0;
        }
    }
}