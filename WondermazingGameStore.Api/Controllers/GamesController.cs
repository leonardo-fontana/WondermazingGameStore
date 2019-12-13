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
using WondermazigGameStore.Context;
using WondermazingGameStore.Domain;

namespace WondermazingGameStore.Api.Controllers
{
    public interface IGamesController
    {
        IQueryable<Game> GetGames();
        IHttpActionResult GetGame(Guid id);
        IHttpActionResult PutGame(Guid id, Game game);
        IHttpActionResult PostGame(Game game);
        IHttpActionResult DeleteGame(Guid id);
    }

    public class GamesController : ApiController, IGamesController
    {
        private DataContext db = new DataContext();

        // GET: api/Games
        public IQueryable<Game> GetGames()
        {
            return db.Games;
        }

        // GET: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult GetGame(Guid id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(Guid id, Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }

            db.Entry(game).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [ResponseType(typeof(Game))]
        public IHttpActionResult PostGame(Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Games.Add(game);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GameExists(game.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(Game))]
        public IHttpActionResult DeleteGame(Guid id)
        {
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }

            db.Games.Remove(game);
            db.SaveChanges();

            return Ok(game);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GameExists(Guid id)
        {
            return db.Games.Count(e => e.Id == id) > 0;
        }
    }
}