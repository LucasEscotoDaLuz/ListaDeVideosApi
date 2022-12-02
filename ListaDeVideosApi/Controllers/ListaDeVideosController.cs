using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeVideosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeVideosController : ControllerBase
    {
        private static List<ListaDeVideos> videos = new List<ListaDeVideos>();

        private readonly DataContext _context;

        public ListaDeVideosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaDeVideos>>> Get()
        {
            return Ok(await _context.ListaDeVideosDb.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ListaDeVideos>>> AddVideo(ListaDeVideos video)
        {
            _context.ListaDeVideosDb.Add(video);
            await _context.SaveChangesAsync();
            return Ok(await _context.ListaDeVideosDb.ToListAsync());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ListaDeVideos>>> Get(int id)
        {
            var video = await _context.ListaDeVideosDb.FindAsync(id);
            if(video == null)
            {
                return BadRequest("O vídeo de Id informado não consta na lista");
            }
            else
            {
                return Ok(video);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<ListaDeVideos>>> UpdateVideo(ListaDeVideos request)
        {
            var dbVideo = await _context.ListaDeVideosDb.FindAsync(request.Id);
            if (dbVideo == null)            
                return BadRequest("O vídeo de Id informado não consta na lista");

            dbVideo.Id = request.Id;
            dbVideo.Categoria = request.Categoria;
            dbVideo.Titulo = request.Titulo;
            dbVideo.Duracao = request.Duracao;
            dbVideo.Url = request.Url;
            
            await _context.SaveChangesAsync();
            return Ok(await _context.ListaDeVideosDb.ToListAsync());
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ListaDeVideos>>> Delete(int id)
        {
            var dbVideo = videos.Find(h => h.Id == id);
            if (dbVideo == null)
            {
                return BadRequest("O vídeo de Id informado não consta na lista");
            }             
            else
            {
                _context.ListaDeVideosDb.Remove(dbVideo);
                await _context.SaveChangesAsync();
                
                return Ok(await _context.ListaDeVideosDb.ToListAsync());

            }
        }




    }
}
