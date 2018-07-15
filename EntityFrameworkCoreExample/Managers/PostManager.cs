using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using EntityFrameworkCoreExample.Config;
using EntityFrameworkCoreExample.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreExample.Managers
{
	public class PostManager
	{
		private readonly EFCDbContext _context;

		public PostManager(EFCDbContext context)
		{
			_context = context;
		}

		public void AddPost(PostModel postModel)
		{
			_context.Add(postModel);

			try
			{
				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				if (postModel.Id != default(int))
				{
					postModel.Id = default(int);
					_context.SaveChanges();
				}
			}

		}

		public void RemovePost(int id)
		{
			var post = _context.Posts.Single(q => q.Id == id);
			_context.Remove(post);

			_context.SaveChanges();
		}

		public void UpdatePost(PostModel postModel)
		{
			_context.Posts.Update(postModel);
			_context.SaveChanges();
		}

		public void ChangeTitle(int id, string newTitle)
		{
			var post = _context.Posts.Single(q => q.Id == id);
			post.Title = newTitle;

			_context.Posts.Update(post);

			try
			{
				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				if (post.Title == null)
				{
					post.Title = "Brak Tytułu";
				}

				_context.SaveChanges();
			}
		}

		public List<PostModel> GetAll()
		{
			return _context.Posts.ToList();
		}

		public PostModel Find(int? id)
		{
			var post = _context.Posts.SingleOrDefault(q => q.Id == id);
			if (post == null)
			{
				throw new Exception($"Nie ma rekordu w tabeli Post o ID: {id}");
			}

			return post;
		}
	}
}
