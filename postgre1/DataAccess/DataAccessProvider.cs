using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postgre1.Models;
using postgre1.DataAccess;

namespace postgre1.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddPatientRecord(Patient patient)
        {
            _context.patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatientRecord(Patient patient)
        {
            _context.patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatientRecord(object id)
        {
            var entity = _context.patients.Find(id);
            _context.patients.Remove(entity);
            _context.SaveChanges();
        }

        public Patient GetPatientSingleRecord(object id)
        {
            return _context.patients.Find(id);
        }

        public List<Patient> GetPatientRecords()
        {
            return _context.patients.ToList();
        }
    }
}
