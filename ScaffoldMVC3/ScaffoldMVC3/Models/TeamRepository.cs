using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ScaffoldMVC3.Models
{ 
	public class TeamRepository : ITeamRepository
	{
		ScaffoldMVC3Context context = new ScaffoldMVC3Context();

		public IEnumerable<Team> GetAllTeams(params Expression<Func<Team, object>>[] includeProperties)
		{
			IQueryable<Team> query = context.Teams;
			foreach (var includeProperty in includeProperties) {
				query = query.Include(includeProperty);
			}
			return query.ToList();
		}

		public Team GetById(int id)
		{
			return context.Teams.Find(id);
		}

		public void InsertOrUpdate(Team team)
		{
			if (team.TeamId == default(int)) {
				// New entity
				context.Teams.Add(team);
			} else {
				// Existing entity
				context.Teams.Attach(team);
				context.Entry(team).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var team = context.Teams.Find(id);
			context.Teams.Remove(team);
		}

		public void Save()
		{
			context.SaveChanges();
		}
	}

	public interface ITeamRepository
	{
		IEnumerable<Team> GetAllTeams(params Expression<Func<Team, object>>[] includeProperties);
		Team GetById(int id);
		void InsertOrUpdate(Team team);
		void Delete(int id);
		void Save();
	}
}