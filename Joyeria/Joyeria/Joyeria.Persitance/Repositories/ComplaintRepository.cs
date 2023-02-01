﻿using Joyeria.Application.Interfaces;
using Joyeria.Application.Interfaces.Repositories;
using Joyeria.Domain.Entities;
using Joyeria.Persitance.Shared;
using Microsoft.EntityFrameworkCore;

namespace Joyeria.Persitance.Repositories
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public ComplaintRepository(JoyeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Complaint> CreateAsync(Complaint createToComplaints)
        {
            await _dbContext.Complaint.AddAsync(createToComplaints);
            return createToComplaints;
        }

        public async Task DeleteAsync(int id)
        {
            var complaints = await _dbContext.Complaint.FindAsync(id);
            _dbContext.Complaint.Remove(complaints);
        }

        public async Task<IEnumerable<Complaint>> GetComplaintsAsync()
        {
            return await _dbContext.Complaint.ToListAsync();
        }

        public async Task<Complaint> GetComplaintstByIdAsync(int id)
        {
            var complaints = await _dbContext.Complaint.FindAsync(id);
            return complaints;
        }

        public async Task<Complaint> UpdateAsync(Complaint complaintToUpdate)
        {
            //var complaintFound = await _dbContext.Complaint.ToListAsync();
            //var complaintUpdated = complaintFound;
            _dbContext.Complaint.Update(complaintToUpdate);
            return complaintToUpdate;
        }
    }
}
