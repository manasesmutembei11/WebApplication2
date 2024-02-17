﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Repository.Repositories
{

        public class PeopleRepository : IPeopleRepository
        {
            private readonly WebApplication2Context _context;

            public PeopleRepository(WebApplication2Context context)
            {
                _context = context;
            }

            /*  public async Task<PagedList<People>> GetPagedPeopleAsync(int offset, int page, int pageSize, CancellationToken cancellationToken = default(CancellationToken))
               {
                   cancellationToken.ThrowIfCancellationRequested();


                   var query = _context.People.OrderBy(x => x.FirstName)
                       .Select(p => p)
                       .Skip(offset)
                       .Take(pageSize);
                   var result = new PagedList<People>
                   {
                       TotalItemCount = await _context.People.CountAsync(),
                       PageNumber = page,
                       PageSize = pageSize,
                       Source = await query.ToListAsync()
                   };


                   return result; 
               } */

            public async Task<List<People>> GetPeopleAsync()
            {
                return await _context.People.ToListAsync();
            }
            public async Task<List<People>> SearchPeopleAsync(string searchString)
            {
                return await _context.People
                    .Where(m => m.FirstName.Contains(searchString))
                    .ToListAsync();
            }


            public async Task<People> GetPersonByIdAsync(int id)
            {
                return await _context.People.FindAsync(id);
            }

            public async Task AddPersonAsync(People person)
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
            }

            public async Task UpdatePersonAsync(People person)
            {
                _context.People.AddOrUpdate(person);
                await _context.SaveChangesAsync();
            }

            public async Task DeletePersonAsync(int id)
            {
                var person = await _context.People.FindAsync(id);
                if (person != null)
                {
                    _context.People.Remove(person);
                    await _context.SaveChangesAsync();
                }
            }

            public bool PersonExists(int id)
            {
                return _context.People.Any(e => e.Id == id);
            }

        }
    }