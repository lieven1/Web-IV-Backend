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
        private readonly IPostRepository _postRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public ForumController(IForumRepository forumRepository, IPostRepository postRepository, IGebruikerRepository gebruikerRepository)
        {
            _forumRepository = forumRepository;
            _postRepository = postRepository;
            _gebruikerRepository = gebruikerRepository;
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

        [HttpGet("getPost")]
        [AllowAnonymous]
        public Post GetPost(int id)
        {
            return _postRepository.GetById(id);
        }

        [HttpGet("getPosts")]
        [AllowAnonymous]
        public IEnumerable<Post> GetPosts(int forumId)
        {
            Forum f = _forumRepository.GetById(forumId);
            IEnumerable<Post> posts = _postRepository.Posts(f);
            return posts;
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

        [HttpGet("follow")]
        public ActionResult Follow(int forumId)
        {
            try
            {
                Gebruiker gebruiker = _gebruikerRepository.GetBy(User.Identity.Name);
                Forum forum = _forumRepository.GetById(forumId);
                forum.addLid(gebruiker);
                _forumRepository.SaveChanges();
                return new AcceptedResult();
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("addPost")]
        public ActionResult AddPost(Post post)
        {
            try
            {
                post.Poster = _gebruikerRepository.GetBy(User.Identity.Name);
                Forum forum = _forumRepository.GetById(post.Forum.Id);
                forum.Posts.Add(post);
                _forumRepository.SaveChanges();
                return new AcceptedResult();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
