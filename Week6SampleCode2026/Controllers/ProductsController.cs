using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductModel;
using Week6SampleCode2026.Data.Business_Data;
using Week6SampleCode2026.Models;

public class ProductsController : Controller
{
    private BusinessContext _context;

    public ProductsController(BusinessContext context)
    {
        _context = context;
    }

    // GET: PRODUCTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Products.Include(ps => ps.Suppliers).ToListAsync());
    }

    // GET: PRODUCTS/Details/5
    [Route("Products/Details/{productid}")]
    public async Task<IActionResult> Details(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.ProductID == productid);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    private List<SelectListItem> FillCategories(int? CurrentCategory)
    {
        // Selected items for the dropdown list
        List<SelectListItem> items = new List<SelectListItem>();

        List<Category> categories = _context.Categories.ToList();
            foreach (var item in categories)
            {
                items.Add(new SelectListItem()
                { Value = item.CategoryID.ToString(), Text = item.Description, 
                    Selected = item.CategoryID == CurrentCategory });
            }
        
        return items;
    }

    private List<SelectListItem> FillSuppliers(int? CurrentSupplier)
    {
        // Selected items for the dropdown list
        List<SelectListItem> items = new List<SelectListItem>();

        List<Supplier> suppliers = _context.Suppliers.ToList();
        foreach (var item in suppliers)
        {
            items.Add(new SelectListItem()
            { Value = item.SupplierID.ToString(), Text = item.SupplierName, 
                Selected = item.SupplierID == CurrentSupplier, });
        }

        return items;
    }

    // GET: PRODUCTS/Create
    public IActionResult Create()
    {
        ViewBag.Categories = FillCategories(null);
        ViewBag.Suppliers = FillSuppliers(null);
        return View();
    }

    // POST: PRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProductID,SupplierID,CategoryID,Description,UnitPrice,dateFirstIssued,QuantityInStock")] ProductViewModel product)
    {
        //var category = _context.Categories.FirstOrDefault(c => c.CategoryID == product.CategoryID);
        var supplier = _context.Suppliers
            .FirstOrDefault(s => s.SupplierID == product.SupplierID);

        // Create a new Product object and set its properties
        var newProduct = new Product
        {
            ProductID = product.ProductID,
            CategoryID = product.CategoryID, // EF will spot the associated category based on the CategoryID
            Description = product.Description,
            UnitPrice = product.UnitPrice,
            dateFirstIssued = product.dateFirstIssued,
            QuantityInStock = product.QuantityInStock,
            //associatedCategory = null, // Set the associated category
        };
        // as SupplierId is via a link table relationship,
        // we need to add the supplier to the Suppliers collection of the Product entity
        if (supplier != null)
        {
            newProduct.Suppliers = new List<Supplier> { supplier };
        }

        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Categories = FillCategories(null);
        ViewBag.Suppliers = FillSuppliers(null);
        return View(product);
    }

    // GET: PRODUCTS/Edit/5
    [HttpGet]
    [Route("Products/Edit/{productid}")]
    public async Task<IActionResult> Edit(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        Product? product = await _context.Products
            .Include(pr => pr.Suppliers) // including Suppliers collection to be able to update it
            .FirstOrDefaultAsync(pr => pr.ProductID == productid);

        if (product == null)
        {
            return NotFound();
        }
        // Else is assumed fill the Product Model with the values from the Product entity and pass it to the view
        ViewBag.Categories = FillCategories(null);
        //if(product.Suppliers != null && product.Suppliers.Any())
        //{
        //    ViewBag.Suppliers = FillSuppliers(product.Suppliers.FirstOrDefault()?.SupplierID);
        //}
        //else
        //{
            ViewBag.Suppliers = FillSuppliers(null);
        //}
            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
                dateFirstIssued = product.dateFirstIssued,
                QuantityInStock = product.QuantityInStock,
                SupplierID = product.Suppliers != null && product.Suppliers.Any() ? 
                                product.Suppliers.FirstOrDefault()?.SupplierID ?? 0 : 0

            };
            return View(productViewModel);
    }

    // POST: PRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Products/Edit/{productid}")]

    public async Task<IActionResult> Edit(int? productid, [Bind("ProductID,CategoryID,SupplierID,Description,UnitPrice,dateFirstIssued,QuantityInStock,associatedCategory,Suppliers")] ProductViewModel product)
    {
        if (productid != product.ProductID)
        {
            return NotFound();
        }
        Product? p = await _context.Products
            .Include(pr => pr.Suppliers) // including Suppliers collection to be able to update it
            .FirstOrDefaultAsync(pr => pr.ProductID == productid);
        
        if (p == null) { 
            return NotFound();
        }

        // Else assumed 
        // Fill the product entity with the updated values from the ProductViewModel
        p.CategoryID = product.CategoryID;
        //p.SupplierID = product.SupplierID;
        p.Description = product.Description;
        p.UnitPrice = product.UnitPrice;
        p.dateFirstIssued = product.dateFirstIssued;
        p.QuantityInStock = product.QuantityInStock;
        var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierID == product.SupplierID);
        // as SupplierId is via a link table relationship,
        // we need to add the supplier to the Suppliers collection of the Product entity
        // supplier may have changed
        if (supplier != null && p.Suppliers != null && !p.Suppliers.Contains(supplier))
        {
            p.Suppliers = new List<Supplier> { supplier };
        }

        if (ModelState.IsValid)
        {   
            try
            {
                _context.Update(p);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Delete/5
    public async Task<IActionResult> Delete(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = await _context.Products
            .FirstOrDefaultAsync(m => m.ProductID == productid);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? productid)
    {
        var product = await _context.Products.FindAsync(productid);
        if (product != null)
        {
            _context.Products.Remove(product);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int? productid)
    {
        return _context.Products.Any(e => e.ProductID == productid);
    }
}
