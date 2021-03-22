using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Back.Models;
using Back.Repository;
using Back.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        HelpClass getDataWith;
        public DataController(IRepositoryWrapper _repoWrapper)
        {
            this._repoWrapper = _repoWrapper;
            getDataWith = new HelpClass(_repoWrapper);
        }

        [HttpGet]
        [Route("details")]
        public IEnumerable getDetails()
        {
           
            return getDataWith.GetDataFromDetais();
        }

        [HttpGet]
        [Route("storeKeepers")]
        public IEnumerable getStoreKeepers()
        {
            return _repoWrapper.StoreKeeper.FindAll();
        }

        [HttpGet]
        [Route("storeKeepersDetals")]
        public IEnumerable getKepeerDetails()
        {
            return getDataWith.GetData();
        }


        [HttpPost]
        [Route("StoreKeeper")]
        public IActionResult addKeeper([FromBody]StoreKeeper storeKeeper)
        {
            try
            {
                _repoWrapper.StoreKeeper.Create(storeKeeper);
                _repoWrapper.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("500");
            }
        }

        [HttpPost]
        [Route("Details")]
        public IActionResult addDetails([FromForm] string detailinfo)
        {
            try
            {
                Details details = JsonSerializer.Deserialize<Details>(detailinfo);
                details.storeKeeperId = _repoWrapper.StoreKeeper.FindByCondition(x => x.FullName == details.storeKepeerName).FirstOrDefault().Id;
                _repoWrapper.Detail.Create(details);
                _repoWrapper.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("500");
            }
        }

        [HttpDelete]
        [Route("StoreKepeer")]
        public IActionResult deleteKepeer([FromBody] StoreKeeper  storeKeeper)
        {
            try
            {
                _repoWrapper.StoreKeeper.Delete(storeKeeper);
                _repoWrapper.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("500");
            }
        }
        [HttpDelete]
        [Route("Details/{id}")]
        public IActionResult deleteDetail(int id)
        {
            try
            {
                Details data=_repoWrapper.Detail.FindByCondition(x => x.Id == id).FirstOrDefault();
                data.dateDeleted =Convert.ToDateTime(DateTime.Now.ToString("f"));
                data.sum = 0; 
                _repoWrapper.Detail.Update(data);
                _repoWrapper.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest("500");
            }
        }

    }
}
