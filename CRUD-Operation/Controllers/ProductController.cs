
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CRUD.Domain.Models;

namespace CRUD_Operation.Controllers
{

    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
      

        public ProductController(IProductRepository productRepo )
        {
            _productRepo = productRepo;
           
        }

      /*  public async Task<IActionResult> Index()
        {
            var product = await _productRepo.GetAll();
            return View(product);
        }*/

  /*      [HttpGet]
        public async  Task<IActionResult> CreateOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new Product());
            }
            else
            {
                Product product = await _productRepo.GetById(id);
                if(product != null)
                {
                    return View(product);
                }
                TempData["ErrorMessage"] = $"Product details not found this ID : {id}";
                return RedirectToAction("Index");
            }
            return View();
        }
*/
 /*       [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(model.ID == 0)
                    {
                        await _productRepo.Add(model);
                        TempData["SuccessMessage"] = "Product is Created Successfully!";
                       
                    }
                    else
                    {
                        await _productRepo.Update(model);
                        TempData["SuccessMessage"] = "Product is Updated Successfully!";
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid Model";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] =ex.Message;
                return View();
            }
        }

     */
  /*      public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Product product = await _productRepo.GetById(id);
                if(product != null)
                {
                    return View(product);
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            TempData["ErrorMessage"] = $"Product details not found this id : {id}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfimed(int id)
        {
            try
            {
                await _productRepo.Delete(id);
                TempData["SuccessMessage"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
*/
    }
}
