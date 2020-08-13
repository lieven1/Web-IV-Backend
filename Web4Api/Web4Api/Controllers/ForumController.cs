using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web4Api.Data;
using Web4Api.Models;

namespace Web4Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ForumController : ControllerBase
    {
        private readonly IForumRepository _forumRepository;

        public ForumController(IForumRepository forumRepository)
        {
            _forumRepository = forumRepository;
        }

        [HttpGet("getFora")]
        [AllowAnonymous]
        public IEnumerable<Forum> GetFora(string filter)
        {

            IEnumerable<Forum> fora = _forumRepository.Fora(filter).OrderBy(f => f.Naam);
            return fora;
        }

        [HttpGet("getForum")]
        [AllowAnonymous]
        public Forum GetForum(int id)
        {
            return _forumRepository.GetById(id);
        }

        [HttpPost]
        public ActionResult Add(Forum forum)
        {
            try
            {
                _forumRepository.Add(forum);
                _forumRepository.SaveChanges();
                return new AcceptedResult();
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [ServiceFilter(typeof(GebruikerFilter))]
        [HttpPost("follow")]
        public ActionResult Follow(Gebruiker gebruiker, string forumNaam)
        {
            try
            {
                Forum forum = _forumRepository.GetBy(forumNaam);
                forum.addLid(gebruiker);
                _forumRepository.SaveChanges();
                return new AcceptedResult();
            } catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
