using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestApi.Models
{
    // Patient context for the database
    public class PatientContext : DbContext, IPatientContext
    {

        public PatientContext()
            : base("PatientContext")
        {
            Database.SetInitializer<PatientContext>(null);
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}