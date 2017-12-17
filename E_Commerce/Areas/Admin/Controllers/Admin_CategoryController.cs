using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Service.Interfaces;
using Service.Implementations;
using CoreModel.Mappings;
using Newtonsoft.Json;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class Admin_CategoryController : Controller
    {
        IGenericService<ecom_tbl_Category> _iGenericService;
        public Admin_CategoryController()
        {
            _iGenericService = new GenericService<ecom_tbl_Category>();
        }

        // GET: Category
        public ActionResult Index()
        {
            return RedirectToAction("GetCategoryAll");
        }

        // get all the category information
        [HttpGet]
        public ActionResult GetCategoryAll()
        {
            List<ecom_tbl_Category> _lst_ecom_Category = new List<ecom_tbl_Category>();
            try
            {
                _lst_ecom_Category = _iGenericService.Get(filter: null, orderBy: q => q.OrderBy(d => d.ct_Modified_Date)).ToList();
            }
            catch (Exception ex)
            {

            }
            return Json(JsonConvert.SerializeObject(_lst_ecom_Category), JsonRequestBehavior.AllowGet);
        }

        // update the category information to the database.
        [HttpGet]
        public ActionResult UpdateCategory()
        {
            List<ecom_tbl_Category> _lst_ecom_Category = new List<ecom_tbl_Category>();
            try
            {
                _lst_ecom_Category = _iGenericService.Get(filter: null, orderBy: q => q.OrderBy(d => d.ct_Modified_Date), includes: null).ToList();
            }
            catch (Exception ex)
            {

            }
            return Json(JsonConvert.SerializeObject(_lst_ecom_Category), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult UpdateCategory(ecom_tbl_Category _items, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return null;
                }
                if (_items != null)
                {
                    if (id != 0)
                    {
                        var itemInfo = _iGenericService.GetById(id);
                        if (itemInfo != null)
                        {
                            _iGenericService.Update(_items);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("UpdateCategory");
        }

        // Inserting the new records into the database
        [HttpGet]
        public ActionResult InsertCategory()
        {
            List<ecom_tbl_Category> _lst_ecom_Category = new List<ecom_tbl_Category>();
            try
            {
                _lst_ecom_Category = _iGenericService.Get(filter: null, orderBy: q => q.OrderBy(d => d.ct_Modified_Date), includes: null).ToList();
            }
            catch (Exception ex)
            {

            }
            return Json(JsonConvert.SerializeObject(_lst_ecom_Category), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult InsertCategory(ecom_tbl_Category _items)
        {
            try
            {
                if (_items != null)
                {
                    _iGenericService.Insert(_items);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("InsertCategory");
        }

        // deleting the records into the database
        [HttpGet]
        public ActionResult DeleteCategory()
        {
            List<ecom_tbl_Category> _lst_ecom_Category = new List<ecom_tbl_Category>();
            try
            {
                _lst_ecom_Category = _iGenericService.Get(filter: null, orderBy: q => q.OrderBy(d => d.ct_Modified_Date), includes: null).ToList();
            }
            catch (Exception ex)
            {

            }
            return Json(JsonConvert.SerializeObject(_lst_ecom_Category), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCategory(ecom_tbl_Category _items, int id)
        {
            try
            {
                if (_items != null)
                {
                    if (id != 0)
                    {
                        var itemInfo = _iGenericService.GetById(id);
                        if (itemInfo != null)
                        {
                            _iGenericService.Delete(id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("DeleteCategory");
        }
    }
}