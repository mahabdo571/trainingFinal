using EveryThingLO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace ETAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIProdacts : ControllerBase
    {
    

        public APIProdacts()
        {
          
        }


        [HttpGet]
        public async Task<IActionResult> getProdacts()
        {
           

            var prodact =await clsProducts.GetAlllist();

            return Ok(prodact);

        }


        [HttpGet("{ProductID}")]
        public  IActionResult getProdacts(int ProductID)
        {
           

            var prodact = clsProducts.Find(ProductID);

            if (prodact == null)
                return NotFound($"prode id {ProductID} not found...");


            return Ok(prodact);

        }


        [HttpPost]
        public  IActionResult AddProdact(clsProducts prod)
        {
         
           if(prod.Save(out Exception ex))
            {
                return Ok(prod.ProductID);
            }
            else
            {
                return BadRequest(ex.Message);
                    }

        }

        [HttpPut]
        public IActionResult EditProdact(clsProducts prod)
        {
            var p = clsProducts.Find(prod.ProductID);

            if (p == null)
                return NotFound($"prode id {prod.ProductID} not found...");

            p = prod;
            p._mode = clsProducts.MODE.UPDATE;
                

            
          if(  p.Save(out Exception ex))
            {
                return Ok(p);
            }
            else
            {
                return BadRequest(ex.Message);
            }

        
        }  
        
        
        [HttpPatch("{ProductID}")]
        public IActionResult EditProdactP([FromBody] JsonPatchDocument<clsProducts> prod,[FromRoute]int ProductID)
        {
            var p = clsProducts.Find(ProductID);

            if (p == null)
                return NotFound($"prode id {ProductID} not found...");



            prod.ApplyTo(p);
  
          if(  p.Save(out Exception ex))
            {
                return Ok(p);
            }
            else
            {
                return BadRequest(ex.Message);
            }

        
        }
        
        [HttpDelete("{ProductID}")]
        public IActionResult DeleteProdact(int ProductID)
        {
            var p = clsProducts.Find(ProductID);

            if (p == null)
                return NotFound($"prode id {ProductID} not found...");

         
                

            
          if( clsProducts.DeleteItem(ProductID))
            {
                return Ok(p);
            }
            else
            {
                return BadRequest();
            }

        
        }
    }


   
}
