using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreExample.Config;
using EntityFrameworkCoreExample.Managers;
using EntityFrameworkCoreExample.Models;

namespace EntityFrameworkCoreExample.Controllers
{
	public class PostsController : Controller
	{
		private readonly PostManager _postManager;

		public PostsController(PostManager postManager)
		{
			_postManager = postManager;
		}

		// GET: Posts
		public ViewResult Index()
		{
			return View(_postManager.GetAll());

		}

		// GET: Posts/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var postModel = _postManager.Find(id);

			return View(postModel);
		}

		// GET: Posts/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Posts/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Title,Content")] PostModel postModel)
		{
			if (ModelState.IsValid)
			{
				_postManager.AddPost(postModel);
				return RedirectToAction(nameof(Index));
			}
			return View(postModel);
		}

		// GET: Posts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var postModel = _postManager.Find(id);
			if (postModel == null)
			{
				return NotFound();
			}

			return View(postModel);
		}

		// POST: Posts/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] PostModel postModel)
		{
			if (id != postModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				_postManager.UpdatePost(postModel);

				return RedirectToAction(nameof(Index));
			}
			return View(postModel);
		}

		// GET: Posts/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var postModel = _postManager.Find(id);
			if (postModel == null)
			{
				return NotFound();
			}

			return View(postModel);
		}

		// POST: Posts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			_postManager.RemovePost(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
