using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiApp.Models;
using WebApiApp.Repositories;
using System.Web.Http.Description;
namespace WebApiApp.Controllers
{
    public class CategoryAPIController : ApiController
    {
        // defin the repository reference for Category
        IRepository<Category, int> catRepository;
        /// <summary>
        /// Inject the CategoryRepositoiry in ctor
        /// </summary>
        public CategoryAPIController(IRepository<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }

        [ResponseType(typeof(List<Category>))]
        public IHttpActionResult Get()
        {
            var cats = catRepository.Get();
            return Ok(cats);
        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult Get(int id)
        {
            var cat = catRepository.Get(id);
            return Ok(cat);
        }

        [ResponseType(typeof(Category))]
        public IHttpActionResult Post(Category category)
        {
            category = catRepository.Create(category);
            return Ok(category);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult Put(int id, Category category)
        {
            bool res = catRepository.Update(id,category);
            return Ok(res);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult Delete(int id)
        {
            bool res = catRepository.Delete(id);
            return Ok(res);
        }

    }
}
